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

namespace UI
{
    public partial class frmAdministrarIdioma : Form
    {
        private IdiomaBLL _idiomaBLL;
        private TraduccionBLL _traduccionBLL;
        public frmAdministrarIdioma(IdiomaBLL idiomaBLL)
        {
            InitializeComponent();
            _idiomaBLL = idiomaBLL;
            _traduccionBLL = new TraduccionBLL();
            CargarIdiomas();
            ActualizarLista();
        }

        private void CargarIdiomas()
        {
            var idiomas = _idiomaBLL.ObtenerIdiomas();

            // Depuración y verificación de las propiedades
            foreach (var idioma in idiomas)
            {
                Console.WriteLine($"Propiedades de idioma: {string.Join(", ", idioma.GetType().GetProperties().Select(p => p.Name))}");
            }

            cmbIdioma.DataSource = idiomas;
            cmbIdioma.DisplayMember = "Nombre";
            cmbIdioma.ValueMember = "Id"; // Asegúrate de que los objetos en 'idiomas' tienen una propiedad 'Id'
        }

        private void CargarTraducciones(Guid idiomaId)
        {
            var traducciones = _traduccionBLL.ObtenerTraduccionesPorIdioma(idiomaId);
            MessageBox.Show($"Se han encontrado {traducciones.Count} traducciones para el idioma seleccionado.");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = traducciones;

            // Configurar DataGridView
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["IdiomaId"].Visible = false;
            dataGridView1.Columns["EtiquetaId"].Visible = false;
            dataGridView1.Columns["Etiqueta"].Visible = false; // Oculta la columna Etiqueta

            dataGridView1.Columns["EtiquetaNombre"].HeaderText = "Nombre de Etiqueta";
            dataGridView1.Columns["Texto"].HeaderText = "Traducción";
        }
        private void ActualizarLista()
        {
            lstIdiomas.Items.Clear();

            var idiomas = _idiomaBLL.ObtenerIdiomas();

            foreach (var idioma in idiomas)
            {
                lstIdiomas.Items.Add(idioma.Nombre);
            }
        }
        private void btnAgregarIdioma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdioma.Text))
            {
                MessageBox.Show("El campo de idioma no puede estar vacio", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool ok = _idiomaBLL.AgregarIdioma(txtIdioma.Text);

                if (ok)
                {
                    MessageBox.Show("Idioma agregado correctamente");
                    ActualizarLista();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al agregar el idioma.");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var traducciones = (List<Traduccion>)dataGridView1.DataSource;
            foreach (var traduccion in traducciones)
            {
                // Asignar un nuevo ID si la traducción es nueva
                if (traduccion.Id == Guid.Empty)
                {
                    traduccion.Id = Guid.NewGuid();
                }
                _traduccionBLL.GuardarTraduccion(traduccion);
            }

            // Obtener el idioma seleccionado
            var idiomaSeleccionado = (IIdioma)cmbIdioma.SelectedItem;

            // Notificar a los observadores
            SingletonSesion.Instancia.CambiarIdioma(idiomaSeleccionado);

            MessageBox.Show("Traducciones guardadas correctamente.");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdministrarIdioma_Load(object sender, EventArgs e)
        {

        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdioma.SelectedItem != null)
            {
                var idioma = (IIdioma)cmbIdioma.SelectedItem;
                CargarTraducciones(idioma.Id);
            }
        }

        private void lstIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
