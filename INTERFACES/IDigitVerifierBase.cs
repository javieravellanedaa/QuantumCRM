using INTERFACES;

namespace INTERFACES
{
    /// <summary>
    /// Contrato base para los servicios de verificación de integridad.
    /// Permite orquestar sin conocer el tipo genérico.
    /// </summary>
    public interface IDigitVerifierBase
    {
        /// <summary>Nombre lógico de la entidad o tabla (ej. "Usuario").</summary>
        string Tabla { get; }

        /// <summary>
        /// Verifica DVH y DVV de todos los registros, devolviendo errores si los hay.
        /// </summary>
        IntegrityResult VerifyIntegrity();

        /// <summary>
        /// Recalcula y persiste tanto los DVH como el DVV para la entidad completa.
        /// </summary>
        void RecalcularDV();
    }
}
