using System.Collections.Generic;
namespace INTERFACES
{
    /// <summary>
    /// Contrato genérico para quienes calculan y guardan DVH/DVV en T.
    /// </summary>
    public interface IDigitVerifier<T> : IDigitVerifierBase
        where T : IDigitVerificable
    {
        string ComputeDVH(T entity);
        string ComputeDVV(IEnumerable<T> entities);
        void GuardarDVH(T entity, string dvh);
        string ObtenerDVHActual(T entity);
        void GuardarDVV(string dvv);
        string ObtenerDVV();
    }

}