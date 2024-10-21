using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class frmCategorias : Form
    {
        
        private CategoriaBLL categoriaBLL;
        private UsuarioBLL usuarioBLL;

        public frmCategorias()
        {
            InitializeComponent();
            categoriaBLL = new CategoriaBLL();
            usuarioBLL = new UsuarioBLL();
         



        }




        private void CargarCategorias()
        {
            try
            {
                // Desactivar la generación automática de columnas
                dgvCategorias.AutoGenerateColumns = false;

                // Limpiar cualquier configuración previa de columnas
                dgvCategorias.Columns.Clear();

                // Asignar el manejador del evento DataError
                dgvCategorias.DataError += dgvCategorias_DataError;

                // Columna categoria_id (int)
                DataGridViewTextBoxColumn categoriaIdColumn = new DataGridViewTextBoxColumn();
                categoriaIdColumn.DataPropertyName = "CategoriaId";
                categoriaIdColumn.HeaderText = "ID Categoría";
                dgvCategorias.Columns.Add(categoriaIdColumn);

                // Columna nombre (nvarchar)
                DataGridViewTextBoxColumn nombreColumn = new DataGridViewTextBoxColumn();
                nombreColumn.DataPropertyName = "Nombre";
                nombreColumn.HeaderText = "Nombre";
                dgvCategorias.Columns.Add(nombreColumn);

                // Columna descripcion (nvarchar)
                DataGridViewTextBoxColumn descripcionColumn = new DataGridViewTextBoxColumn();
                descripcionColumn.DataPropertyName = "Descripcion";
                descripcionColumn.HeaderText = "Descripción";
                dgvCategorias.Columns.Add(descripcionColumn);

                //// Columna group_id (int)
                //DataGridViewTextBoxColumn groupIdColumn = new DataGridViewTextBoxColumn();
                //groupIdColumn.DataPropertyName = "GroupId";
                //groupIdColumn.HeaderText = "ID Grupo";
                //dgvCategorias.Columns.Add(groupIdColumn);

                //// Columna tipo_id (int)
                //DataGridViewTextBoxColumn tipoIdColumn = new DataGridViewTextBoxColumn();
                //tipoIdColumn.DataPropertyName = "TipoId";
                //tipoIdColumn.HeaderText = "ID Tipo";
                //dgvCategorias.Columns.Add(tipoIdColumn);


                // Columna estado_categoria_id (int)
                DataGridViewTextBoxColumn estadoCategoriaIdColumn = new DataGridViewTextBoxColumn();
                estadoCategoriaIdColumn.DataPropertyName = "NombreEstadoCategoria";
                estadoCategoriaIdColumn.HeaderText = "Estado";
                dgvCategorias.Columns.Add(estadoCategoriaIdColumn);


                // Columna tipoCategoria (string)
                DataGridViewTextBoxColumn tipoCategoriaColumn = new DataGridViewTextBoxColumn();
                tipoCategoriaColumn.DataPropertyName = "nombreTipoCategoria";
                tipoCategoriaColumn.HeaderText = "Tipo";
                dgvCategorias.Columns.Add(tipoCategoriaColumn);



                //// Columna creador_id (uniqueidentifier)
                //DataGridViewTextBoxColumn creadorIdColumn = new DataGridViewTextBoxColumn();
                //creadorIdColumn.DataPropertyName = "CreadorId";
                //creadorIdColumn.HeaderText = "ID Creador";
                //dgvCategorias.Columns.Add(creadorIdColumn);



                // Columna aprobador_requerido (bit / bool)
                DataGridViewCheckBoxColumn aprobadorRequeridoColumn = new DataGridViewCheckBoxColumn();
                aprobadorRequeridoColumn.DataPropertyName = "AprobadorRequerido";
                aprobadorRequeridoColumn.HeaderText = "Aprobador Requerido";
                aprobadorRequeridoColumn.TrueValue = true;  // Valor verdadero para checkbox
                aprobadorRequeridoColumn.FalseValue = false; // Valor falso para checkbox
                aprobadorRequeridoColumn.ThreeState = false; // No permitir valores nulos
                dgvCategorias.Columns.Add(aprobadorRequeridoColumn);

                // Columna para el nombre de usuario del aprobador (nvarchar)
                DataGridViewTextBoxColumn usuarioAprobadorNombreColumn = new DataGridViewTextBoxColumn();
                usuarioAprobadorNombreColumn.DataPropertyName = "NombreUsuarioAprobador"; // Propiedad calculada
                usuarioAprobadorNombreColumn.HeaderText = "Nombre Usuario Aprobador";
                dgvCategorias.Columns.Add(usuarioAprobadorNombreColumn);


                // Columna fecha_creacion (datetime)
                DataGridViewTextBoxColumn fechaCreacionColumn = new DataGridViewTextBoxColumn();
                fechaCreacionColumn.DataPropertyName = "FechaCreacion";
                fechaCreacionColumn.HeaderText = "Fecha de Creación";
                fechaCreacionColumn.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"; // Formato opcional
                dgvCategorias.Columns.Add(fechaCreacionColumn);

                // Asignar la lista de categorías al DataSource
                dgvCategorias.DataSource = categoriaBLL.ListarCategorias();

                // Ajustar el tamaño de las columnas
                dgvCategorias.AutoResizeColumns();
            }
            catch (FormatException fe)
            {
                MessageBox.Show($"Se produjo un error de formato: {fe.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error general: {ex.Message}");
            }
        }





        private void dgvCategorias_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Error en columna {e.ColumnIndex} en la fila {e.RowIndex}. Detalles del error: {e.Exception.Message}");
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            
            CargarCategorias();
            cargarAprobador();
            cargarTiposCategoria();
            CargarDepartamentos();

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }
        private void CargarDepartamentos()
        {
            DepartamentoBLL departamentosBLL = new DepartamentoBLL();
            List<Departamento> departamentos = departamentosBLL.ListarDepartamentos();

            // Aquí puedes asignar la lista al ComboBox o a cualquier otro control
            cmbDepartamento.DataSource = departamentos;
            cmbDepartamento.DisplayMember = "Nombre"; // Asegúrate de que esta propiedad exista
            cmbDepartamento.ValueMember = "Id"; // Asegúrate de que esta propiedad exista
            cmbDepartamento.SelectedIndex = -1; // Desmarcar selección inicial
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                try
                {
                    var categoria = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    categoria.Nombre = txtNombre.Text;
                    categoria.Estado = new EstadosCategoria { Nombre = chkEstado.Checked ? "Activo" : "Inactivo" };

                    categoriaBLL.ActualizarCategoria(categoria);
                    MessageBox.Show("Categoría actualizada correctamente.");
                    CargarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la categoría: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                try
                {
                    int categoriaId = ((Categoria)dgvCategorias.CurrentRow.DataBoundItem).CategoriaId;
                    categoriaBLL.EliminarCategoria(categoriaId);
                    MessageBox.Show("Categoría eliminada correctamente.");
                    CargarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la categoría: " + ex.Message);
                }
            }
        }
        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                // Obtener la categoría seleccionada
                var categoria = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

                // Asignar el nombre de la categoría al TextBox
                txtNombre.Text = categoria.Nombre;
                txtDescripcion.Text = categoria.Descripcion;

                // Verificar el estado de la categoría y reflejarlo en el checkbox
                if (categoria.Estado != null)
                {
                    chkEstado.Checked = (categoria.Estado.EstadoCategoriaId == 1);
                }

                // Verificar si UsuarioAprobador es null antes de intentar acceder a su Id
                Guid? idAprobador = null; // Inicializar como null

                if (categoria.UsuarioAprobador != null)
                {
                    idAprobador = categoria.UsuarioAprobador.Id; // Asignar el Id si no es null
                }

                // Actualizar el estado de aprobación en el ComboBox
                cmbAprobacion.Text = idAprobador.HasValue ? "SI" : "NO";

                // Comparar con los usuarios cargados
                if (idAprobador.HasValue)
                {
                    if (usuariosMap.ContainsKey(idAprobador.Value))
                    {
                        cmbAprobador.Text = usuariosMap[idAprobador.Value]; // Seleccionar el usuario en el ComboBox
                    }
                    else
                    {
                        cmbAprobador.SelectedIndex = -1; // Desmarcar si no hay coincidencia
                    }
                }
                else
                {
                    // Si no hay un aprobador, desmarcar el ComboBox
                    cmbAprobador.SelectedIndex = -1; // Desmarcar el ComboBox
                }

                // Lógica para seleccionar el tipo de categoría
                if (categoria.tipoCategoria.Id != null) // Asegúrate de que TipoId sea un valor válido
                {
                    cmbTiposCategoria.SelectedValue = categoria.tipoCategoria.Id; // Seleccionar el tipo en el ComboBox
                }
                else
                {
                    cmbTiposCategoria.SelectedIndex = -1; // Desmarcar si no hay un tipo válido
                }

                // Lógica para seleccionar el departamento
                if (categoria.Departamento != null) // Verificar si el departamento está asignado
                {
                    cmbDepartamento.SelectedValue = categoria.Departamento.Id; // Seleccionar el departamento en el ComboBox
                }
                else
                {
                    cmbDepartamento.SelectedIndex = -1; // Desmarcar si no hay un departamento
                }
            }
        }






        private void btnGuardar_Click(object sender, EventArgs e)
        { 
        
        }

        private void dgvCampos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private Dictionary<Guid, string> usuariosMap = new Dictionary<Guid, string>();

        private void cargarAprobador()
        {
            // Asumiendo que Usuario tiene propiedades Id (GUID), Nombre y Apellido
            List<Usuario> usuarios = usuarioBLL.ListarTodosLosUsuarios();
            List<string> nombresYApellidos = new List<string>();

            foreach (var usuario in usuarios)
            {
                nombresYApellidos.Add($"{usuario.Apellido}, {usuario.Nombre}");
                usuariosMap[usuario.Id] = $"{usuario.Apellido}, {usuario.Nombre}"; // Mapear ID a nombre completo
            }

            // Asignar la lista al ComboBox
            cmbAprobador.DataSource = nombresYApellidos;
            cmbAprobador.SelectedIndex = -1; // Opcional: Desmarcar selección inicial
        }


        private void cargarTiposCategoria()
        {
            TiposCategoriaBLL tiposCategoriaBLL = new TiposCategoriaBLL();
            List<TipoCategoria> tiposCategorias = tiposCategoriaBLL.listarCategorias();

            // Configurar el ComboBox
            cmbTiposCategoria.DataSource = tiposCategorias; // Asignar la lista como fuente de datos
            cmbTiposCategoria.DisplayMember = "Nombre"; // Propiedad para mostrar en el ComboBox
            cmbTiposCategoria.ValueMember = "Id"; // Propiedad que se usará como valor (asegúrate de que sea el nombre correcto)
            cmbTiposCategoria.SelectedIndex = -1; // Desmarcar selección inicial
        }


        private void cmbAprobador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}