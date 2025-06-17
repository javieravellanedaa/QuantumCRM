using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL;
using INTERFACES;
using BLL.DigitVerifier;

namespace BLL.DigitVerifier
{
    /// <summary>
    /// Servicio de verificación de integridad (DVH/DVV) para la entidad Usuario.
    /// </summary>
    public class UsuarioVerifierService : IDigitVerifier<Usuario>
    {
        private readonly UsuarioDAL _dal = new UsuarioDAL();
        private readonly DigitoVerificadorVDAL _dvvDal = new DigitoVerificadorVDAL();
        private readonly DigitVerifier<Usuario> _calc = new DigitVerifier<Usuario>();

        /// <inheritdoc/>
        public string Tabla => "Usuario";

        /// <inheritdoc/>
        public string ComputeDVH(Usuario e) => _calc.ComputeDVH(e);

        /// <inheritdoc/>
        public string ComputeDVV(IEnumerable<Usuario> list) => _calc.ComputeDVV(list);

        /// <inheritdoc/>
        public void GuardarDVH(Usuario e, string dvh)
        {
            e.DigitoVerificadorH = dvh;
            _dal.ActualizarDVH(e);
        }

        /// <inheritdoc/>
        public string ObtenerDVHActual(Usuario e) => e.DigitoVerificadorH;

        /// <inheritdoc/>
        public void GuardarDVV(string dvv) => _dvvDal.ActualizarDVV(Tabla, dvv);

        /// <inheritdoc/>
        public string ObtenerDVV() => _dvvDal.ObtenerDVV(Tabla);

        /// <inheritdoc/>
        public IntegrityResult VerifyIntegrity()
        {
            var res = new IntegrityResult();
            var all = _dal.ObtenerTodos();  // Debe devolver Usuarios con DigitoVerificadorH cargado

            // Verifica DVH de cada usuario
            foreach (var u in all)
            {
                var dvhCalc = ComputeDVH(u);
                if (u.DigitoVerificadorH != dvhCalc)
                {
                    res.Result = false;
                    res.DHErrors.Add(new IntegrityError($"DVH inválido para Usuario ID {u.Id}"));
                }
            }

            // Verifica DVV global
            var dvvCalc = ComputeDVV(all);
            if (dvvCalc != ObtenerDVV())
            {
                res.Result = false;
                res.DVErrors.Add(new IntegrityError("DVV inválido para tabla Usuario"));
            }

            return res;
        }

        /// <inheritdoc/>
        public void RecalcularDV()
        {
            var all = _dal.ObtenerTodos();

            // Recalcula y persiste DVH de cada usuario
            foreach (var u in all)
            {
                var dvh = ComputeDVH(u);
                u.DigitoVerificadorH = dvh;
                GuardarDVH(u, dvh);
            }

            // Recalcula y persiste DVV global
            var newDvv = ComputeDVV(all);
            GuardarDVV(newDvv);
        }

        /// <summary>
        /// Recalcula solo el DVH de un usuario (por Guid Id) y luego el DVV global.
        /// </summary>
        public void RecalcularSingleDV(Guid id)
        {
            var usuario = _dal.ObtenerUsuarioPorId(id);
            if (usuario == null) return;

            // Recalcula su DVH
            var dvh = ComputeDVH(usuario);
            usuario.DigitoVerificadorH = dvh;
            GuardarDVH(usuario, dvh);

            // Luego recalcula DVV para toda la tabla
            var all = _dal.ObtenerTodos();
            var dvv = ComputeDVV(all);
            GuardarDVV(dvv);
        }
    }
}
