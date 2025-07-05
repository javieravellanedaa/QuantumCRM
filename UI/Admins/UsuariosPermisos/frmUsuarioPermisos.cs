using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using INTERFACES;
using BE;
using SERVICIOS;

namespace UI.Admins.UsuariosPermisos
{
    public partial class frmUsuarioPermisos : Form
    {
        private readonly EventManagerService _eventManagerService;
        UsuarioBLL _usuarioBLL = new UsuarioBLL();
        PermisoBLL _permisoBLL = new PermisoBLL();

        public frmUsuarioPermisos(EventManagerService eventManagerService)
        {
            _eventManagerService = eventManagerService;
            InitializeComponent();

            // Configuración visual
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(96, 116, 239);

            // Cargar usuarios y sus eventos
            CargarUsuarios();
            cbUsuarios.SelectedIndexChanged += cbUsuarios_SelectedIndexChanged;

            // Si ya hay un usuario en la lista, forzamos la carga inicial de los combo boxes de familias.
            if (cbUsuarios.Items.Count > 0)
            {
                cbUsuarios.SelectedIndex = 0;
                cbUsuarios_SelectedIndexChanged(cbUsuarios, EventArgs.Empty);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                // Obtenemos la lista de usuarios
                var usuarios = _usuarioBLL.ObtenerlistaDeUsuarios();
            

                // Proyectamos en un nuevo listado con el formato "Apellido, Nombre"
                var lista = usuarios.Select(u => new
                {
                    Id = u.Id,
                    NombreCompleto = $"{u.Apellido}, {u.Nombre}"
                }).ToList();

                // Asignamos la lista al ComboBox de usuarios
                cbUsuarios.DataSource = lista;
                cbUsuarios.DisplayMember = "NombreCompleto";
                cbUsuarios.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento que se dispara al cambiar la selección del usuario
        private void cbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbUsuarios.SelectedValue != null)
                {
                    Guid usuarioId = Guid.Parse(cbUsuarios.SelectedValue.ToString());

                    // Obtenemos los roles (familias) que el usuario ya posee
                    var roles = _usuarioBLL.ObtenerRolesPorUsuario(usuarioId);

                    // Actualizamos el ComboBox de familias (permisos asignados)
                    if (roles != null && roles.Count > 0)
                    {
                        cbFamilias.DataSource = roles;
                        cbFamilias.DisplayMember = "Nombre";  // Ajusta según la propiedad que quieras mostrar
                        cbFamilias.ValueMember = "Id";        // Ajusta según la propiedad identificadora
                        cbFamilias.SelectedIndex = 0;
                    }
                    else
                    {
                        cbFamilias.DataSource = null;
                        cbFamilias.Items.Clear();
                        cbFamilias.Text = string.Empty;
                    }

                    // Obtenemos la lista completa de familias disponibles
                    var allFamilias = _permisoBLL.GetAllFamilias();

                    // Filtramos para excluir aquellas familias que el usuario ya posee
                    var familiasDisponibles = allFamilias.Where(f => !roles.Any(r => r.Id == f.Id)).ToList();

                    // Actualizamos el ComboBox de asignación (permisos disponibles para asignar)
                    if (familiasDisponibles != null && familiasDisponibles.Count > 0)
                    {
                        cbAsignarFamilias.DataSource = familiasDisponibles;
                        cbAsignarFamilias.DisplayMember = "Nombre";
                        cbAsignarFamilias.ValueMember = "Id";
                        cbAsignarFamilias.SelectedIndex = 0;
                    }
                    else
                    {
                        cbAsignarFamilias.DataSource = null;
                        cbAsignarFamilias.Items.Clear();
                        cbAsignarFamilias.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón para asignar permisos
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validamos que se haya seleccionado un usuario y un permiso (familia) a asignar.
                if (cbUsuarios.SelectedValue == null || cbAsignarFamilias.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione un usuario y un permiso para asignar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Guid usuarioId = Guid.Parse(cbUsuarios.SelectedValue.ToString());
                int permisoId = int.Parse(cbAsignarFamilias.SelectedValue.ToString());

                // Se asume que la BLL de usuario tiene un método para asignar permisos,
                // por ejemplo: AsignarPermiso(usuarioId, permisoId)
                bool asignado = _usuarioBLL.AsignarPermiso(usuarioId, permisoId);

                if (asignado)
                {
                    MessageBox.Show("Permiso asignado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizamos los ComboBoxes de roles y permisos disponibles
                    cbUsuarios_SelectedIndexChanged(cbUsuarios, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("No se pudo asignar el permiso, por favor intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar permiso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
