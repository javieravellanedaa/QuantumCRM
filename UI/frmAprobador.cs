using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICIOS;
using INTERFACES;

namespace UI
{
    public partial class frmAprobador : Form, IEventListener
    {
        private readonly TicketBLL _ticketBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly EventManagerService _eventManagerService;
        private readonly int _usuarioAprobadorId;
        private List<Ticket> _ticketsPendientes;

        // Recibe EventManagerService y el Id de aprobador
        public frmAprobador(EventManagerService eventManagerService, int usuarioAprobadorId)
        {
            InitializeComponent();
            _eventManagerService = eventManagerService;
            _ticketBLL = new TicketBLL();
            _clienteBLL = new ClienteBLL();
            _usuarioAprobadorId = usuarioAprobadorId;

            // Suscribir al evento de cierre si es necesario
            _eventManagerService.Subscribe("FormularioCerrado", this);
        }

        private void frmAprobador_Load(object sender, EventArgs e)
        {
            CargarTickets();
        }

        private void CargarTickets()
        {
            // Obtener tickets en estado "En Aprobacion"
            _ticketsPendientes = _ticketBLL.ListarTicketsPendientesDeAprobacion(_usuarioAprobadorId);

            // Proyección a objeto anónimo para el grid, obteniendo cliente completo
            var fuente = _ticketsPendientes
                .Select(t =>
                {
                    var cliente = _clienteBLL.ObtenerClientePorId(t.ClienteCreadorId);
                    return new
                    {
                        TicketId = t.TicketId,
                        FechaCreacion = t.FechaCreacion,
                        Asunto = t.Asunto,
                        Descripcion = t.Descripcion,
                        Cliente = $"{cliente.Apellido}, {cliente.Nombre}"
                    };
                })
                .ToList();

            dgvAprobaciones.DataSource = fuente;
        }

        private Guid? GetTicketIdSeleccionado()
        {
            if (dgvAprobaciones.CurrentRow == null)
                return null;

            // Usa el nombre de la columna en el designer: "colTicketId"
            var cell = dgvAprobaciones.CurrentRow.Cells["colTicketId"];
            if (cell?.Value is Guid guid)
                return guid;

            return null;
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            var id = GetTicketIdSeleccionado();
            if (!id.HasValue) return;

            _ticketBLL.AprobarTicket(id.Value, _usuarioAprobadorId);
            CargarTickets();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            var id = GetTicketIdSeleccionado();
            if (!id.HasValue) return;

            _ticketBLL.RechazarTicket(id.Value, _usuarioAprobadorId);
            CargarTickets();
        }

        public void Update(string eventType, object data)
        {
            if (eventType == "FormularioCerrado")
            {
                CargarTickets();
            }
        }
    }
}
