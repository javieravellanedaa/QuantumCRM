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
using BE.Composite;
using BLL;
using SERVICIOS;

namespace UI
{

    public partial class frmFamiliaPermisos : Form
    {
        Familia seleccion;
        PermisoBLL repo;
    
        private readonly EventManagerService _eventManagerService;

        // Guarda temporalmente el Id del último idioma agregado (opcional, si deseas otra lógica)
        private Guid _idiomaRecienCreadoId;


        public frmFamiliaPermisos(EventManagerService eventManagerService)
        {
            _eventManagerService = eventManagerService;
            InitializeComponent();

            // Configuración visual
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(96, 116, 239);

            // Obtiene el usuario desde la sesión global
            BE.Usuario usuarioActual = SingletonSesion.Instancia.Sesion.Usuario as BE.Usuario;
            if (usuarioActual != null)
            {
                repo = new PermisoBLL();
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.", "Error de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();  // Cierra el formulario si no hay sesión
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFamiliaPatente_Load(object sender, EventArgs e)
        {
            LlenarPatentesFamilias();
        }

        private void LlenarPatentesFamilias()
        {
            this.cboPatentes.DataSource = repo.GetAllPatentes();
            this.cboPatentes.DisplayMember = "nombre";
            this.cboFamilias.DataSource = repo.GetAllFamilias();
            cboFamilias2.DataSource = repo.GetAllFamilias().FindAll(familia => familia.Id != ((Familia)cboFamilias.SelectedItem).Id);
        }


        void MostrarFamilia(bool init)
        {
            if (seleccion == null) return;

            if (init)
            {
                // Limpias hijos locales, por seguridad
                seleccion.VaciarHijos();

                // Llamas a FillFamilyComponents para poblar la jerarquía
                repo.FillFamilyComponents(seleccion);
            }

            // Render en el treeview
            treeConfigurarFamilia.Nodes.Clear();
            TreeNode root = new TreeNode(seleccion.Nombre);
            root.Tag = seleccion;
            treeConfigurarFamilia.Nodes.Add(root);

            foreach (var item in seleccion.Hijos)
            {
                MostrarEnTreeView(root, item);
            }
            treeConfigurarFamilia.ExpandAll();
        }



        void MostrarEnTreeView(TreeNode tn, Componente c)
        {
            TreeNode n = new TreeNode(c.Nombre);
            n.Tag = c;
            tn.Nodes.Add(n);

            // Cargar los hijos correctamente
            if (c.Hijos != null && c.Hijos.Count > 0)
            {
                foreach (var item in c.Hijos)
                {
                    MostrarEnTreeView(n, item);
                }
            }
        }


        private void cmdAgregarPatente_Click(object sender, EventArgs e)
        {
            if (seleccion != null)
            {
                var patente = (Patente)cboPatentes.SelectedItem;
                if (patente != null)
                {
                    //var esta = repo.Existe(seleccion, patente.Id);
                    var esta = repo.ExisteEnNivelActual(seleccion, patente.Id);
                    if (esta)
                        MessageBox.Show("ya existe la patente indicada");
                    else
                    {
                        {
                            //seleccion.AgregarHijo(patente);
                            seleccion.AgregarHijoFamilyRaiz(patente);
                            MostrarFamilia(false);
                        }
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (seleccion != null)
            {
                Patente patente = (Patente)cboPatentes.SelectedItem;
                if (patente != null)
                {
                    if (repo.Existe(seleccion, patente.Id))
                    {
                        seleccion.EliminarHijo(seleccion.Hijos.Find(item => patente.Id == item.Id));
                        MostrarFamilia(false);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.txtNombreFamilia.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre para la familia");
                return;
            }
            Familia p = new Familia()
            {
                Nombre = this.txtNombreFamilia.Text

            };


            repo.GuardarComponente(p, true);
            LlenarPatentesFamilias();
            MessageBox.Show("Familia guardada correctamente");
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            if (seleccion == null)
            {
                MessageBox.Show("Debe seleccionar una familia antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Familia familia = cboFamilias2.SelectedItem as Familia;
            if (familia == null)
            {
                MessageBox.Show("Debe seleccionar una familia válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (repo.Existe(seleccion, familia.Id))
            {
                MessageBox.Show("Ya existe la familia indicada en esta relación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            repo.FillFamilyComponents(familia);

            // Verificar si genera un ciclo antes de agregar
            if (seleccion.EsCiclo(familia))
            {
                MessageBox.Show("No se puede agregar esta familia porque genera un ciclo en la jerarquía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            seleccion.AgregarHijo(familia);
            MostrarFamilia(false);
        }


        private void cmdAgregarFamilia_Click(object sender, EventArgs e)
        {
            if (seleccion != null)
            {
                var familia = (Familia)cboFamilias.SelectedItem;
                if (familia != null)
                {
                    try
                    {
                        if (repo.Existe(seleccion, familia.Id))
                        {
                            MessageBox.Show("Ya existe la familia indicada en esta relación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Asegurar que la familia tenga sus hijos cargados antes de agregarla
                            repo.FillFamilyComponents(familia);

                            // Verificar si genera un ciclo antes de agregar
                            if (seleccion.EsCiclo(familia))
                            {
                                MessageBox.Show("No se puede agregar esta familia porque genera un ciclo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // Detiene la ejecución sin intentar agregar
                            }

                            seleccion.AgregarHijo(familia);

                            try
                            {
                                repo.GuardarFamilia(seleccion);
                                MessageBox.Show("Familia guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MostrarFamilia(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al guardar la familia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }





        private void cmdGuardarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                repo.GuardarFamilia(seleccion);
                MessageBox.Show("Familia guardada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la familia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cboPatentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboPatentes.SelectedItem != null)
            {
                Patente patent = (Patente)this.cboPatentes.SelectedItem;
                TxtDescription.Text = patent.Permiso;
            }
        }

        private void cmdSeleccionar_Click_1(object sender, EventArgs e)
        {
            var tmp = (Familia)this.cboFamilias.SelectedItem;
            seleccion = new Familia();
            seleccion.Id = tmp.Id;
            seleccion.Nombre = tmp.Nombre;

            MostrarFamilia(true);
        }

        private void eliminarFamiliaBtn_Click(object sender, EventArgs e)
        {
            if (seleccion != null)
            {
                Familia familia = (Familia)cboFamilias2.SelectedItem;
                if (familia != null)
                {
                    if (repo.Existe(seleccion, familia.Id))
                    {
                        seleccion.EliminarHijo(seleccion.Hijos.Find(item => familia.Id == item.Id));
                        MostrarFamilia(false);
                    }
                }
            }
        }

        private void cboFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFamilias2.DataSource = repo.GetAllFamilias().FindAll(familia => familia.Id != ((Familia)cboFamilias.SelectedItem).Id);
            Familia tmp = (Familia)this.cboFamilias.SelectedItem;
            seleccion = new Familia();
            seleccion.Id = tmp.Id;
            seleccion.Nombre = tmp.Nombre;

            MostrarFamilia(true);
        }
    }
}