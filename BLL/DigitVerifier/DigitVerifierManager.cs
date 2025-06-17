using System.Collections.Generic;
using System.Linq;
using INTERFACES;

namespace BLL.DigitVerifier
{
    public class DigitVerifierManager
    {
        private readonly List<IDigitVerifierBase> _verifiers;

        public DigitVerifierManager()
        {
            _verifiers = new List<IDigitVerifierBase>
            {
                new UsuarioVerifierService(),
                new TicketVerifierService()
            };
        }

        public IntegrityResume VerifyIntegrity()
        {
            var resume = new IntegrityResume();
            foreach (var v in _verifiers)
            {
                var r = v.VerifyIntegrity();
                if (!r.Result)
                {
                    resume.Result = false;
                    resume.DVHErrors.AddRange(r.DHErrors);
                    resume.DVVErrors.AddRange(r.DVErrors);
                    resume.DVTables.Add(v.Tabla);
                }
            }
            return resume;
        }

        public void RecalcularDV()
        {
            foreach (var v in _verifiers)
                v.RecalcularDV();
        }

        public void RecalcularDVDeTabla(string tabla)
        {
            var match = _verifiers.FirstOrDefault(v => v.Tabla == tabla);
            match?.RecalcularDV();
        }
    }
}
