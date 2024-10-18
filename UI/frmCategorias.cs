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

        public frmCategorias()
        {
            InitializeComponent();
            categoriaBLL = new CategoriaBLL();


           
            
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

                // Columna group_id (int)
                DataGridViewTextBoxColumn groupIdColumn = new DataGridViewTextBoxColumn();
                groupIdColumn.DataPropertyName = "GroupId";
                groupIdColumn.HeaderText = "ID Grupo";
                dgvCategorias.Columns.Add(groupIdColumn);

                // Columna tipo_id (int)
                DataGridViewTextBoxColumn tipoIdColumn = new DataGridViewTextBoxColumn();
                tipoIdColumn.DataPropertyName = "TipoId";
                tipoIdColumn.HeaderText = "ID Tipo";
                dgvCategorias.Columns.Add(tipoIdColumn);

                // Columna estado_categoria_id (int)
                DataGridViewTextBoxColumn estadoCategoriaIdColumn = new DataGridViewTextBoxColumn();
                estadoCategoriaIdColumn.DataPropertyName = "EstadoCategoriaId";
                estadoCategoriaIdColumn.HeaderText = "ID Estado Categoría";
                dgvCategorias.Columns.Add(estadoCategoriaIdColumn);

                // Columna fecha_creacion (datetime)
                DataGridViewTextBoxColumn fechaCreacionColumn = new DataGridViewTextBoxColumn();
                fechaCreacionColumn.DataPropertyName = "FechaCreacion";
                fechaCreacionColumn.HeaderText = "Fecha de Creación";
                fechaCreacionColumn.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"; // Formato opcional
                dgvCategorias.Columns.Add(fechaCreacionColumn);

                // Columna creador_id (uniqueidentifier)
                DataGridViewTextBoxColumn creadorIdColumn = new DataGridViewTextBoxColumn();
                creadorIdColumn.DataPropertyName = "CreadorId";
                creadorIdColumn.HeaderText = "ID Creador";
                dgvCategorias.Columns.Add(creadorIdColumn);

                // Columna descripcion (nvarchar)
                DataGridViewTextBoxColumn descripcionColumn = new DataGridViewTextBoxColumn();
                descripcionColumn.DataPropertyName = "Descripcion";
                descripcionColumn.HeaderText = "Descripción";
                dgvCategorias.Columns.Add(descripcionColumn);

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
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
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

                // Verificar el estado de la categoría y reflejarlo en el checkbox
                if (categoria.Estado != null)
                {
                    chkEstado.Checked = categoria.Estado.Nombre == "Activo";
                }
                else
                {
                    chkEstado.Checked = false;
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
    }
}