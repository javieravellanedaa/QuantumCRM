using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;      // Para usar reflection en RevertirPropiedad
using BE;
using DAL;
using INTERFACES;             // Para IRevertible
using BLL.DigitVerifier;      // Para TicketVerifierService

namespace BLL
{
    // Implementa IRevertible
    public class TicketBLL : IRevertible
    {
        private readonly TicketDAL _ticketDAL;
        private readonly CategoriaBLL _categoriaBLL;
        private readonly PrioridadBLL _prioridadBLL;
        private readonly EstadoTicketBLL _estadoTicketBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly GrupoTecnicoBLL _grupoTecnicoBLL;
        private readonly TecnicoBLL _tecnicoBLL;
        private readonly ComentarioBLL _comentarioBLL;
        private readonly TicketHistoricoDAL _historicoDAL;
        private readonly ControlDeCambiosBLL _controlDeCambiosBLL;

        public TicketBLL()
        {
            _ticketDAL = new TicketDAL();
            _categoriaBLL = new CategoriaBLL();
            _prioridadBLL = new PrioridadBLL();
            _estadoTicketBLL = new EstadoTicketBLL();
            _clienteBLL = new ClienteBLL();
            _grupoTecnicoBLL = new GrupoTecnicoBLL();
            _tecnicoBLL = new TecnicoBLL();
            _comentarioBLL = new ComentarioBLL();
            _historicoDAL = new TicketHistoricoDAL();
            _controlDeCambiosBLL = new ControlDeCambiosBLL();
        }

        public void CrearTicket(Ticket ticket)
        {
            // 1. Validaciones básicas
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(ticket.Asunto))
                throw new ArgumentException("El asunto del ticket no puede estar vacío.", nameof(ticket.Asunto));
            if (string.IsNullOrWhiteSpace(ticket.Descripcion))
                throw new ArgumentException("La descripción del ticket no puede estar vacía.", nameof(ticket.Descripcion));

            // 2. Validar categoría existente
            var categoria = _categoriaBLL.ObtenerCategoriaPorId(ticket.CategoriaId)
                ?? throw new InvalidOperationException($"Categoría con Id {ticket.CategoriaId} no encontrada.");

            // 3. Determinar prioridad inicial
            var prioridadDefault = _prioridadBLL.ObtenerPrioridadCategoria(categoria);
            if (ticket.PrioridadId <= 0)
                ticket.PrioridadId = prioridadDefault.Id;

            // 4. Inicializar timestamps y flags
            var ahora = DateTime.Now;
            ticket.FechaCreacion = ahora;
            ticket.FechaUltimaModif = ahora;
            ticket.Eliminado = false;

            // 5. Estado y aprobador inicial
            if (categoria.AprobadorRequerido)
            {
                var est = _estadoTicketBLL.ObtenerPorNombre("En Aprobacion");
                ticket.EstadoId = est.EstadoId;
                ticket.UsuarioAprobador = categoria.ClienteAprobador;
            }
            else
            {
                var est = _estadoTicketBLL.ObtenerPorNombre("Derivado");
                ticket.EstadoId = est.EstadoId;
                ticket.UsuarioAprobadorId = null;
            }

            // 6. Persistir ticket
            _ticketDAL.GuardarTicket(ticket);
            _controlDeCambiosBLL.RegistrarCambios(null, ticket);

            // 7. Histórico de creación
            _historicoDAL.Insertar(new TicketHistorico
            {
                TicketId = ticket.TicketId,
                FechaCambio = ahora,
                UsuarioCambioId = _clienteBLL.ObtenerIdUsuarioPorClienteId(ticket.ClienteCreadorId),
                TipoEvento = "Creación",
                Comentario = "Ticket creado"
            });

            // 8. Histórico de estado inicial
            _historicoDAL.Insertar(new TicketHistorico
            {
                TicketId = ticket.TicketId,
                FechaCambio = ahora,
                UsuarioCambioId = _clienteBLL.ObtenerIdUsuarioPorClienteId(ticket.ClienteCreadorId),
                TipoEvento = "Estado",
                ValorAnteriorId = null,
                ValorNuevoId = ticket.EstadoId,
                Comentario = categoria.AprobadorRequerido
                                  ? "Enviado a aprobación"
                                  : "Apertura automática"
            });

            // 9. Histórico de grupo técnico inicial (si aplica)
            if (ticket.GrupoTecnicoId.HasValue)
            {
                _historicoDAL.Insertar(new TicketHistorico
                {
                    TicketId = ticket.TicketId,
                    FechaCambio = ahora,
                    UsuarioCambioId = _clienteBLL.ObtenerIdUsuarioPorClienteId(ticket.ClienteCreadorId),
                    TipoEvento = "Grupo",
                    ValorAnteriorId = null,
                    ValorNuevoId = ticket.GrupoTecnicoId,
                    Comentario = "Asignado automáticamente según categoría"
                });
            }

            // 10. Histórico de override de prioridad
            if (ticket.PrioridadId != prioridadDefault.Id)
            {
                var prim = _prioridadBLL.ObtenerPrioridadPorId(ticket.PrioridadId);
                var nombreOverride = prim?.Nombre ?? $"Id {ticket.PrioridadId}";
                _historicoDAL.Insertar(new TicketHistorico
                {
                    TicketId = ticket.TicketId,
                    FechaCambio = ahora,
                    UsuarioCambioId = _clienteBLL.ObtenerIdUsuarioPorClienteId(ticket.ClienteCreadorId),
                    TipoEvento = "Prioridad",
                    ValorAnteriorId = prioridadDefault.Id,
                    ValorNuevoId = ticket.PrioridadId,
                    Comentario = $"Prioridad por defecto ({prioridadDefault.Nombre}) cambiada a {nombreOverride}"
                });
            }

            // 11. Recalcular integridad para este ticket y DVV global
            new TicketVerifierService().RecalcularSingleDV(ticket.TicketId);
        }

        public Ticket ObtenerTicketPorId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.", nameof(id));

            var ticket = _ticketDAL.ObtenerTicketPorId(id)
                         ?? throw new InvalidOperationException($"Ticket con Id {id} no encontrado.");

            if (ticket.Eliminado)
                throw new InvalidOperationException($"El ticket con Id {id} ha sido eliminado.");

            // Carga de relaciones
            ticket.ClienteCreador = _clienteBLL.ObtenerClientePorId(ticket.ClienteCreadorId);
            ticket.Categoria = _categoriaBLL.ObtenerCategoriaPorId(ticket.CategoriaId);
            ticket.Prioridad = _prioridadBLL.ObtenerPrioridadPorId(ticket.PrioridadId);
            ticket.Estado = _estadoTicketBLL.ObtenerEstadoTicket(ticket.EstadoId);

            if (ticket.UsuarioAprobadorId.HasValue)
                ticket.UsuarioAprobador = _clienteBLL.ObtenerClientePorId(ticket.UsuarioAprobadorId.Value);
            if (ticket.GrupoTecnicoId.HasValue)
                ticket.GrupoTecnico = _grupoTecnicoBLL.ObtenerGrupoPorId(ticket.GrupoTecnicoId.Value);
            if (ticket.TecnicoId.HasValue)
                ticket.TecnicoAsignado = _tecnicoBLL.ObtenerTecnicoPorId(ticket.TecnicoId.Value);

            ticket.Comentarios = _comentarioBLL.ListarComentariosPorTicket(ticket.TicketId);
            // ticket.Historicos = _historicoDAL.ListarHistoricos(ticket.TicketId);

            return ticket;
        }

        public void ActualizarTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            if (ticket.TicketId == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.", nameof(ticket.TicketId));
            if (string.IsNullOrWhiteSpace(ticket.Asunto))
                throw new ArgumentException("El asunto del ticket no puede ser vacío.", nameof(ticket.Asunto));
            if (string.IsNullOrWhiteSpace(ticket.Descripcion))
                throw new ArgumentException("La descripción del ticket no puede ser nula.", nameof(ticket.Descripcion));

            // 1) Obtenemos el estado previo
            var ticketAnterior = ObtenerTicketPorId(ticket.TicketId);

            // 2) Cargamos el existente para modificarlo
            var existente = ObtenerTicketPorId(ticket.TicketId);
            const int estadoCanceladoId = 7;

            // Mismo manejo de cancelación…
            if (ticket.EstadoId == estadoCanceladoId)
            {
                existente.EstadoId = estadoCanceladoId;
                existente.FechaCierre = DateTime.Now;
                existente.FechaUltimaModif = DateTime.Now;
                _ticketDAL.ActualizarTicket(existente);
                new TicketVerifierService().RecalcularSingleDV(ticket.TicketId);
                return;
            }

            // Cambio de prioridad (igual que antes)…

            // 3) Campos editables
            existente.Asunto = ticket.Asunto;
            existente.Descripcion = ticket.Descripcion;
            existente.CategoriaId = ticket.CategoriaId;
            existente.TecnicoId = ticket.TecnicoId;
            existente.FechaUltimaModif = DateTime.Now;
            existente.PrioridadId = ticket.PrioridadId;

            // **Primero** asignamos el estado que viene del UI
            existente.EstadoId = ticket.EstadoId;
            existente.UsuarioAprobadorId = ticketAnterior.UsuarioAprobadorId;
            // (mantenemos el aprobador previo a menos que lo necesitemos recalcular)

            // 4) Sólo si realmente cambié de una categoría NO requiere-aprobación
            //    a una que SÍ la requiere, lo forzamos a "En aprobación"
            var catAnterior = _categoriaBLL.ObtenerCategoriaPorId(ticketAnterior.CategoriaId);
            var catNueva = _categoriaBLL.ObtenerCategoriaPorId(ticket.CategoriaId);
            if (catNueva.AprobadorRequerido && !catAnterior.AprobadorRequerido)
            {
                var et = _estadoTicketBLL.ObtenerPorNombre("En aprobacion");
                existente.EstadoId = et.EstadoId;
                existente.UsuarioAprobadorId = catNueva.ClienteAprobador.ClienteId;
            }

            // 5) Persistimos cambios
            _ticketDAL.ActualizarTicket(existente);
            _controlDeCambiosBLL.RegistrarCambios(ticketAnterior, existente);
            new TicketVerifierService().RecalcularSingleDV(ticket.TicketId);
        }


        public void EliminarTicket(Ticket ticket, Usuario usuario)
        {
            if (ticket == null || usuario == null)
                throw new ArgumentNullException("Ticket o usuario nulo.");
            if (ticket.Eliminado)
                throw new InvalidOperationException($"El ticket {ticket.TicketId} ya está eliminado.");
            if (ticket.FechaCierre.HasValue)
                throw new InvalidOperationException("No se puede eliminar un ticket ya cerrado.");

            var ahora = DateTime.Now;
            ticket.Eliminado = true;
            ticket.FechaUltimaModif = ahora;
            _ticketDAL.ActualizarTicket(ticket);
            _historicoDAL.Insertar(new TicketHistorico
            {
                TicketId = ticket.TicketId,
                FechaCambio = ahora,
                UsuarioCambioId = usuario.Id,
                TipoEvento = "Eliminación",
                ValorAnteriorId = 0,
                ValorNuevoId = null,
                Comentario = "Ticket marcado como eliminado"
            });

            // Recalcular integridad
            new TicketVerifierService().RecalcularSingleDV(ticket.TicketId);
        }


        /// <summary>
        /// Obtiene todos los tickets pendientes de aprobación para un usuario aprobador.
        /// </summary>
        public List<Ticket> ListarTicketsPendientesDeAprobacion(int usuarioAprobadorId)
        {
            // 1) Obtener el estado "En Aprobacion"
            var estadoEnAprobacion = _estadoTicketBLL.ObtenerPorNombre("En Aprobacion")
                ?? throw new InvalidOperationException("Estado 'En Aprobacion' no encontrado.");

            // 2) Llamar al DAL
            return _ticketDAL.ListarTicketsParaAprobacion(usuarioAprobadorId, estadoEnAprobacion.EstadoId);
        }

        /// <summary>
        /// Aprueba (deriva) un ticket que está en estado "En Aprobacion".
        /// </summary>
        public void AprobarTicket(Guid ticketId, int usuarioAprobadorId)
        {
            var ticket = ObtenerTicketPorId(ticketId);

            if (ticket.Estado.Nombre != "En Aprobacion")
                throw new InvalidOperationException("Solo se pueden aprobar tickets en estado 'En Aprobacion'.");

            var estadoDerivado = _estadoTicketBLL.ObtenerPorNombre("Derivado")
                ?? throw new InvalidOperationException("Estado 'Derivado' no encontrado.");

            int anterior = ticket.EstadoId;
            ticket.EstadoId = estadoDerivado.EstadoId;
            ticket.FechaUltimaModif = DateTime.Now;

            // Persistir cambio de estado
            _ticketDAL.ActualizarTicket(ticket);
            var UsuarioCambio = _clienteBLL.ObtenerIdUsuarioPorClienteId(usuarioAprobadorId);

            // Registrar en histórico
            _historicoDAL.Insertar(new TicketHistorico
            {

                TicketId = ticketId,
                FechaCambio = DateTime.Now,
                UsuarioCambioId = UsuarioCambio,
                TipoEvento = "Aprobación",
                ValorAnteriorId = anterior,
                ValorNuevoId = estadoDerivado.EstadoId,
                Comentario = "Ticket aprobado y derivado"
            });

            // Control de cambios y dígito verificable
            _controlDeCambiosBLL.RegistrarCambios(
                new Ticket { TicketId = ticketId, EstadoId = anterior },
                ticket
            );
            new TicketVerifierService().RecalcularSingleDV(ticketId);
        }

        /// <summary>
        /// Rechaza (cancela) un ticket que está en estado "En Aprobacion".
        /// </summary>
        public void RechazarTicket(Guid ticketId, int usuarioAprobadorId)
        {
            var ticket = ObtenerTicketPorId(ticketId);

            if (ticket.Estado.Nombre != "En Aprobacion")
                throw new InvalidOperationException("Solo se pueden rechazar tickets en estado 'En Aprobacion'.");

            var estadoCancelado = _estadoTicketBLL.ObtenerPorNombre("Cancelado")
                ?? throw new InvalidOperationException("Estado 'Cancelado' no encontrado.");

            int anterior = ticket.EstadoId;
            ticket.EstadoId = estadoCancelado.EstadoId;
            ticket.FechaUltimaModif = DateTime.Now;
            ticket.FechaCierre = DateTime.Now;

            _ticketDAL.ActualizarTicket(ticket);

            _historicoDAL.Insertar(new TicketHistorico
            {
                TicketId = ticketId,
                FechaCambio = DateTime.Now,
                UsuarioCambioId = _clienteBLL.ObtenerIdUsuarioPorClienteId(usuarioAprobadorId),
                TipoEvento = "Cancelación",
                ValorAnteriorId = anterior,
                ValorNuevoId = estadoCancelado.EstadoId,
                Comentario = "Ticket rechazado y cancelado"
            });

            _controlDeCambiosBLL.RegistrarCambios(
                new Ticket { TicketId = ticketId, EstadoId = anterior },
                ticket
            );
            new TicketVerifierService().RecalcularSingleDV(ticketId);
        }

        public List<Ticket> ListarTicketsDeCliente(Cliente cliente)
        {
            if (cliente.ClienteId <= 0)
                throw new ArgumentException("El ID del cliente no puede ser vacío.", nameof(cliente));

            // ← Aquí corregimos el uso de la propiedad
            var lista = _ticketDAL.ListarTicketsDeCliente(cliente.ClienteId);
            return lista.Where(t => !t.Eliminado).ToList();
        }

        public List<Ticket> ListarTicketsPorGrupo(int grupoId)
        {
            if (grupoId <= 0) throw new ArgumentException("ID de grupo inválido", nameof(grupoId));
            return _ticketDAL.ListarTicketsPorGrupoTecnico(grupoId);
        }


        public List<Ticket> ListarTicketsDelDepartamento(int departamentoId)
        {
            if (departamentoId <= 0)
                throw new ArgumentException("ID de departamento inválido.", nameof(departamentoId));
            var list = _ticketDAL.ListarTicketsDelDepartamento(departamentoId);
            return list.Where(t => !t.Eliminado).ToList();
        }

        public void RevertirPropiedad(Guid id, string propiedad, string valorAnterior)
        {
            var ticket = ObtenerTicketPorId(id);
            var propInfo = typeof(Ticket)
                .GetProperty(propiedad, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                ?? throw new InvalidOperationException($"Propiedad '{propiedad}' no existe.");

            var valTyped = Convert.ChangeType(valorAnterior, propInfo.PropertyType);
            propInfo.SetValue(ticket, valTyped);
            ActualizarTicket(ticket);

            // Recalcular integridad
            new TicketVerifierService().RecalcularSingleDV(ticket.TicketId);
        }
    }
}
