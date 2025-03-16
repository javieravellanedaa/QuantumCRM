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
        private readonly IdiomaBLL _idiomaBLL;
        private readonly TraduccionBLL _traduccionBLL;
        private readonly EventManagerService _eventManagerService;

        // Guarda temporalmente el Id del último idioma agregado (opcional, si deseas otra lógica)
        private Guid _idiomaRecienCreadoId;

        public frmAdministrarIdioma(IdiomaBLL idiomaBLL, EventManagerService eventManagerService)
        {
            InitializeComponent();

            // Instancias de BLL
            _idiomaBLL = idiomaBLL;
            _traduccionBLL = new TraduccionBLL();
            _eventManagerService = eventManagerService;

            // Configuración visual
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(96, 116, 239);

            // Cargar datos iniciales (para las distintas solapas)
            CargarIdiomasActivos();
            CargarIdiomasInactivos();
            CargarListaParaBorrar();
        }
        public void SeleccionarTab(int index)
        {
            if (index >= 0 && index < tabControlIdioma.TabCount)
            {
                tabControlIdioma.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show($"Índice de pestaña inválido: {index}");
            }
        }


        private void frmAdministrarIdioma_Load(object sender, EventArgs e)
        {
            // Opcional: lógica adicional al cargarse el form
        }

        #region ---- CARGAS PRINCIPALES ----

        /// <summary>
        /// Carga los idiomas activos en el ComboBox de la pestaña "Traducciones" y en el ListBox de la pestaña "Idiomas Activos".
        /// </summary>
        private void CargarIdiomasActivos()
        {
            // Se asume que ObtenerIdiomas() en tu BLL retorna SOLO los idiomas con Activo=true
            var idiomasActivos = _idiomaBLL.ObtenerIdiomas();

            // ComboBox (pestaña "Traducciones")
            cmbIdioma.DataSource = null;
            cmbIdioma.DataSource = idiomasActivos;
            cmbIdioma.DisplayMember = "Nombre";
            cmbIdioma.ValueMember = "Id";

            // ListBox (pestaña "Idiomas Activos")
            lstIdiomasActivos.Items.Clear();
            foreach (var idioma in idiomasActivos)
            {
                lstIdiomasActivos.Items.Add(idioma.Nombre);
            }
        }

        /// <summary>
        /// Carga los idiomas inactivos en el ListBox de la pestaña "Idiomas Inactivos".
        /// </summary>
        private void CargarIdiomasInactivos()
        {
            // Se asume que tienes un método en la BLL que retorna Idiomas con Activo=false
            var idiomasInactivos = _idiomaBLL.ObtenerIdiomasInactivos();

            lstIdiomasInactivos.Items.Clear();
            foreach (var idioma in idiomasInactivos)
            {
                lstIdiomasInactivos.Items.Add(idioma.Nombre);
            }

            // Limpiar la grilla de traducciones inactivas (estético)
            dgvTraduccionesInactivos.DataSource = null;
        }

        /// <summary>
        /// Carga TODOS los idiomas (activos + inactivos) en el ListBox de la pestaña "Borrar Idiomas".
        /// </summary>
        private void CargarListaParaBorrar()
        {
            // Se asume que existe en la BLL un método que retorna TODOS los idiomas sin filtrar, p.e.:
            // _idiomaBLL.ObtenerTodosLosIdiomas()

            var todosLosIdiomas = _idiomaBLL.ObtenerTodosLosIdiomas();

            lstIdiomasBorrar.Items.Clear();
            foreach (var idioma in todosLosIdiomas)
            {
                // Ejemplo: "Español (Activo)"
                string estado = idioma.Activo ? "Activo" : "Inactivo";
                lstIdiomasBorrar.Items.Add($"{idioma.Nombre} ({estado})");
            }
        }

        #endregion

        #region ---- SOLAPA: TRADUCCIONES (IDIOMAS ACTIVOS) ----

        /// <summary>
        /// Cargar en dgvTraducciones las traducciones existentes para un idioma (sin filtrar ni lanzar excepciones).
        /// </summary>
        private void CargarTraducciones(Guid idiomaId)
        {
            // Obtenemos las traducciones existentes (incluso vacías)
            var traducciones = _traduccionBLL.ObtenerTraduccionesPorIdioma(idiomaId);

            dgvTraducciones.DataSource = null;
            dgvTraducciones.DataSource = traducciones;

            // Configurar columnas
            if (dgvTraducciones.Columns["Id"] != null)
                dgvTraducciones.Columns["Id"].Visible = false;

            if (dgvTraducciones.Columns["IdiomaId"] != null)
                dgvTraducciones.Columns["IdiomaId"].Visible = false;

            if (dgvTraducciones.Columns["EtiquetaId"] != null)
                dgvTraducciones.Columns["EtiquetaId"].Visible = false;

            if (dgvTraducciones.Columns["Etiqueta"] != null)
                dgvTraducciones.Columns["Etiqueta"].Visible = false;

            if (dgvTraducciones.Columns["EtiquetaNombre"] != null)
                dgvTraducciones.Columns["EtiquetaNombre"].HeaderText = "Nombre de Etiqueta";

            if (dgvTraducciones.Columns["TextoOriginal"] != null)
                dgvTraducciones.Columns["TextoOriginal"].HeaderText = "Texto Original";

            if (dgvTraducciones.Columns["Texto"] != null)
                dgvTraducciones.Columns["Texto"].HeaderText = "Traducción";

            if (dgvTraducciones.Columns["Formulario"] != null)
                dgvTraducciones.Columns["Formulario"].HeaderText = "Formulario";
        }

        /// <summary>
        /// Al cambiar de idioma en el ComboBox, recargamos la grilla de traducciones.
        /// </summary>
        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdioma.SelectedItem == null) return;

            var idiomaSeleccionado = (IIdioma)cmbIdioma.SelectedItem;
            CargarTraducciones(idiomaSeleccionado.Id);
        }

        /// <summary>
        /// Al hacer clic en "Guardar" (solapa Traducciones) se guardan todas las filas, 
        /// y si detectamos vacíos, se desactiva el idioma.
        /// </summary>
        private void btnGuardarTraducciones_Click(object sender, EventArgs e)
        {
            if (cmbIdioma.SelectedItem == null)
            {
                MessageBox.Show("No se ha seleccionado ningún idioma.");
                return;
            }

            var idiomaSeleccionado = (IIdioma)cmbIdioma.SelectedItem;
            var traducciones = dgvTraducciones.DataSource as List<Traduccion>;

            if (traducciones == null || traducciones.Count == 0)
            {
                // Si no hay registros, desactivamos el idioma
                _idiomaBLL.DesactivarIdioma(idiomaSeleccionado.Id);
                MessageBox.Show("No hay traducciones. El idioma se ha inactivado.");

                // Refrescar
                CargarIdiomasActivos();
                CargarIdiomasInactivos();
                CargarListaParaBorrar();
                return;
            }

            // Guardamos siempre (sean vacías o no)
            foreach (var trad in traducciones)
            {
                if (trad.Id == Guid.Empty)
                    trad.Id = Guid.NewGuid();

                _traduccionBLL.GuardarTraduccion(trad);
            }

            // Ahora validamos si quedaron vacías
            bool hayVacias = traducciones.Any(t => string.IsNullOrWhiteSpace(t.Texto));
            if (hayVacias)
            {
                // Desactivar
                _idiomaBLL.DesactivarIdioma(idiomaSeleccionado.Id);
                MessageBox.Show("Existen textos sin traducir. El idioma se ha desactivado.");

                CargarIdiomasActivos();
                CargarIdiomasInactivos();
                CargarListaParaBorrar();
                return;
            }

            // Todo completo => mantenemos activo => Notificamos
            SingletonSesion.Instancia.Sesion.CambiarIdioma(idiomaSeleccionado);

            MessageBox.Show("Traducciones guardadas correctamente.");
        }

        #endregion

        #region ---- SOLAPA: IDIOMAS ACTIVOS (AGREGAR) ----

        /// <summary>
        /// Botón para agregar un nuevo idioma. Se crea como activo, pero 
        /// si las traducciones quedan incompletas, luego se pasará a inactivo.
        /// </summary>
        private void btnAgregarNuevoIdioma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreIdioma.Text))
            {
                MessageBox.Show("El campo de idioma no puede estar vacío",
                                "Error de Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            bool resultado = _idiomaBLL.AgregarIdioma(txtNombreIdioma.Text);
            if (resultado)
            {
                MessageBox.Show("Idioma agregado correctamente.");

                // Refrescar
                CargarIdiomasActivos();
                CargarIdiomasInactivos();
                CargarListaParaBorrar();

                txtNombreIdioma.Clear();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al agregar el idioma.");
            }
        }

        private void lstIdiomasActivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Puedes manejar la sincronización con el combo, o mostrar info. 
            // Depende de tu flujo.
        }

        #endregion

        #region ---- SOLAPA: IDIOMAS INACTIVOS ----

        /// <summary>
        /// Al seleccionar un idioma inactivo en la lista, cargamos sus traducciones (incluso vacías) en dgvTraduccionesInactivos.
        /// </summary>
        private void lstIdiomasInactivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstIdiomasInactivos.SelectedIndex == -1) return;

            // Nombre del idioma
            string nombre = lstIdiomasInactivos.SelectedItem.ToString();
            var idiomaInactivo = _idiomaBLL.ObtenerIdiomaPorNombreEnTodos(nombre);
            if (idiomaInactivo == null)
            {
                MessageBox.Show("No se encontró el idioma en la base.");
                return;
            }
            CargarTraduccionesInactivos(idiomaInactivo.Id);
        }


        private void CargarTraduccionesInactivos(Guid idiomaId)
        {
            // 1) Pedimos todas las traducciones (aunque estén vacías)
            var traducciones = _traduccionBLL.ObtenerTraduccionesPorIdioma(idiomaId);

            // 2) Asignamos al DataGridView
            dgvTraduccionesInactivos.DataSource = null;
            dgvTraduccionesInactivos.DataSource = traducciones;

            // 3) Ajustes de columnas
            if (dgvTraduccionesInactivos.Columns["Id"] != null)
                dgvTraduccionesInactivos.Columns["Id"].Visible = false;
            if (dgvTraduccionesInactivos.Columns["IdiomaId"] != null)
                dgvTraduccionesInactivos.Columns["IdiomaId"].Visible = false;
            if (dgvTraduccionesInactivos.Columns["EtiquetaId"] != null)
                dgvTraduccionesInactivos.Columns["EtiquetaId"].Visible = false;
            if (dgvTraduccionesInactivos.Columns["Etiqueta"] != null)
                dgvTraduccionesInactivos.Columns["Etiqueta"].Visible = false;

            if (dgvTraduccionesInactivos.Columns["EtiquetaNombre"] != null)
                dgvTraduccionesInactivos.Columns["EtiquetaNombre"].HeaderText = "Nombre de Etiqueta";
            if (dgvTraduccionesInactivos.Columns["TextoOriginal"] != null)
                dgvTraduccionesInactivos.Columns["TextoOriginal"].HeaderText = "Texto Original";
            if (dgvTraduccionesInactivos.Columns["Texto"] != null)
                dgvTraduccionesInactivos.Columns["Texto"].HeaderText = "Traducción";
            if (dgvTraduccionesInactivos.Columns["Formulario"] != null)
                dgvTraduccionesInactivos.Columns["Formulario"].HeaderText = "Formulario";
        }

        /// <summary>
        /// Botón "Activar Idioma Seleccionado": guarda las traducciones, 
        /// y si no hay vacías, lo pone en activo.
        /// </summary>
        private void btnActivarIdiomaInactivo_Click(object sender, EventArgs e)
        {
            if (lstIdiomasInactivos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un idioma inactivo de la lista.");
                return;
            }

            // 1) Buscar el idioma en TODOS (no solo en los activos)
            string nombre = lstIdiomasInactivos.SelectedItem.ToString();
            var idioma = _idiomaBLL.ObtenerIdiomaPorNombreEnTodos(nombre);
            if (idioma == null)
            {
                MessageBox.Show("No se encontró el idioma en la base.");
                return;
            }

            // 2) Confirmar la edición de la grilla (para que se vuelquen los cambios a la lista)
            dgvTraduccionesInactivos.EndEdit();

            // 3) Obtener la lista de traducciones
            var traducciones = dgvTraduccionesInactivos.DataSource as List<Traduccion>;
            if (traducciones == null || traducciones.Count == 0)
            {
                MessageBox.Show("No hay traducciones para este idioma. Complete antes de activar.");
                return;
            }

            // 4) Guardar todo. Insertar si "Id" = Guid.Empty, actualizar si no.
            int total = traducciones.Count;
            int vacias = 0;

            foreach (var trad in traducciones)
            {
                // Contar cuántas siguen vacías
                if (string.IsNullOrWhiteSpace(trad.Texto))
                    vacias++;

                // Si no tiene ID => generamos uno nuevo => Insert en la DAL
                if (trad.Id == Guid.Empty)
                    trad.Id = Guid.NewGuid();

                // Llamamos a la BLL
                _traduccionBLL.GuardarTraduccion(trad);
            }

            // 5) Verificar cuántas faltan
            if (vacias > 0)
            {
                // Queda inactivo; Notificamos
                MessageBox.Show(
                    $"Se guardaron {total - vacias} completas y {vacias} siguen vacías.\n" +
                    $"El idioma '{idioma.Nombre}' permanece inactivo."
                );

                // Forzar inactivo si deseas, en caso de que no ya lo esté
                _idiomaBLL.DesactivarIdioma(idioma.Id);
            }
            else
            {
                // Todas completas => activar
                _idiomaBLL.ActivarIdioma(idioma.Id);
                MessageBox.Show($"El idioma '{idioma.Nombre}' se ha activado correctamente.");
            }

            // 6) Refrescar las listas
            CargarIdiomasActivos();
            CargarIdiomasInactivos();
            CargarListaParaBorrar();
        }

        #endregion

        #region ---- SOLAPA: BORRAR IDIOMAS ----

        /// <summary>
        /// Botón que elimina el idioma seleccionado en lstIdiomasBorrar.
        /// </summary>
        private void btnBorrarIdioma_Click(object sender, EventArgs e)
        {
            if (lstIdiomasBorrar.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un idioma de la lista para borrar.");
                return;
            }

            // Ejemplo: "Español (Activo)"
            string seleccionado = lstIdiomasBorrar.SelectedItem.ToString();
            // Tomar solo el nombre "Español"
            string nombreIdioma = seleccionado.Split('(')[0].Trim();

            var idiomaABorrar = _idiomaBLL.ObtenerIdiomaPorNombre(nombreIdioma);
            if (idiomaABorrar == null)
            {
                MessageBox.Show("No se encontró el idioma a borrar en el sistema.");
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de eliminar el idioma '{idiomaABorrar.Nombre}' permanentemente?",
                "Confirmación de borrado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // Llamamos al método que elimina físicamente en la DB
                bool exito = _idiomaBLL.EliminarIdioma(idiomaABorrar.Id);
                if (exito)
                {
                    MessageBox.Show("Idioma borrado con éxito.");
                    // Refrescamos las listas/combos
                    CargarIdiomasActivos();
                    CargarIdiomasInactivos();
                    CargarListaParaBorrar();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar borrar el idioma.");
                }
            }
        }

        #endregion

        #region ---- BOTÓN CERRAR FORM ----

        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
