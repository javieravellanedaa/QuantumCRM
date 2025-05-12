using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL;

namespace BLL
{
    public class TicketBLL
    {
        private readonly TicketDAL _ticketDAL;
        private readonly CategoriaBLL _categoriaBLL;
        private readonly PrioridadBLL _prioridadBLL;
        private readonly TicketHistoricoDAL _historicoDAL;
        private readonly EstadoTicketBLL _estadoTicketBLL;

        public TicketBLL()
        {
            _ticketDAL = new TicketDAL();
            _categoriaBLL = new CategoriaBLL();
            _prioridadBLL = new PrioridadBLL();
            _historicoDAL = new TicketHistoricoDAL();
            _estadoTicketBLL = new EstadoTicketBLL();
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

            // 3. Determinar prioridad inicial: por defecto de la categoría o override desde la UI
            var prioridadDefault = _prioridadBLL.ObtenerPrioridadCategoria(categoria);
            if (ticket.PrioridadId <= 0)
            {
                // No vino override: asigno la prioridad por defecto de la categoría
                ticket.PrioridadId = prioridadDefault.Id;
            }
            // Si vino override (> 0), lo acepto tal cual (ya viene de la UI)

            // 4. Inicializar timestamps y flags
            var ahora = DateTime.Now;
            ticket.FechaCreacion = ahora;
            ticket.FechaUltimaModif = ahora;
            ticket.Eliminado = false;

            // 5. Estado y aprobador inicial según necesidad de aprobación  
            if (categoria.AprobadorRequerido)
            {
                // traigo la entidad desde BD
                var estadoAprob = _estadoTicketBLL.ObtenerPorNombre("En Aprobacion");
                ticket.EstadoId = estadoAprob.EstadoId;
                ticket.UsuarioAprobador = categoria.ClienteAprobador;
                ticket.GrupoTecnicoId = null;
            }
            else
            {
                ticket.EstadoId = (int)EstadoTicket.Abierto;
                ticket.UsuarioAprobadorId = null;
                ticket.GrupoTecnicoId = categoria.GrupoTecnicoId;
            }

            // 6. Persistir el ticket
            _ticketDAL.GuardarTicket(ticket);

            // 7. Registrar histórico: creación
            _historicoDAL.Insertar(new TicketHistorico
            {
                TicketId = ticket.TicketId,
                FechaCambio = ahora,
                UsuarioCambioId = ticket.ClienteCreadorId,  // quien creó el ticket
                TipoEvento = "Creación",
                Comentario = "Ticket creado"
            });

            // 8. Registrar histórico: estado inicial
            _historicoDAL.Insertar(new TicketHistorico
            {
                TicketId = ticket.TicketId,
                FechaCambio = ahora,
                UsuarioCambioId = ticket.ClienteCreadorId,
                TipoEvento = "Estado",
                ValorAnteriorId = null,
                ValorNuevoId = ticket.EstadoId,
                Comentario = categoria.RequiereAprobacion
                                      ? "Enviado a aprobación"
                                      : "Apertura automática"
            });

            // 9. Registrar histórico: asignación de grupo técnico inicial (si aplica)
            if (ticket.GrupoTecnicoId.HasValue)
            {
                _historicoDAL.Insertar(new TicketHistorico
                {
                    TicketId = ticket.TicketId,
                    FechaCambio = ahora,
                    UsuarioCambioId = ticket.ClienteCreadorId,
                    TipoEvento = "Grupo",
                    ValorAnteriorId = null,
                    ValorNuevoId = ticket.GrupoTecnicoId,
                    Comentario = "Asignado automáticamente según categoría"
                });
            }

            // 10. Registrar histórico: override de prioridad (solo si cambió)
            if (ticket.PrioridadId != prioridadDefault.Id)
            {
                // Para armar el mensaje, obtengo el nombre de la prioridad seleccionada
                var prioridadOverride = new PrioridadDAL().ObtenerPrioridadPorId(ticket.PrioridadId);
                var nombreOverride = prioridadOverride?.Nombre ?? $"Id {ticket.PrioridadId}";

                _historicoDAL.Insertar(new TicketHistorico
                {
                    TicketId = ticket.TicketId,
                    FechaCambio = ahora,
                    UsuarioCambioId = ticket.ClienteCreadorId,
                    TipoEvento = "Prioridad",
                    ValorAnteriorId = prioridadDefault.Id,
                    ValorNuevoId = ticket.PrioridadId,
                    Comentario = $"Prioridad por defecto ({prioridadDefault.Nombre}) cambiada a {nombreOverride}"
                });
            }
        }

        public Ticket ObtenerTicketPorId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.", nameof(id));

            var ticket = _ticketDAL.ObtenerTicketPorId(id)
                ?? throw new InvalidOperationException($"Ticket con Id {id} no encontrado.");

            if (ticket.Eliminado)
                throw new InvalidOperationException($"El ticket con Id {id} ha sido eliminado.");

            return ticket;
        }

        public void ActualizarTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            if (ticket.TicketId == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.", nameof(ticket.TicketId));

            // Validaciones de contenido
            if (string.IsNullOrWhiteSpace(ticket.Asunto))
                throw new ArgumentException("El asunto del ticket no puede estar vacío.", nameof(ticket.Asunto));
            if (string.IsNullOrWhiteSpace(ticket.Descripcion))
                throw new ArgumentException("La descripción del ticket no puede estar vacía.", nameof(ticket.Descripcion));

            // Obtener ticket existente
            var existente = ObtenerTicketPorId(ticket.TicketId);

            // Validar y aplicar nueva prioridad si fue modificada
            if (ticket.PrioridadId > 0 && ticket.PrioridadId != existente.PrioridadId)
            {
                var nuevaPrioridad = _prioridadBLL.ObtenerPrioridadPorId(ticket.PrioridadId)
                    ?? throw new InvalidOperationException($"Prioridad con Id {ticket.PrioridadId} no encontrada.");
                existente.PrioridadId = nuevaPrioridad.Id;
            }

            // Actualizar otros campos permitidos
            existente.Asunto = ticket.Asunto;
            existente.Descripcion = ticket.Descripcion;
            existente.CategoriaId = ticket.CategoriaId;
            existente.TecnicoId = ticket.TecnicoId;
            existente.FechaUltimaModif = DateTime.Now;

            // Si la categoría requiere aprobación, ajustar estado y aprobador
            var categoria = _categoriaBLL.ObtenerCategoriaPorId(existente.CategoriaId);
            if (categoria.RequiereAprobacion)
            {
                existente.EstadoId = (int)EstadoTicket.EnAprobacion;
                existente.UsuarioAprobadorId = categoria.UsuarioAprobadorId;
            }

            _ticketDAL.ActualizarTicket(existente);
        }

        public void EliminarTicket(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.", nameof(id));

            var ticket = ObtenerTicketPorId(id);
            if (ticket.Eliminado)
                throw new InvalidOperationException($"El ticket con Id {id} ya está eliminado.");

            _ticketDAL.EliminarTicket(id);
        }

        public void AgregarComentario(Ticket ticket, Usuario usuario, string comentario)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));
            if (string.IsNullOrWhiteSpace(comentario))
                throw new ArgumentException("El comentario no puede estar vacío.", nameof(comentario));

            var existente = ObtenerTicketPorId(ticket.TicketId);
            _ticketDAL.AgregarComentario(existente.TicketId, usuario.Id, comentario);

            var nuevoComentario = new Comentario
            {
                TicketId = existente.TicketId,
                Texto = comentario,
                Fecha = DateTime.Now,
                UsuarioId = usuario.Id,
                Ticket = existente
            };
            existente.Comentarios.Add(nuevoComentario);
        }

        public List<Ticket> ListarTicketsDelUsuario(Guid usuarioId)
        {
            if (usuarioId == Guid.Empty)
                throw new ArgumentException("El ID del usuario no puede ser vacío.", nameof(usuarioId));

            var tickets = _ticketDAL.ListarTicketsDelUsuario(usuarioId);
            return tickets.Where(t => !t.Eliminado).ToList();
        }

        public List<Ticket> ListarTicketsDelDepartamento(int departamentoId)
        {
            if (departamentoId <= 0)
                throw new ArgumentException("El ID del departamento debe ser mayor que cero.", nameof(departamentoId));

            var tickets = _ticketDAL.ListarTicketsDelDepartamento(departamentoId);
            return tickets.Where(t => !t.Eliminado).ToList();
        }
    }
}
