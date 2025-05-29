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
        private readonly EstadoTicketBLL _estadoTicketBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly GrupoTecnicoBLL _grupoTecnicoBLL;
        private readonly TecnicoBLL _tecnicoBLL;
        private readonly ComentarioBLL _comentarioBLL;
        private readonly TicketHistoricoDAL _historicoDAL;

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
                
            }
            else
            {
                var estadoAprob = _estadoTicketBLL.ObtenerPorNombre("Derivado");
                ticket.EstadoId = estadoAprob.EstadoId;
                ticket.UsuarioAprobadorId = null;
                
            }

            // 6. Persistir el ticket
            _ticketDAL.GuardarTicket(ticket);

            // 7. Registrar histórico: creación
            _historicoDAL.Insertar(new TicketHistorico
            {
                TicketId = ticket.TicketId,
                FechaCambio = ahora,
                UsuarioCambioId = _clienteBLL.ObtenerIdUsuarioPorClienteId(ticket.ClienteCreadorId),  // quien creó el ticket
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
                // Para armar el mensaje, obtengo el nombre de la prioridad seleccionada
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

            // 1) Traer sólo los campos primitivos desde DAL
            var ticket = _ticketDAL.ObtenerTicketPorId(id)
                ?? throw new InvalidOperationException($"Ticket con Id {id} no encontrado.");

            // 2) Validar soft-delete
            if (ticket.Eliminado)
                throw new InvalidOperationException($"El ticket con Id {id} ha sido eliminado.");

            // 3) Cargar entidades de navegación
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

            // 4) Cargar comentarios e histórico (si ya definiste esos BLL/DAL)
            ticket.Comentarios = _comentarioBLL.ListarComentariosPorTicket(ticket.TicketId);
            //ticket.Historicos = _historicoDAL.ListarHistoricos(ticket.TicketId);

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

            // --- BLOQUE CORREGIDO: cambio de prioridad ---
            // Sólo si el ticket NO está cerrado y la prioridad nueva difiere de la actual
            if (!existente.FechaCierre.HasValue
                && ticket.PrioridadId > 0
                && ticket.PrioridadId != existente.PrioridadId)
            {
                var prioridadAnterior = existente.PrioridadId;
                existente.PrioridadId = ticket.PrioridadId;

                // Opcional: registrar en histórico
                _historicoDAL.Insertar(new TicketHistorico
                {
                    TicketId = existente.TicketId,
                    FechaCambio = DateTime.Now,
                    UsuarioCambioId = _clienteBLL.ObtenerIdUsuarioPorClienteId(ticket.ClienteCreadorId),       // o quien realice el cambio
                    TipoEvento = "Prioridad",
                    ValorAnteriorId = prioridadAnterior,
                    ValorNuevoId = ticket.PrioridadId,
                    Comentario = $"Prioridad cambiada de Id {prioridadAnterior} a Id {ticket.PrioridadId}"
                });
            }
            // --- fin bloque prioridad ---

            // Actualizar otros campos permitidos
            existente.Asunto = ticket.Asunto;
            existente.Descripcion = ticket.Descripcion;
            existente.CategoriaId = ticket.CategoriaId;
            existente.TecnicoId = ticket.TecnicoId;
            existente.FechaUltimaModif = DateTime.Now;

            // Si la categoría requiere aprobación, ajustar estado y aprobador
            var categoria = _categoriaBLL.ObtenerCategoriaPorId(existente.CategoriaId);
            if (categoria.AprobadorRequerido)
            {
                var estadoEnAprob = _estadoTicketBLL.ObtenerPorNombre("En aprobación");
                existente.EstadoId = estadoEnAprob.EstadoId;
                existente.UsuarioAprobadorId = categoria.ClienteAprobador.ClienteId;
            }

            // Finalmente, persisto los cambios
            _ticketDAL.ActualizarTicket(existente);
        }

        public void EliminarTicket(Ticket ticket, Usuario usuario)
        {
            // 0) Validar parámetros
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");

            // 1) Verificar estado actual
            if (ticket.Eliminado)
                throw new InvalidOperationException($"El ticket con Id {ticket.TicketId} ya está eliminado.");
            if (ticket.FechaCierre.HasValue)
                throw new InvalidOperationException("No se puede eliminar un ticket ya cerrado.");

            //// TO:DO --> Agregar el permiso necesario para que se ejecute esto
            //if (usuario.Permisos
            //    /* && !usuario.EsAdmin */)
            //{
            //    throw new UnauthorizedAccessException("No tienes permisos para eliminar este ticket.");
            //}

            // 3) Marcar como eliminado
            var ahora = DateTime.Now;
            ticket.Eliminado = true;
            ticket.FechaUltimaModif = ahora;

            // 4) Persistir cambios (el DAL debe soportar el flag 'eliminado')
            _ticketDAL.ActualizarTicket(ticket);

            // 5) Registrar en histórico
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
            int clienteId = cliente.ClienteId;
            if (clienteId>0)
            {
                var tickets = _ticketDAL.ListarTicketsDeCliente(clienteId);
                return tickets.Where(t => !t.Eliminado).ToList();

            }
            else
            {

                throw new ArgumentException("El ID del usuario no puede ser vacío.", nameof(Cliente.Id));
            }

           
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
