using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using INTERFACES;
using System.Runtime.Remoting.Messaging;
using BE.Composite;


namespace DAL
{

    public class UsuarioDAL : AbstractDAL<Usuario>
    {

        Acceso acceso;
        bool accesopropio;



        private void Abrir()
        {

            if (accesopropio)
            {

                acceso.Abrir();
            }

        }

        private void IniciarTx()
        {

            if (accesopropio)
            {

                acceso.ComenzarTransaccion();
            }

        }

        private void FinalizarTx(int i)
        {

            if (accesopropio)
            {

                if (i >= 0) { acceso.ConfirmarTransaccion(); } else { acceso.CancelarTransaccion(); }
            }

        }

        private void Cerrar()
        {

            if (accesopropio)
            {

                acceso.Cerrar();
            }

        }

        public UsuarioDAL()
        {

            accesopropio = true;
            acceso = new Acceso();

            //CrearUsuarioDePrueba();

        }

        internal UsuarioDAL(Acceso ac)
        {

            acceso = ac;
            accesopropio = false;
        }



        public List<Usuario> GetAll()
        {
            Abrir();
            IniciarTx();
            DataTable tabla = acceso.Leer("usuarios_listar");


            var lista = new List<Usuario>();


            foreach (DataRow registro in tabla.Rows)
            {
                Usuario c = new Usuario();
                c.Id = Guid.Parse(registro["id_usuario"].ToString());
                c.Nombre = registro["nombre"].ToString();
                lista.Add(c);
            }
            // FinalizarTx(1);
            Cerrar();
            return lista;

        } // funciona pero hay redundacia en el metodo con el ICRUD

        private void CrearUsuarioDePrueba()
        {
            string mail = "gestor@gmail.com";

            SqlParameter parametro = new SqlParameter("@Email", mail);
            Abrir();
            IniciarTx();

            int count = acceso.Escribir("crea_usuario_default", new List<SqlParameter> { parametro });
            // FinalizarTx(1);
            if (count == 0)
            {

                // Crear el usuario de prueba
                Save(new Usuario { Email = mail, Password = "123", Nombre = "Javier", Apellido = "Gomez" });

            }

        }

        public override void Save(BE.Usuario entity)
        {

            Abrir();
            IniciarTx();
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", entity.Id));
            parameters.Add(new SqlParameter("@Email", entity.Email));
            parameters.Add(new SqlParameter("@Password", Encriptador.Hash(entity.Password)));
            parameters.Add(new SqlParameter("@Nombre", entity.Nombre));
            parameters.Add(new SqlParameter("@Apellido", entity.Apellido));
            acceso.Escribir("sp_InsertarUsuario", parameters);
            Cerrar();

        }

        public Usuario Login(string email, string password)
        {
            Abrir(); 

            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@Email", email),
        new SqlParameter("@Password", Encriptador.Hash(password)) // aca usamos el encriptador
    };

            DataTable tabla = acceso.Leer("sp_LoginUsuario", parameters);

            // Verificar si la tabla tiene al menos una fila
            if (tabla.Rows.Count > 0)
            {
                DataRow registro = tabla.Rows[0]; // Obtener la primera fila

                Usuario usuario = new Usuario
                { 
                    Id = Guid.Parse(registro["usuario_id"].ToString()),
                    Email = registro["email"].ToString(),
                    Password = registro["password"].ToString(),
                    Nombre = registro["nombre"].ToString(),
                    Apellido = registro["apellido"].ToString()
                };

                Cerrar(); 
                return usuario;
            }

            Cerrar(); 
            return null;
        }






        public void GuardarPermisos(Usuario u)
        {

            try
            {
                var cnn = new SqlConnection(@"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=CRM");
                cnn.Open();

                var cmd = new SqlCommand();
                cmd.Connection = cnn;

                cmd.CommandText = $@"delete from usuario_permisos where usuario_id=@id;";
                cmd.Parameters.Add(new SqlParameter("id", u.Id));
                cmd.ExecuteNonQuery();

                foreach (var item in u.Permisos)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;

                    cmd.CommandText = $@"insert into usuario_permisos (usuario_id,permiso_id) values (@id_usuario,@id_permiso) "; ;
                    cmd.Parameters.Add(new SqlParameter("id_usuario", u.Id));
                    cmd.Parameters.Add(new SqlParameter("id_permiso", item.Id));

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Patente> GetPermisos(Usuario user)
        {
            List<Patente> list = new List<Patente>();

            string con = @"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=CRM";
            using (SqlConnection cone = new SqlConnection(con))
            {
                string query = @"WITH recursivo AS (
                                SELECT pp.permiso_padre_id, pp.permiso_hijo_id
                                FROM permiso_permisos pp
                                WHERE pp.permiso_padre_id IN (
                                    SELECT up.permiso_id
                                    FROM usuario_permisos up
                                    WHERE up.usuario_id = @id_usuario
                                )
                                UNION ALL
                                SELECT pp.permiso_padre_id, pp.permiso_hijo_id
                                FROM permiso_permisos pp
                                INNER JOIN recursivo r ON r.permiso_hijo_id = pp.permiso_padre_id
                            )
                            SELECT DISTINCT p.permiso_id as id, p.nombre, p.descripcion
                            FROM recursivo r
                            INNER JOIN permisos p ON r.permiso_hijo_id = p.permiso_id
                            WHERE p.nombre IS NOT NULL;";
                SqlCommand cmd = new SqlCommand(query, cone);
                cmd.Parameters.AddWithValue("@id_usuario", user.Id);

                cone.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idp = reader.GetInt32(reader.GetOrdinal("id"));
                        string nombrep = reader.GetString(reader.GetOrdinal("nombre"));
                        string permisop = reader.GetString(reader.GetOrdinal("descripcion"));

                        Patente permiso = new Patente()

                        {
                            Id = idp,
                            Nombre = nombrep,
                            Permiso = permisop
                         };


                        list.Add(permiso);
                    }
                }
            }

            return list;
        }

        public List<Usuario> ListarUsuariosConTodosLosAtributos()
        {
            Abrir();
            IniciarTx();

            // Leer los usuarios desde la base de datos
            DataTable tabla = acceso.Leer("sp_ListarUsuariosConAtributos");

            var lista = new List<Usuario>();

            foreach (DataRow registro in tabla.Rows)
            {
                Usuario usuario = new Usuario
                {
                    Id = Guid.Parse(registro["usuario_id"].ToString()),
                    Email = registro["email"].ToString(),
                    Nombre = registro["nombre"].ToString(),
                    Apellido = registro["apellido"].ToString(),
                    Password = registro["password"].ToString(),
                    // Asigna el idioma si no es nulo
                    Idioma = registro.IsNull("idioma_id") ? null : new Idioma
                    {
                        Id = Guid.Parse(registro["idioma_id"].ToString()), // Se obtiene el ID del idioma
                        Nombre = registro["nombre_idioma"].ToString() // Se asume que se extrae también el nombre del idioma
                    }
                };

                // Obtener los permisos del usuario
                usuario.Permisos.AddRange(GetPermisos(usuario));

                lista.Add(usuario);
            }

            Cerrar();
            return lista;
        }




    }

}
           

