using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BE;
using BE.PN;
using BLL;

namespace UI
{
    public partial class AltaTecnico : Form
    {
        private readonly UsuarioBLL _usuarioBLL = new UsuarioBLL();
     
        private readonly GrupoTecnicoBLL _grupoTecnicoBLL = new GrupoTecnicoBLL();
        private readonly TecnicoBLL _tecnicoBLL = new TecnicoBLL();

        private List<Usuario> _usuariosDisponibles;

        public AltaTecnico()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            Load += AltaTecnico_Load;
            btnGuardar.Click += BtnGuardar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            clbGrupos.DrawItem += clbGrupos_DrawItem;
        }

        private void AltaTecnico_Load(object sender, EventArgs e)
        {
            try
            {
                _usuariosDisponibles = _usuarioBLL.ObtenerCandidatosParaTecnico();
                lstUsuarios.DataSource = _usuariosDisponibles;
                lstUsuarios.DisplayMember = "Email";
                lstUsuarios.ValueMember = "Id";

    

                var grupos = _grupoTecnicoBLL.ListarGruposTecnicos();
                clbGrupos.DataSource = grupos;
                clbGrupos.DisplayMember = "Nombre";
                clbGrupos.ValueMember = "GrupoId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstUsuarios.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEspecialidad.Text))
                {
                    MessageBox.Show("Debe ingresar una especialidad.");
                    return;
                }


                var usuario = (Usuario)lstUsuarios.SelectedItem;
             
                var gruposSeleccionados = clbGrupos.CheckedItems.Cast<GrupoTecnico>().ToList();

                var tecnico = new Tecnico
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Email = usuario.Email,
                    Especialidad = txtEspecialidad.Text.Trim(),
                
                    GruposTecnicos = gruposSeleccionados
                };

                _tecnicoBLL.CrearTecnico(tecnico);

                MessageBox.Show("Técnico creado correctamente.");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el técnico: " + ex.Message);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            lstUsuarios.ClearSelected();
            txtEspecialidad.Clear();
    
            for (int i = 0; i < clbGrupos.Items.Count; i++)
            {
                clbGrupos.SetItemChecked(i, false);
            }
        }

        private void clbGrupos_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            CheckedListBox clb = (CheckedListBox)sender;
            bool isChecked = clb.GetItemChecked(e.Index);

            e.DrawBackground();

            Font font = e.Font;
            Brush brush = new SolidBrush(e.ForeColor);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                brush = Brushes.White;

            CheckBoxRenderer.DrawCheckBox(e.Graphics,
                new System.Drawing.Point(e.Bounds.X, e.Bounds.Y + 4),
                isChecked ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal
                          : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);

            e.Graphics.DrawString(clb.Items[e.Index].ToString(), font, brush,
                e.Bounds.X + 20, e.Bounds.Y + 4);

            e.DrawFocusRectangle();
        }
    }
}
