using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BE.PN;
using BLL;
using SERVICIOS;
using System.Drawing;

namespace UI.Admins.Categoria
{
    public partial class frmAltaCategoria : Form
    {
        private readonly CategoriaBLL _categoriaBLL = new CategoriaBLL();
        private readonly DepartamentoBLL _departamentoBLL = new DepartamentoBLL();
        private readonly PrioridadBLL _prioridadBLL = new PrioridadBLL();
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private readonly GrupoTecnicoBLL _grupoTecnicoBLL = new GrupoTecnicoBLL();

        public frmAltaCategoria(EventManagerService eventManagerService)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(96, 116, 239);

            this.Load += frmAltaCategoria_Load;
            chkAprobadorRequerido.CheckedChanged += chkAprobadorRequerido_CheckedChanged;
            cmbDepartamento.SelectedIndexChanged += cmbDepartamento_SelectedIndexChanged;  
        }


        private void frmAltaCategoria_Load(object sender, EventArgs e)
        {
            LoadCombos();
            cmbClienteAprobador.Visible = chkAprobadorRequerido.Checked;
        }


        private void LoadCombos()
        {
            // Tipo de categoría desde enum
            var tipos = new List<KeyValuePair<int, string>>();
            foreach (TipoCategoria tipo in Enum.GetValues(typeof(TipoCategoria)))
            {
                tipos.Add(new KeyValuePair<int, string>((int)tipo, tipo.ToString()));
            }

            cmbTipoCategoria.DataSource = tipos;
            cmbTipoCategoria.DisplayMember = "Value";
            cmbTipoCategoria.ValueMember = "Key";

            // Departamentos
            var departamentos = _departamentoBLL.ListarDepartamentos();
            cmbDepartamento.DataSource = departamentos;
            cmbDepartamento.DisplayMember = "Nombre";
            cmbDepartamento.ValueMember = "Id";

            // Prioridades
            var prioridades = _prioridadBLL.GetAllPrioridades();
            cmbPrioridad.DataSource = prioridades;
            cmbPrioridad.DisplayMember = "Nombre";
            cmbPrioridad.ValueMember = "Id";

            // Grupo técnico
            var grupos = _grupoTecnicoBLL.ListarGruposTecnicos();
            cmbGrupoTecnico.DataSource = grupos;
            cmbGrupoTecnico.DisplayMember = "Nombre";
            cmbGrupoTecnico.ValueMember = "GrupoId";    

       
        }

        private void chkAprobadorRequerido_CheckedChanged(object sender, EventArgs e)
        {
            cmbClienteAprobador.Visible = chkAprobadorRequerido.Checked;

            if (chkAprobadorRequerido.Checked && cmbDepartamento.SelectedItem != null)
            {
                cmbDepartamento_SelectedIndexChanged(null, null);
            }
        }


        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.");
                return false;
            }

            if (chkAprobadorRequerido.Checked && cmbClienteAprobador.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente aprobador.");
                return false;
            }

            if (cmbDepartamento.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un departamento.");
                return false;
            }

            if (cmbPrioridad.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una prioridad.");
                return false;
            }

            return true;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ValidarFormulario())
                {
                    var categoria = new BE.Categoria
                    {
                        CategoriaId = 0,

                        Nombre = txtNombre.Text.Trim(),
                        Descripcion = txtDescripcion.Text.Trim(),
                        tipoCategoria = (TipoCategoria)((KeyValuePair<int, string>)cmbTipoCategoria.SelectedItem).Key,
                        AprobadorRequerido = chkAprobadorRequerido.Checked,
                        ClienteAprobador = chkAprobadorRequerido.Checked ? (Cliente)cmbClienteAprobador.SelectedItem : null,
                        Departamento = (Departamento)cmbDepartamento.SelectedItem,
                        Prioridad = (Prioridad)cmbPrioridad.SelectedItem,
                        GrupoTecnico = (GrupoTecnico)cmbGrupoTecnico.SelectedItem,
                        Estado = true,
                        FechaCreacion = DateTime.Now,
                        CreadorId = SingletonSesion.Instancia.Sesion.Usuario.Id
                    };

                    _categoriaBLL.AgregarCategoria(categoria);
                    if (categoria.AprobadorRequerido && categoria.ClienteAprobador != null)
                    {
                        categoria.ClienteAprobador.EsAprobador = true;
                        _clienteBLL.MarcarComoAprobador(categoria.ClienteAprobador.ClienteId);
                    }


                    MessageBox.Show("Categoría agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      

        }
        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkAprobadorRequerido.Checked && cmbDepartamento.SelectedItem != null)
            {
                var departamentoSeleccionado = (Departamento)cmbDepartamento.SelectedItem;

                var clientes = _clienteBLL.ListarClientesPorDepartamento(departamentoSeleccionado.Id);

                if (clientes.Count > 0)
                {
                    cmbClienteAprobador.DataSource = null;
                    cmbClienteAprobador.DataSource = clientes;
                    cmbClienteAprobador.DisplayMember = "NombreListado";
                    cmbClienteAprobador.ValueMember = "ClienteId";
                    cmbClienteAprobador.Enabled = true;
                }
                else
                {
                    cmbClienteAprobador.DataSource = null;
                    cmbClienteAprobador.Items.Clear();
                    cmbClienteAprobador.Enabled = false;
                }
            }
            else
            {
                cmbClienteAprobador.DataSource = null;
                cmbClienteAprobador.Items.Clear();
                cmbClienteAprobador.Enabled = false;
            }

            cmbClienteAprobador.Visible = chkAprobadorRequerido.Checked;
        }


    }
}
