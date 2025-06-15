using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BitacoraBLL
    {
        private readonly BitacoraDAL _dal;

        public event Action EntradaRegistrada;

        public BitacoraBLL()
        {
            _dal = new BitacoraDAL();
        }

        public IList<Bitacora> ObtenerEntradas(
            DateTime? desde = null,
            DateTime? hasta = null,
            Guid? usuarioId = null,
            string clase = null,
            string accion = null)
        {
            return _dal.ObtenerEntradas(desde, hasta, usuarioId, clase, accion);
        }

        public bool RegistrarEntrada(
            Guid usuarioId,
            string usuarioNombre,
            string clase,
            string accion,
            string infoAdicional = null)
        {
            var e = new Bitacora
            {
                Id = Guid.NewGuid(),
                FechaHora = DateTime.Now,
                UsuarioId = usuarioId,
                UsuarioNombre = usuarioNombre,
                Clase = clase,
                Accion = accion,
                InfoAdicional = infoAdicional
            };

            var ok = _dal.AgregarEntrada(e);
            if (ok) EntradaRegistrada?.Invoke();
            return ok;
        }
    }
}