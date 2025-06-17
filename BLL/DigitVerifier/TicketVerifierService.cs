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
    /// Servicio de verificación de integridad (DVH/DVV) para la entidad Ticket.
    /// </summary>
    public class TicketVerifierService : IDigitVerifier<Ticket>
    {
        private readonly TicketDAL _dal = new TicketDAL();
        private readonly DigitoVerificadorVDAL _dvvDal = new DigitoVerificadorVDAL();
        private readonly DigitVerifier<Ticket> _calc = new DigitVerifier<Ticket>();

        /// <inheritdoc/>
        public string Tabla => "Ticket";

        /// <inheritdoc/>
        public string ComputeDVH(Ticket e) => _calc.ComputeDVH(e);

        /// <inheritdoc/>
        public string ComputeDVV(IEnumerable<Ticket> list) => _calc.ComputeDVV(list);

        /// <inheritdoc/>
        public void GuardarDVH(Ticket e, string dvh) => _dal.ActualizarDVH(e.TicketId, dvh);

        /// <inheritdoc/>
        public string ObtenerDVHActual(Ticket e) => e.DigitoVerificadorH;

        /// <inheritdoc/>
        public void GuardarDVV(string dvv) => _dvvDal.ActualizarDVV(Tabla, dvv);

        /// <inheritdoc/>
        public string ObtenerDVV() => _dvvDal.ObtenerDVV(Tabla);

        /// <inheritdoc/>
        public IntegrityResult VerifyIntegrity()
        {
            var res = new IntegrityResult();
            var all = _dal.ListarTodos();

            // Verifica DVH de cada ticket
            foreach (var t in all)
            {
                var dvhCalc = ComputeDVH(t);
                if (t.DigitoVerificadorH != dvhCalc)
                {
                    res.Result = false;
                    res.DHErrors.Add(new IntegrityError($"DVH incorrecto para Ticket {t.TicketId}"));
                }
            }

            // Verifica DVV global
            var dvvCalc = ComputeDVV(all);
            if (dvvCalc != ObtenerDVV())
            {
                res.Result = false;
                res.DVErrors.Add(new IntegrityError("DVV incorrecto para tabla Ticket"));
            }

            return res;
        }

        /// <inheritdoc/>
        public void RecalcularDV()
        {
            var all = _dal.ListarTodos();

            // Recalcula y persiste DVH de cada ticket
            foreach (var t in all)
            {
                var dvh = ComputeDVH(t);
                t.DigitoVerificadorH = dvh;
                GuardarDVH(t, dvh);
            }

            // Recalcula y persiste DVV global
            var newDvv = ComputeDVV(all);
            GuardarDVV(newDvv);
        }

        /// <summary>
        /// Recalcula solo el DVH de un ticket específico y luego el DVV global.
        /// </summary>
        public void RecalcularSingleDV(Guid ticketId)
        {
            // 1) Recalcula DVH del ticket modificado
            var ticket = _dal.ObtenerTicketPorId(ticketId);
            if (ticket != null)
            {
                var dvh = ComputeDVH(ticket);
                ticket.DigitoVerificadorH = dvh;
                GuardarDVH(ticket, dvh);
            }

            // 2) Recalcula DVV de toda la tabla
            var all = _dal.ListarTodos();
            var dvv = ComputeDVV(all);
            GuardarDVV(dvv);
        }
    }
}
