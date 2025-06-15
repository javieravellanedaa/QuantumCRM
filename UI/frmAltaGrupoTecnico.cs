using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using BE.PN;

namespace UI
{
    public partial class frmAltaGrupoTecnico : Form
    {
        private readonly TecnicoBLL _tecnicoBLL = new TecnicoBLL();
        private readonly GrupoTecnicoBLL _grupoBLL = new GrupoTecnicoBLL();
        private List<Tecnico> _tecnicosDisponibles = new List<Tecnico>();

        public frmAltaGrupoTecnico()
        {
            InitializeComponent();
            CargarTecnicosDisponibles();
        }

        private void CargarTecnicosDisponibles()
        {
            try
            {
                _tecnicosDisponibles = _tecnicoBLL.ListarTecnicosActivos();

                cmbLider.DataSource = new List<Tecnico>(_tecnicosDisponibles);
                cmbLider.DisplayMember = "NombreCompleto";
                cmbLider.ValueMember = "TecnicoId";
                cmbLider.SelectedIndex = -1;

                lstTecnicos.DataSource = new List<Tecnico>(_tecnicosDisponibles);
                lstTecnicos.DisplayMember = "NombreCompleto";
                lstTecnicos.ValueMember = "TecnicoId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los técnicos disponibles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre del grupo técnico es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbLider.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un técnico líder.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lstTecnicos.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos un técnico para el grupo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var tecnicoLider = (Tecnico)cmbLider.SelectedItem;
                var tecnicosSeleccionados = lstTecnicos.SelectedItems.Cast<Tecnico>().ToList();

                // Validar que el técnico líder esté dentro de la lista seleccionada
                if (!tecnicosSeleccionados.Any(t => t.TecnicoId == tecnicoLider.TecnicoId))
                {
                    MessageBox.Show("El técnico líder debe estar incluido en la lista de técnicos del grupo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var grupo = new GrupoTecnico
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    TecnicoLider = tecnicoLider,
                    TecnicoLiderId = tecnicoLider.TecnicoId,
                    Tecnicos = tecnicosSeleccionados,
                    Activo = chkActivo.Checked
                };

                _grupoBLL.AgregarGrupoTecnico(grupo);
                MessageBox.Show("Grupo técnico creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el grupo técnico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            cmbLider.SelectedIndex = -1;
            lstTecnicos.ClearSelected();
            chkActivo.Checked = true;
        }
    }
}
