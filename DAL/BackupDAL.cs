using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BE;

namespace DAL
{
    public class BackupException : Exception
    {
        public BackupException(string message, Exception inner = null)
            : base(message, inner) { }
    }

    public class BackupDAL
    {
        private readonly string _backupFolder;
        private readonly string _connectionString;
        private readonly int _restoreTimeoutSeconds;
        private readonly string _csvPath;
        private static readonly object _csvLock = new object();

        public BackupDAL()
        {
           
            _connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]?.ConnectionString
                ?? throw new BackupException("Falta la cadena de conexión 'DefaultConnection'.");

            _backupFolder = ConfigurationManager.AppSettings["BackupFolder"]
                ?? throw new BackupException("Falta configurar 'BackupFolder' en appSettings.");

            if (!Directory.Exists(_backupFolder))
                Directory.CreateDirectory(_backupFolder);

            _csvPath = Path.Combine(_backupFolder, "backup_history.csv");

            if (!int.TryParse(ConfigurationManager.AppSettings["RestoreTimeoutSeconds"],
                              out _restoreTimeoutSeconds))
                _restoreTimeoutSeconds = 600;

            if (!File.Exists(_csvPath))
            {
                File.WriteAllText(_csvPath,
                    "Id,Description,CreatedAt,FileName,User,MachineName\r\n");
            }
        }

        /// <summary>
        /// Lista únicamente los backups registrados en la tabla.
        /// </summary>
        public IList<Backup> Listar()
        {
            var lista = new List<Backup>();
            const string sql = @"
                SELECT Id, Description, CreatedAt, FilePath
                  FROM dbo.Backups
              ORDER BY CreatedAt DESC;";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new Backup
                        {
                            Id = rdr.GetGuid(rdr.GetOrdinal("Id")),
                            Description = rdr.GetString(rdr.GetOrdinal("Description")),
                            CreatedAt = rdr.GetDateTime(rdr.GetOrdinal("CreatedAt")),
                            FilePath = rdr.GetString(rdr.GetOrdinal("FilePath"))
                        });
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Lee todo el historial del CSV (incluye backups “externos”).
        /// </summary>
        public IList<BackupHistoryEntry> ListarHistorial()
        {
            var hist = new List<BackupHistoryEntry>();
            string[] lines;
            lock (_csvLock)
            {
                lines = File.ReadAllLines(_csvPath);
            }

            for (int i = 1; i < lines.Length; i++)
            {
                var cols = SplitCsvLine(lines[i]);
                if (cols.Length < 6) continue;

                if (!Guid.TryParse(cols[0], out var id)) id = Guid.Empty;
                var desc = UnescapeCsv(cols[1]);
                if (!DateTime.TryParseExact(cols[2], "o",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var created))
                {
                    DateTime.TryParse(cols[2], out created);
                }

                hist.Add(new BackupHistoryEntry
                {
                    Id = id,
                    Description = desc,
                    CreatedAt = created,
                    FileName = cols[3],
                    User = cols[4],
                    MachineName = cols[5]
                });
            }

            return hist
                .OrderByDescending(h => h.CreatedAt)
                .ToList();
        }

        /// <summary>
        /// Crea un backup físico, lo registra en la tabla y en el CSV.
        /// Lanza BackupException en caso de error.
        /// </summary>
        public Guid Crear(string descripcion)
        {
            try
            {
                var id = Guid.NewGuid();
                var now = DateTime.UtcNow;
                var stamp = now.ToString("yyyyMMdd_HHmmss");
                var safeDesc = descripcion.Replace(" ", "_");
                var fileName = $"db_backup_{safeDesc}_{stamp}.bak";
                var filePath = Path.Combine(_backupFolder, fileName);
                var dbName = new SqlConnectionStringBuilder(_connectionString).InitialCatalog;

                // 1) Backup SQL
                const string sqlBackup = @"
                    BACKUP DATABASE [{0}]
                    TO DISK = @File
                    WITH FORMAT, INIT, NAME = @Name;";
                ExecuteNonQuery(
                    _connectionString,
                    string.Format(sqlBackup, dbName),
                    cmd =>
                    {
                        cmd.Parameters.AddWithValue("@File", filePath);
                        cmd.Parameters.AddWithValue("@Name", $"Full Backup {stamp}");
                    },
                    _restoreTimeoutSeconds
                );

                // 2) Registrar en tabla
                const string sqlIns = @"
                    INSERT INTO dbo.Backups
                      (Id, Description, CreatedAt, FilePath, PerformedBy, MachineName)
                    VALUES
                      (@Id,@Desc,@CreatedAt,@Path,@User,@Machine);";
                ExecuteNonQuery(_connectionString, sqlIns, cmd =>
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Desc", descripcion);
                    cmd.Parameters.AddWithValue("@CreatedAt", now);
                    cmd.Parameters.AddWithValue("@Path", filePath);
                    cmd.Parameters.AddWithValue("@User", Environment.UserName);
                    cmd.Parameters.AddWithValue("@Machine", Environment.MachineName);
                });

                // 3) Log CSV
                var line = string.Join(",",
                    id,
                    EscapeCsv(descripcion),
                    now.ToString("o"),
                    fileName,
                    Environment.UserName,
                    Environment.MachineName);
                lock (_csvLock)
                {
                    File.AppendAllText(_csvPath, line + "\r\n");
                }

                return id;
            }
            catch (SqlException ex)
            {
                throw new BackupException("Error al crear el backup.", ex);
            }
            catch (IOException ex)
            {
                throw new BackupException("Error al escribir el archivo de backup o CSV.", ex);
            }
        }

        /// <summary>
        /// Restaura el backup indicado y luego sincroniza cualquier .bak extra al CSV y tabla.
        /// </summary>
        public void Restaurar(Guid backupId)
        {
            if (backupId == Guid.Empty)
                throw new BackupException("El identificador de backup no puede ser Guid.Empty.");

            string path = null;
            var dbName = new SqlConnectionStringBuilder(_connectionString).InitialCatalog;

            // 1) Obtener ruta desde la tabla
            const string sqlSel = @"
                SELECT FilePath
                  FROM dbo.Backups
                 WHERE Id = @Id;";
            ExecuteReader(_connectionString, sqlSel, cmd =>
            {
                cmd.Parameters.AddWithValue("@Id", backupId);
            },
            rdr =>
            {
                if (!rdr.Read())
                    throw new BackupException($"No se encontró un backup con Id = {backupId}.");
                path = rdr.GetString(rdr.GetOrdinal("FilePath"));
            });

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                throw new BackupException($"El archivo de backup no existe: {path}");

            // 2) Ejecutar RESTORE
            var csb = new SqlConnectionStringBuilder(_connectionString)
            {
                InitialCatalog = "master",
                Pooling = false
            };
            SqlConnection.ClearAllPools();

            try
            {
                ExecuteNonQuery(
                    csb.ConnectionString,
                    $"ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;",
                    null,
                    _restoreTimeoutSeconds
                );

                ExecuteNonQuery(
                    csb.ConnectionString,
                    $"RESTORE DATABASE [{dbName}] FROM DISK = @File WITH REPLACE;",
                    cmd => cmd.Parameters.AddWithValue("@File", path),
                    _restoreTimeoutSeconds
                );

                ExecuteNonQuery(
                    csb.ConnectionString,
                    $"ALTER DATABASE [{dbName}] SET MULTI_USER;",
                    null,
                    _restoreTimeoutSeconds
                );
            }
            catch (SqlException ex)
            {
                throw new BackupException("Error durante el proceso de restauración.", ex);
            }

            // 3) Sincronizar los .bak que queden en disco y no estén en la tabla
            SincronizarMetadataDesdeDisco();
        }

        /// <summary>
        /// Detecta en el folder de backups cualquier .bak no registrado aún
        /// y lo añade a la tabla y al CSV.
        /// </summary>
        public void SincronizarMetadataDesdeDisco()
        {
            // 1) Paths ya en la tabla
            var existentesEnTabla = Listar()
                .Select(d => d.FilePath)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            // 2) Nombres de fichero ya en el CSV
            HashSet<string> existentesEnCsv;
            lock (_csvLock)
            {
                existentesEnCsv = new HashSet<string>(
                    File.ReadAllLines(_csvPath)
                        .Skip(1)
                        .Select(line => SplitCsvLine(line)[3]),  // columna FileName
                    StringComparer.OrdinalIgnoreCase
                );
            }

            foreach (var path in Directory.GetFiles(_backupFolder, "*.bak"))
            {
                if (existentesEnTabla.Contains(path))
                    continue;

                // extraer metadata…
                var name = Path.GetFileNameWithoutExtension(path);
                var desc = name;
                var created = File.GetCreationTimeUtc(path);
                const string prefix = "db_backup_";
                if (name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    var rest = name.Substring(prefix.Length);
                    var idx = rest.LastIndexOf('_');
                    if (idx > 0)
                    {
                        desc = rest.Substring(0, idx);
                        var ts = rest.Substring(idx + 1);
                        if (DateTime.TryParseExact(ts, "yyyyMMdd_HHmmss",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.AssumeUniversal, out var dt))
                        {
                            created = dt;
                        }
                    }
                }

                // 3) Insertar en BD
                var id = Guid.NewGuid();
                const string sqlIns = @"
            INSERT INTO dbo.Backups
              (Id, Description, CreatedAt, FilePath, PerformedBy, MachineName)
            VALUES
              (@Id,@Desc,@CreatedAt,@Path,@User,@Machine);";
                ExecuteNonQuery(_connectionString, sqlIns, cmd =>
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Desc", desc);
                    cmd.Parameters.AddWithValue("@CreatedAt", created);
                    cmd.Parameters.AddWithValue("@Path", path);
                    cmd.Parameters.AddWithValue("@User", Environment.UserName);
                    cmd.Parameters.AddWithValue("@Machine", Environment.MachineName);
                });

                // 4) Sólo añadir al CSV si no estaba ya
                var fileName = Path.GetFileName(path);
                if (!existentesEnCsv.Contains(fileName))
                {
                    var line = string.Join(",",
                        id,
                        EscapeCsv(desc),
                        created.ToString("o"),
                        fileName,
                        Environment.UserName,
                        Environment.MachineName);

                    lock (_csvLock)
                    {
                        File.AppendAllText(_csvPath, line + "\r\n");
                    }
                    existentesEnCsv.Add(fileName);
                }
            }
        }


        private void ExecuteNonQuery(string conn, string sql, Action<SqlCommand> map, int to = 30)
        {
            using (var c = new SqlConnection(conn))
            using (var cmd = new SqlCommand(sql, c))
            {
                c.Open();
                cmd.CommandTimeout = to;
                map?.Invoke(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        private void ExecuteReader(string conn, string sql, Action<SqlCommand> map, Action<SqlDataReader> read, int to = 30)
        {
            using (var c = new SqlConnection(conn))
            using (var cmd = new SqlCommand(sql, c))
            {
                c.Open();
                cmd.CommandTimeout = to;
                map?.Invoke(cmd);
                using (var r = cmd.ExecuteReader())
                    read(r);
            }
        }

        private string EscapeCsv(string s)
        {
            if (s.Contains(",") || s.Contains("\""))
                s = "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }

        private string UnescapeCsv(string s)
        {
            if (s.StartsWith("\"") && s.EndsWith("\""))
                s = s.Substring(1, s.Length - 2).Replace("\"\"", "\"");
            return s;
        }

        private string[] SplitCsvLine(string line)
        {
            // Divide por comas que no estén entre comillas
            var pattern = ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))";
            return Regex.Split(line, pattern);
        }
    }
}