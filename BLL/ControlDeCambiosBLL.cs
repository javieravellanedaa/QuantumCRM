using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BE;
using DAL;
using SERVICIOS;
using INTERFACES;  // ← Para IRevertible

namespace BLL
{
    public class ControlDeCambiosBLL
    {
        private readonly ControlDeCambiosDAL _controlDeCambiosDAL;
        private readonly Guid _usuarioActualId;

        public ControlDeCambiosBLL()
        {
            _controlDeCambiosDAL = new ControlDeCambiosDAL();
            _usuarioActualId = SingletonSesion.Instancia.Sesion.IsLogged()
                ? SingletonSesion.Instancia.Sesion.Usuario.Id
                : Guid.Empty;
        }

        #region ► Grabación de cambios

        public void RegistrarCambios<T>(T anterior, T actual)
            where T : class
        {
            var tipo = typeof(T);
            string tabla = tipo.Name;

            // Detectar clave: Propiedad "Id" o "{Tabla}Id"
            var idProp = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase)
                                  || string.Equals(p.Name, tabla + "Id", StringComparison.OrdinalIgnoreCase));

            // Obtener valor de la clave
            Guid entityId = Guid.Empty;
            if (idProp != null)
            {
                var holder = actual ?? anterior;
                var keyVal = idProp.GetValue(holder);
                if (keyVal is Guid g)
                    entityId = g;
            }

            // Todas las propiedades excepto la clave
            var props = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite
                            && !string.Equals(p.Name, idProp?.Name, StringComparison.OrdinalIgnoreCase));

            // Comparar y guardar
            foreach (var prop in props)
            {
                string viejo = anterior == null ? null : SerializeValue(prop.GetValue(anterior));
                string nuevo = actual == null ? null : SerializeValue(prop.GetValue(actual));
                if (string.Equals(viejo, nuevo, StringComparison.Ordinal))
                    continue;

                var entry = new ControlDeCambios
                {
                    Tabla = tabla,
                    EntityId = entityId,
                    Propiedad = prop.Name,
                    ValorViejo = viejo,
                    ValorNuevo = nuevo,
                    CambiadoPor = _usuarioActualId,
                    FechaCambio = DateTime.UtcNow,
                    TipoOperacion = anterior == null
                                        ? TipoDeOperacion.Insert
                                        : actual == null
                                            ? TipoDeOperacion.Delete
                                            : TipoDeOperacion.Update
                };
                _controlDeCambiosDAL.Guardar(entry);
            }
        }

        private string SerializeValue(object value)
        {
            if (value == null)
                return null;

            var type = value.GetType();

            // Tipos simples
            if (IsSimple(type))
                return value.ToString();

            // Colección (IEnumerable) excepto string
            if (value is IEnumerable enumerable)
            {
                var items = new List<string>();
                foreach (var item in enumerable)
                    items.Add(SerializeValue(item));
                return "[" + string.Join(",", items) + "]";
            }

            // Objeto complejo: serializar propiedades simples
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && IsSimple(p.PropertyType));

            var kv = props.Select(p =>
            {
                var v = p.GetValue(value);
                var s = v == null
                    ? "null"
                    : v.ToString().Replace("\\", "\\\\").Replace("\"", "\\\"");
                return $"\"{p.Name}\":\"{s}\"";
            });

            return "{" + string.Join(",", kv) + "}";
        }

        private bool IsSimple(Type type)
        {
            return type.IsPrimitive
                || type.IsEnum
                || type == typeof(string)
                || type == typeof(decimal)
                || type == typeof(DateTime)
                || type == typeof(DateTimeOffset)
                || type == typeof(Guid)
                || type == typeof(bool);
        }

        #endregion

        #region ► Consultas de historial

        public IEnumerable<string> ListarTablas()
            => _controlDeCambiosDAL.ObtenerTablas();

        public IEnumerable<ControlDeCambios> ListarCambios(
            string tabla = null,
            Guid? entityId = null,
            DateTime? desde = null,
            DateTime? hasta = null)
        {
            var query = _controlDeCambiosDAL.ObtenerTodos().AsQueryable();
            if (!string.IsNullOrEmpty(tabla))
                query = query.Where(e => e.Tabla == tabla);
            if (entityId.HasValue)
                query = query.Where(e => e.EntityId == entityId.Value);
            if (desde.HasValue)
                query = query.Where(e => e.FechaCambio >= desde.Value);
            if (hasta.HasValue)
                query = query.Where(e => e.FechaCambio <= hasta.Value);
            return query.OrderByDescending(e => e.FechaCambio).ToList();
        }

        #endregion

        #region ► Reconstrucción histórica

        public T ReconstruirHasta<T>(Guid entityId, DateTime fechaHasta, Func<Guid, T> loader)
            where T : class, new()
        {
            string tabla = typeof(T).Name;
            var cambios = _controlDeCambiosDAL.ObtenerHasta(fechaHasta)
                .Where(e => e.Tabla == tabla && e.EntityId == entityId)
                .OrderBy(e => e.FechaCambio)
                .ToList();

            var instancia = loader(entityId) ?? new T();

            // Detectar clave
            var tipo = typeof(T);
            var idProp = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase)
                                  || string.Equals(p.Name, tabla + "Id", StringComparison.OrdinalIgnoreCase));

            foreach (var c in cambios)
            {
                if (c.TipoOperacion == TipoDeOperacion.Delete)
                {
                    instancia = new T();
                    continue;
                }

                var prop = tipo.GetProperty(c.Propiedad);
                if (prop == null || !prop.CanWrite)
                    continue;

                object valor = c.ValorNuevo;
                var dstType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                if (dstType.IsEnum)
                    valor = Enum.Parse(dstType, c.ValorNuevo);
                else if (dstType != typeof(string))
                    valor = Convert.ChangeType(c.ValorNuevo, dstType);

                prop.SetValue(instancia, valor);
            }

            if (idProp != null && idProp.CanWrite)
                idProp.SetValue(instancia, entityId);

            return instancia;
        }

        #endregion

        #region ► Reversión de cambios

        /// <summary>
        /// Revertir un cambio para la fila seleccionada:
        /// despacha a IRevertible si existe BLL, o hace UPDATE directo en DAL.
        /// </summary>
        public void RevertirCambio(string tabla, Guid entityId, string propiedad, string valorAnterior)
        {
            if (string.IsNullOrWhiteSpace(tabla))
                throw new ArgumentException("La tabla es requerida.", nameof(tabla));
            if (entityId == Guid.Empty)
                throw new ArgumentException("EntityId no válido.", nameof(entityId));
            if (string.IsNullOrWhiteSpace(propiedad))
                throw new ArgumentException("La propiedad es requerida.", nameof(propiedad));

            switch (tabla)
            {
                case "Ticket":
                    IRevertible ticketBll = new TicketBLL();
                    ticketBll.RevertirPropiedad(entityId, propiedad, valorAnterior);
                    break;

                // case "OtraEntidad":
                //     IRevertible otraBll = new OtraEntidadBLL();
                //     otraBll.RevertirPropiedad(entityId, propiedad, valorAnterior);
                //     break;

                default:
                    // Fallback: actualización directa en la tabla
                    _controlDeCambiosDAL.RevertirCambio(tabla, entityId, propiedad, valorAnterior);
                    break;
            }
        }

        #endregion
    }
}
