using System;

namespace INTERFACES
{
    /// <summary>
    /// Contrato para clases de negocio que puedan revertir el valor de una propiedad de una entidad.
    /// </summary>
    public interface IRevertible
    {
        /// <summary>
        /// Restaura la propiedad indicada de la entidad con Id al valorAnterior.
        /// </summary>
        /// <param name="id">
        /// Identificador único de la entidad (por ejemplo TicketId, ClienteId, etc.).
        /// </param>
        /// <param name="propiedad">
        /// Nombre de la propiedad a revertir (debe coincidir con la propiedad en la clase BE).
        /// </param>
        /// <param name="valorAnterior">
        /// Valor, en formato string, al que se desea restaurar la propiedad.
        /// </param>
        void RevertirPropiedad(Guid id, string propiedad, string valorAnterior);
    }
}
