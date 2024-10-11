using BE;
using BE.Composite;
using BLL;
using SERVICIOS;  // Asumiendo que SingletonSesion está aquí
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class frmGestorPermiso : Form
    {
        Familia seleccion;
        PermisoBLL repo;
        public frmGestorPermiso() 
        {
            
            InitializeComponent();
           
            
            // Obtiene el usuario desde la sesión global
            BE.Usuario usuarioActual = SingletonSesion.Instancia.Usuario as BE.Usuario;
            if (usuarioActual != null)
            {
                
                repo = new PermisoBLL();
                this.cboPermisos.DataSource = repo.GetAllPermission();
                
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.", "Error de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();  // Cierra el formulario si no hay sesión
            }
        }
        private void LlenarPatentesFamilias()
        {
           
            this.cboPatentes.DataSource = repo.GetAllPatentes();
            this.cboFamilias.DataSource = repo.GetAllFamilias();
        }

        private void frmGestorPermiso_Load(object sender, EventArgs e)
        {
            LlenarPatentesFamilias();
        }

        private void btnGuardarPatente_Click_1(object sender, EventArgs e)
        {
            if (this.txtNombrePatente.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre para la patente");
                return;
            }

            Patente p = new Patente()
            {
                Nombre = this.txtNombrePatente.Text,
                Permiso = this.cboPermisos.SelectedItem.ToString()

            };

            repo.GuardarComponente(p, false);
            LlenarPatentesFamilias();

            MessageBox.Show("Patente guardada correctamente");
        }

        private void button1_Click(object sender, EventArgs e)
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

        void MostrarFamilia(bool init)
        {
            if (seleccion == null) return;


            IList<Componente> flia = null;
            if (init)
            {
                //traigo los hijos de la base
                flia = repo.GetAll(seleccion.Id.ToString());


                foreach (var i in flia)
                    seleccion.AgregarHijo(i);
            }
            else
            {
                flia = seleccion.Hijos;
            }

            this.treeConfigurarFamilia.Nodes.Clear();

            TreeNode root = new TreeNode(seleccion.Nombre);
            root.Tag = seleccion;
            this.treeConfigurarFamilia.Nodes.Add(root);

            foreach (var item in flia)
            {
                MostrarEnTreeView(root, item);
            }

            treeConfigurarFamilia.ExpandAll();
        }



        private void cmdAgregarPatente_Click_1(object sender, EventArgs e)
        {
            if (seleccion != null)
            {
                var patente = (Patente)cboPatentes.SelectedItem;
                if (patente != null)
                {
                    var esta = repo.Existe(seleccion, patente.Id);
                    if (esta)
                        MessageBox.Show("ya exsite la patente indicada");
                    else
                    {

                        {
                            seleccion.AgregarHijo(patente);
                            MostrarFamilia(false);
                        }
                    }
                }
            }

        }



        private void cmdGuardarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                repo.GuardarFamilia(seleccion);
                MessageBox.Show("Familia guardada correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar la familia");
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
        void MostrarEnTreeView(TreeNode tn, Componente c)
        {
            TreeNode n = new TreeNode(c.Nombre);
            tn.Tag = c;
            tn.Nodes.Add(n);
            if (c.Hijos != null)
                foreach (var item in c.Hijos)
                {
                    MostrarEnTreeView(n, item);
                }

        }

        private void cmdAgregarFamilia_Click_1(object sender, EventArgs e)
        {
            if (seleccion != null)
            {
                var familia = (Familia)cboFamilias.SelectedItem;
                if (familia != null)
                {

                    var esta = repo.Existe(seleccion, familia.Id);
                    if (esta)
                        MessageBox.Show("ya exsite la familia indicada");
                    else
                    {

                        repo.FillFamilyComponents(familia);
                        seleccion.AgregarHijo(familia);
                        MostrarFamilia(false);
                    }


                }
            }
        }
    }
    
}
