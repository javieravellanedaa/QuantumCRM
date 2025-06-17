using System;
using BLL.DigitVerifier;

namespace BLL.DigitVerifier
{
    public class DigitVerifierStartupService
    {
        private readonly DigitVerifierManager _manager;

        public DigitVerifierStartupService()
        {
            _manager = new DigitVerifierManager();
        }

        public void RecalcularDVsIniciales()
        {
            try
            {
                _manager.RecalcularDV();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recalcular los dígitos verificadores.", ex);
            }
        }
    }
}
