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
using BE;
using INTERFACES;
using SERVICIOS;

namespace UI
{
    public partial class frmPpal : Form, IIdiomaObserver
    {
        BLL.UsuarioBLL _bllUsuarios;
        IdiomaBLL _idiomaBLL;
        public frmPpal()
        {
            InitializeComponent();
            ValidarForm();
            _bllUsuarios = new BLL.UsuarioBLL();

            _idiomaBLL = new IdiomaBLL();
            _idiomaBLL.IdiomaAgregado += CargarIdiomas;

            AsignarEtiquetasMenu();
            SingletonSesion.Instancia.SuscribirObservador(this);

            var idiomaDefault = new BLL.IdiomaBLL().ObtenerIdiomaDefault();
            SingletonSesion.Instancia.CambiarIdioma(idiomaDefault);

            Traducir(SingletonSesion.Instancia.Idioma);

            CargarIdiomas();


            // Calcular el 70% del tamaño de la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = (int)(screenWidth * 0.7);
            this.Height = (int)(screenHeight * 0.7);

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((screenWidth - this.Width) / 2, (screenHeight - this.Height) / 2);
        }
        private void AsignarEtiquetasMenu()
        {
            ////perfil
            this.verPerfilMenuItem.Tag = "menu.verPerfil";
            this.iniciarSesiónToolStripMenuItem.Tag = "menu.iniciarSesion";
            this.cerrarSesiónToolStripMenuItem.Tag = "menu.cerrarSesion";


            //gestores
            this.menuGestores.Tag = "menu.gestores";
            this.gestorDePermisosToolStripMenuItem.Tag = "menu.gestorPermisos";

            this.gestorDeGruposToolStripMenuItem .Tag = "menu.gestorGrupos";
         

            // Empleados
            this.menuEmpleados.Tag = "menu.empleados";
            this.verToolStripMenuItem .Tag = "menu.ver";
            this.agregarToolStripMenuItem.Tag = "menu.agregar";
            this.modificarToolStripMenuItem .Tag = "menu.modificar";

            // Novedades

            this.menuNovedades.Tag = "menu.novedades";
            this.verToolStripMenuItem1.Tag = "menu.ver";
            //Estadisticas

            this.estadisticasToolStripMenuItem .Tag = "menu.estadisticas";
            this.tableroGeneralToolStripMenuItem .Tag = "menu.tableroGeneral";
            this.misTicketsToolStripMenuItem .Tag = "menu.misTickets";

            //Pedidos

            this.pedidosToolStripMenuItem .Tag = "menu.pedidos";
            this.crearPedidoToolStripMenuItem .Tag = "menu.crearPedido";
            this.buscarToolStripMenuItem .Tag = "menu.buscar";

            //inventario 

            this.inventarioToolStripMenuItem .Tag = "menu.inventario";
            this.inventarioGeneralToolStripMenuItem .Tag = "menu.inventarioGeneral";
            this.inventarioProyectoToolStripMenuItem.Tag = "menu.inventarioProyecto";

            //ayuda 
            this.ayudaToolStripMenuItem.Tag ="menu.ayuda";
            // Idioma
            this.idiomaToolStripMenuItem .Tag = "menu.idioma";
            this.cambiarToolStripMenuItem.Tag = "menu.administrar";
            this.actualToolStripMenuItem.Tag = "menu.actual";



        }
        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }

        public void Traducir(IIdioma idioma = null)

        {
            var traduccionBLL = new TraduccionBLL();
            var idiomaBLL = new IdiomaBLL();

            var traducciones = new BLL.TraduccionBLL().ObtenerTraducciones(idioma);
            // Obtener las traducciones del idioma por defecto (español)
            var idiomaDefault = idiomaBLL.ObtenerIdiomaPorNombre("Español");
            var traduccionesDefault = traduccionBLL.ObtenerTraducciones(idiomaDefault);
            foreach (var key in traducciones.Keys.ToList())
            {
                if (string.IsNullOrWhiteSpace(traducciones[key].Texto))
                {
                    if (traduccionesDefault.ContainsKey(key))
                    {
                        traducciones[key].Texto = traduccionesDefault[key].Texto;
                    }
                }
            }
            foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
            {
                TraducirMenuItem(menuItem, traducciones);
            }

            this.toolStripStatusLabel1.Text = traducciones.ContainsKey("menu.usuario") ? traducciones["menu.usuario"].Texto : "Usuario";
        }

        private void TraducirMenuItem(ToolStripMenuItem menuItem, IDictionary<string, ITraduccion> traducciones)
        {
            if (menuItem.Tag != null && traducciones.ContainsKey(menuItem.Tag.ToString()))
            {
                menuItem.Text = traducciones[menuItem.Tag.ToString()].Texto;
            }

            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem)
                {
                    TraducirMenuItem((ToolStripMenuItem)subItem, traducciones);
                }
            }
        }


        public void ValidarForm()
        {
            this.iniciarSesiónToolStripMenuItem.Enabled = !SingletonSesion.Instancia.IsLogged();
            this.cerrarSesiónToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsLogged();
            //this.menuEmpleados.Enabled = SingletonSesion.Instancia.IsLogged();
            this.menuGestores.Enabled = SingletonSesion.Instancia.IsLogged();
            //this.menuNovedades.Enabled = SingletonSesion.Instancia.IsLogged();
            this.verPerfilMenuItem.Enabled = SingletonSesion.Instancia.IsLogged();

            // Desactivar menús principales
            this.menuEmpleados.Enabled = false;
            this.menuGestores.Enabled = false;
            this.menuNovedades.Enabled = false;

            this.pedidosToolStripMenuItem.Enabled = false;
            this.buscarToolStripMenuItem.Enabled = false;
            this.cambiarToolStripMenuItem.Enabled = false;
            this.crearCamposToolStripMenuItem.Enabled = false;
            this.crearCategoriasToolStripMenuItem.Enabled = false;
            this.crearPedidoToolStripMenuItem.Enabled = false;  
            this.estadisticasToolStripMenuItem .Enabled = false;
            this.inventarioToolStripMenuItem.Enabled = false;
            this.inventarioGeneralToolStripMenuItem.Enabled = false;
            this.inventarioProyectoToolStripMenuItem.Enabled = false;
            this.gestorDeGruposToolStripMenuItem.Enabled = false;
            this.gestorDePermisosToolStripMenuItem.Enabled = false;
            this.misTicketsToolStripMenuItem.Enabled = false;
            this.tableroGeneralToolStripMenuItem.Enabled = false;
            this.verToolStripMenuItem.Enabled = false;
            this.verToolStripMenuItem1.Enabled = false;
            this.agregarToolStripMenuItem.Enabled = false;
            this.modificarToolStripMenuItem.Enabled = false;
            this.actualToolStripMenuItem.Enabled = false;
            this.ayudaToolStripMenuItem.Enabled = false;
            
            // Si hay más menús o submenús, sigue el mismo patrón


            if (SingletonSesion.Instancia.IsLogged())
            {
                this.toolStripLabelLoginUser.Text = SingletonSesion.Instancia.Usuario.Email;
            }
            else
            {
                this.toolStripLabelLoginUser.Text = "[Sesión no iniciada]";
            }

            //////
            //this.mnuGestorPermisos.Enabled = SingletonSesion.Instancia.IsInRole(TipoPermiso.GestorPermiso);
            //this.mnuGestorUsuarios.Enabled = SingletonSesion.Instancia.IsInRole(TipoPermiso.GestorUsuario);
            this.menuNovedades.Enabled = SingletonSesion.Instancia.IsInRole(15); // paso el id del permiso
            this.menuEmpleados.Enabled = SingletonSesion.Instancia.IsInRole(15);
            this.menuGestores.Enabled = SingletonSesion.Instancia.IsInRole(15);
            if (SingletonSesion.Instancia.IsInRole(15) || SingletonSesion.Instancia.IsInRole(16) || SingletonSesion.Instancia.IsInRole(15)) 
            {
                this.pedidosToolStripMenuItem.Enabled = true;
                
               
            }
            if (SingletonSesion.Instancia.IsInRole(18) || SingletonSesion.Instancia.IsInRole(15))
            {
                this.menuGestores.Enabled = true;
            }

            


            this.crearCamposToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsInRole(15);
            this.crearCategoriasToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsInRole(16);
            this.gestorDeGruposToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsInRole(18);
            this.gestorDePermisosToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsInRole(18);


            this.crearCamposToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsInRole(15);
            this.crearCategoriasToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsInRole(15);
            this.gestorDeGruposToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsInRole(15);
            this.gestorDePermisosToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsInRole(15);
            this.cambiarToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsInRole(15);
            this.actualToolStripMenuItem.Enabled = SingletonSesion.Instancia.IsInRole(15);


        }


        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.MdiParent = this;
            int x = (this.ClientSize.Width - frm.Width) / 2;
            int y = (this.ClientSize.Height - frm.Height) / 2;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(x, y);
            frm.Show();
        }

        private void frmPpal_Load(object sender, EventArgs e)
        {
            Traducir();
        }

        private void CargarIdiomas()
        {
            var idiomas = _idiomaBLL.ObtenerIdiomas();
            actualToolStripMenuItem.DropDownItems.Clear();

            foreach (var idioma in idiomas)
            {
                var menuItem = new ToolStripMenuItem(idioma.Nombre);
                menuItem.Tag = idioma;
                actualToolStripMenuItem.DropDownItems.Add(menuItem);
            }

            var idiomaEspañol = idiomas.FirstOrDefault(i => i.Nombre.Equals("Español", StringComparison.OrdinalIgnoreCase));
            if (idiomaEspañol != null)
            {
                Traducir(idiomaEspañol);
                SingletonSesion.Instancia.CambiarIdioma(idiomaEspañol);
            }
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro?", "Confirme", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _bllUsuarios.Logout();
                ValidarForm();
            }
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void baToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestorDePermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestorPermiso frmGestorPermiso = new frmGestorPermiso();
            frmGestorPermiso.MdiParent = this;
            int x = (this.ClientSize.Width - frmGestorPermiso.Width) / 2;
            int y = (this.ClientSize.Height - frmGestorPermiso.Height) / 2;
            frmGestorPermiso.StartPosition = FormStartPosition.Manual;
            frmGestorPermiso.Location = new Point(x, y);
            frmGestorPermiso.Show();

        }


        private void toolStripComboBox2_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void idiomaToolStripMenuItem_TextChanged(object sender, EventArgs e)
        {

        }


        private void gestorDeGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frmUsuarios = new frmUsuarios();
            frmUsuarios.MdiParent = this;
            int x = (this.ClientSize.Width - frmUsuarios.Width) / 2;
            int y = (this.ClientSize.Height - frmUsuarios.Height) / 2;
            frmUsuarios.StartPosition = FormStartPosition.Manual;
            frmUsuarios.Location = new Point(x, y);
            frmUsuarios.Show();
        }

        private void verPerfilMenuItem_Click(object sender, EventArgs e)
        {
            frmPerfil frm = new frmPerfil();
            frm.MdiParent = this;
            int x = (this.ClientSize.Width - frm.Width) / 2;
            int y = (this.ClientSize.Height - frm.Height) / 2;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(x, y);
            frm.Show();
        }

        private void cambiarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAdministrarIdioma frmAdministrarIdioma = new frmAdministrarIdioma(_idiomaBLL);
            frmAdministrarIdioma.MdiParent = this;
            int x = (this.ClientSize.Width - frmAdministrarIdioma.Width) / 2;
            int y = (this.ClientSize.Height - frmAdministrarIdioma.Height) / 2;
            frmAdministrarIdioma.StartPosition = FormStartPosition.Manual;
            frmAdministrarIdioma.Location = new Point(x, y);
            frmAdministrarIdioma.Show();
        }

        private void actualToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void actualToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            var menuItem = e.ClickedItem as ToolStripMenuItem;
            if (menuItem != null)
            {
                var idioma = menuItem.Tag as IIdioma;
                if (idioma != null)
                {
                    Traducir(idioma);
                    SingletonSesion.Instancia.CambiarIdioma(idioma);
                }
            }
        }

        private void crearCamposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCampo frmCampo = new frmCampo();
            frmCampo.MdiParent = this;
            int x = (this.ClientSize.Width - frmCampo.Width) / 2;
            int y = (this.ClientSize.Height - frmCampo.Height) / 2;
            frmCampo.StartPosition = FormStartPosition.Manual;
            frmCampo.Location = new Point(x, y);
            frmCampo.Show();
        }

        private void crearCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias frmCategorias = new frmCategorias();
            frmCategorias.MdiParent = this;
            int x = (this.ClientSize.Width - frmCategorias.Width) / 2;
            int y = (this.ClientSize.Height - frmCategorias.Height) / 2;
            frmCategorias.StartPosition = FormStartPosition.Manual;
            frmCategorias.Location = new Point(x, y);
            frmCategorias.Show();
        }

        private void crearPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearTicket frmTicke = new CrearTicket();
            frmTicke.MdiParent = this;
            int x = (this.ClientSize.Width - frmTicke.Width) / 2;
            int y = (this.ClientSize.Height - frmTicke.Height) / 2;
            frmTicke.StartPosition = FormStartPosition.Manual;
            frmTicke.Location = new Point(x, y);
            frmTicke.Show();
        }
    }
}
