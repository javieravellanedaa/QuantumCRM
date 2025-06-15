using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;      // Para usar reflection en RevertirPropiedad
using BE;
using DAL;
using INTERFACES;             // Para IRevertible

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

            // 3. Determinar prioridad inicial: por defecto de la categoría o override desde la UI
            var prioridadDefault = _prioridadBLL.ObtenerPrioridadCategoria(categoria);
            if (ticket.PrioridadId <= 0)
            {
                ticket.PrioridadId = prioridadDefault.Id;
            }

            // 4. Inicializar timestamps y flags
            var ahora = DateTime.Now;
            ticket.FechaCreacion = ahora;
            ticket.FechaUltimaModif = ahora;
            ticket.Eliminado = false;

            // 5. Estado y aprobador inicial según necesidad de aprobación  
            if (categoria.AprobadorRequerido)
            {
                var estadoAprob = _estadoTicketBLL.ObtenerPorNombre("En Aprobacion");
                ticket.EstadoId = estadoAprob.EstadoId;
                ticket.UsuarioAprobador = categoria.ClienteAprobador;
            }
            else
            {
                var estadoAprob = _estadoTicketBLL.ObtenerPorNombre("Derivado");
                ticket.EstadoId = estadoAprob.EstadoId;
                ticket.UsuarioAprobadorId = null;
            }

            // 6. Persistir el ticket
            _ticketDAL.GuardarTicket(ticket);
            _controlDeCambiosBLL.RegistrarCambios(null, ticket);

            // 7. Registrar histórico: creación
            _historicoDAL.Insertar(new TicketHistorico
            {
                TicketId = ticket.TicketId,
                FechaCambio = ahora,
                UsuarioCambioId = _clienteBLL.ObtenerIdUsuarioPorClienteId(ticket.ClienteCreadorId),
                TipoEvento = "Creación",
                Comentario = "Ticket creado"
            });

            // 8. Registrar histórico: estado inicial
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

            // 9. Registrar histórico: asignación de grupo técnico inicial (si aplica)
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

            // 10. Registrar histórico: override de prioridad (solo si cambió)
            if (ticket.PrioridadId != prioridadDefault.Id)
            {
                var prioridadOverride = _prioridadBLL.ObtenerPrioridadPorId(ticket.PrioridadId);
                var nombreOverride = prioridadOverride?.Nombre ?? $"Id {ticket.PrioridadId}";

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
        }

        public Ticket ObtenerTicketPorId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.", nameof(id));

            var ticket = _ticketDAL.ObtenerTicketPorId(id)
                         ?? throw new InvalidOperationException($"Ticket con Id {id} no encontrado.");

            if (ticket.Eliminado)
                throw new InvalidOperationException($"El ticket con Id {id} ha sido eliminado.");

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

            // Paso 1: obtener copia completa antes de cambios
            var ticketAnterior = ObtenerTicketPorId(ticket.TicketId);

            // Paso 2: obtener copia para aplicar cambios
            var existente = ObtenerTicketPorId(ticket.TicketId);
            const int estadoCanceladoId = 7;

            // Estado cancelado
            if (ticket.EstadoId == estadoCanceladoId)
            {
                existente.EstadoId = estadoCanceladoId;
                existente.FechaCierre = DateTime.Now;
                existente.FechaUltimaModif = DateTime.Now;
                _ticketDAL.ActualizarTicket(existente);
                return;
            }

            // Cambio de prioridad
            if (!existente.FechaCierre.HasValue
                && ticket.PrioridadId > 0
                && ticket.PrioridadId != existente.PrioridadId)
            {
                var prioridadAnterior = existente.PrioridadId;
                existente.PrioridadId = ticket.PrioridadId;

                _historicoDAL.Insertar(new TicketHistorico
                {
                    TicketId = existente.TicketId,
                    FechaCambio = DateTime.Now,
                    UsuarioCambioId = _clienteBLL.ObtenerIdUsuarioPorClienteId(ticket.ClienteCreadorId),
                    TipoEvento = "Prioridad",
                    ValorAnteriorId = prioridadAnterior,
                    ValorNuevoId = ticket.PrioridadId,
                    Comentario = $"Prioridad cambiada de Id {prioridadAnterior} a Id {ticket.PrioridadId}"
                });
            }

            // Actualizar campos permitidos
            existente.Asunto = ticket.Asunto;
            existente.Descripcion = ticket.Descripcion;
            existente.CategoriaId = ticket.CategoriaId;
            existente.TecnicoId = ticket.TecnicoId;
            existente.FechaUltimaModif = DateTime.Now;

            var categoria = _categoriaBLL.ObtenerCategoriaPorId(existente.CategoriaId);
            if (categoria.AprobadorRequerido)
            {
                var estadoEnAprob = _estadoTicketBLL.ObtenerPorNombre("En aprobacion");
                existente.EstadoId = estadoEnAprob.EstadoId;
                existente.UsuarioAprobadorId = categoria.ClienteAprobador.ClienteId;
            }

            // Persistir cambios
            _ticketDAL.ActualizarTicket(existente);

            // Registrar sólo las diferencias reales
            _controlDeCambiosBLL.RegistrarCambios(ticketAnterior, existente);
        }

        public void EliminarTicket(Ticket ticket, Usuario usuario)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");
            if (ticket.Eliminado)
                throw new InvalidOperationException($"El ticket con Id {ticket.TicketId} ya está eliminado.");
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
        }

        public List<Ticket> ListarTicketsDeCliente(Cliente cliente)
        {
            if (cliente.ClienteId <= 0)
                throw new ArgumentException("El ID del cliente no puede ser vacío.", nameof(cliente));

            var tickets = _ticketDAL.ListarTicketsDeCliente(cliente.ClienteId);
            return tickets.Where(t => !t.Eliminado).ToList();
        }

        public List<Ticket> ListarTicketsDelDepartamento(int departamentoId)
        {
            if (departamentoId <= 0)
                throw new ArgumentException("El ID del departamento debe ser mayor que cero.", nameof(departamentoId));

            var tickets = _ticketDAL.ListarTicketsDelDepartamento(departamentoId);
            return tickets.Where(t => !t.Eliminado).ToList();
        }

        public void RevertirPropiedad(Guid id, string propiedad, string valorAnterior)
        {
            var ticket = ObtenerTicketPorId(id);

            var propInfo = typeof(Ticket)
                .GetProperty(propiedad, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                ?? throw new InvalidOperationException($"No existe la propiedad '{propiedad}' en Ticket.");

            var typedValue = Convert.ChangeType(valorAnterior, propInfo.PropertyType);
            propInfo.SetValue(ticket, typedValue);
            ActualizarTicket(ticket);
        }
    }
}
