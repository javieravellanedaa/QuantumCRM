using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using INTERFACES;
using SERVICIOS;
using BLL;
using BE;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using UI.Design;

namespace UI
{
    public partial class frmPpalCliente: Form, IEventListener
    {

        BLL.UsuarioBLL _bllUsuarios;
        BLL.IdiomaBLL _idiomaBLL;
        BLL.TraduccionBLL _traduccionBLL = new TraduccionBLL();
        private IUsuario _usuario;
        private int borderSize = 2;
        private Size formSize;
        private readonly EventManagerService _eventManagerService = new EventManagerService();




        public List<Etiqueta> etiquetas = new List<Etiqueta>();
        public frmPpalCliente()
        {

            InitializeComponent();
            if (SingletonSesion.Instancia.IsLogged())
            {
                etiquetas.AddRange(RecopilarEtiquetas(this));
                etiquetas.AddRange(ObtenerEtiquetasDeDropDownMenu(dropDownMenu1, this.Name));
                etiquetas.AddRange(ObtenerEtiquetasDeDropDownMenu(dropDownMenu2, this.Name));

                _usuario = SingletonSesion.Instancia.Usuario;
                icbApellidoNombre.Text = _usuario.NombreUsuario;
                SingletonSesion.Instancia.SuscribirEvento("CambiarIdioma", this);
                //var idiomaDefault = new BLL.IdiomaBLL().ObtenerIdiomaDefault();
                //SingletonSesion.Instancia.CambiarIdioma(idiomaDefault);
               

            }
            else
            {
                MessageBox.Show("Sesión no iniciada");
            }
            ColapseMenu();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(96, 116, 239); // border color
            _bllUsuarios = new BLL.UsuarioBLL();
            BLL.TraduccionBLL _bllTraduccion = new BLL.TraduccionBLL();
            _bllTraduccion.AgregarEtiquetasBulk(etiquetas);


        }
        // Drag Form 

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void frmPpalNew_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);


        }



        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;

            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          

                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);

                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }
        private void PanelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmPpalNew_Load(object sender, EventArgs e)
        {

            formSize = this.ClientSize;
            dropDownMenu1.IsMainMenu = true;
            dropDownMenu2.IsMainMenu = true;

        }

        private void PanelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PanelTitleBar_Resize(object sender, EventArgs e)
        {

        }
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void frmPpalNew_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximaze_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)

                this.WindowState = FormWindowState.Maximized;

            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Guardar el timestamp del último registro antes de salir
            GuardarUltimoRegistro();

            // Confirmar la salida con un mensaje
            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea salir?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Si el usuario confirma, cerrar la aplicación
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Método para guardar el último registro
        private void GuardarUltimoRegistro()
        {
            // Lógica para guardar el timestamp del último registro
            // Ejemplo: últimoRegistro = DateTime.Now;
        }
        private void ColapseMenu()
        {

            if (this.PanelMenu.Width > 100)
            {
                PanelMenu.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in PanelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);

                }

            }
            else
            {

                PanelMenu.Width = 230;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in PanelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(10, 0, 0, 0);

                }

            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ColapseMenu();
        }

        private void iconBtnGeneral_Click(object sender, EventArgs e)
        {
            dropDownMenu1.Show(iconBtnGeneral, iconBtnGeneral.Width, 0);
        }

        private void iconBtnDepartamentos_Click(object sender, EventArgs e)
        {

        }

        private void lblApellidoNombre_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dropDownMenu2.Show(pictureBox1, 0, pictureBox1.Height);


        }
        private void FormularioSecundarioCerrado(object sender, EventArgs e)
        {
            // Cambia el label cuando el formulario secundario se cierra
            lblTitulo.Text = "Seleccione una opción";
        }

        private void CargarFormularioEnPanel(Form formulario)
        {
            if (formulario is frmPerfil perfilForm)
            {
                _eventManagerService.Subscribe("FormularioCerrado", this);

            }
            PanelDesktop.Controls.Clear();
            formulario.TopLevel = false;

            PanelDesktop.Controls.Add(formulario);
            formulario.Dock = DockStyle.Fill;
            lblTitulo.Text = formulario.Text;

            formulario.Show();
        }

        private void datosPersonalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPerfil frmPerfil = new frmPerfil();
            CargarFormularioEnPanel(frmPerfil);
            if (frmPerfil.IsDisposed)
            {
                lblTitulo.Text = "Seleccione una opcion";
            }


        }

        private void cambiarRolToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // Verificar si ya existen elementos hijos, para evitar duplicados
            if (cambiarRolToolStripMenuItem.DropDownItems.Count == 0)
            {
                // Verificar si hay roles en la lista y crear hijos dinámicamente
                if (SingletonSesion.Instancia.Usuario.NombreDeLosRoles != null)
                {
                    foreach (var item in SingletonSesion.Instancia.Usuario.NombreDeLosRoles)
                    {
                        // Crear un nuevo ToolStripMenuItem para cada rol
                        ToolStripMenuItem rolMenuItem = new ToolStripMenuItem(item);

                        // Agregar el nuevo ToolStripMenuItem como hijo del ToolStripMenuItem padre
                        cambiarRolToolStripMenuItem.DropDownItems.Add(rolMenuItem);

                        // Agregar un evento de clic a cada item hijo
                        rolMenuItem.Click += (s, args) =>
                        {
                            // Verificar si el rol seleccionado empieza con "Administrador"
                            if (item.StartsWith("Cliente"))
                            {
                                MessageBox.Show($"Usted ya se encuentra en el rol {item}");
                            }
                            else
                            {
                                // Lógica para cambiar de rol si es diferente al actual
                                MessageBox.Show($"Rol seleccionado: {item}");
                                if (item.StartsWith("Administrador"))
                                {
                                    this.Close();
                                    frmPpalAdmin frm = new frmPpalAdmin();

                                    frm.Show();

                                }
                                else if (item.StartsWith("Tecnico"))
                                {
                                    this.Close();
                                    frmPpalTecnico frm = new frmPpalTecnico();
                                    frm.Show();
                                }

                            }
                        };
                    }
                }
            }
        }


        public void Update(string eventType, object data)
        {
            if (eventType == "FormularioCerrado")
            {
                lblTitulo.Text = "Seleccione una opción";
            }
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        public List<Etiqueta> RecopilarEtiquetas(Form formulario)
        {
            var etiquetas = new List<Etiqueta>();

            void AgregarEtiquetas(Control control)
            {
                if (control.Text.Length > 0)
                {
                    etiquetas.Add(new Etiqueta
                    {
                        Id = Guid.NewGuid(),
                        Nombre = control.Name,
                        Form = formulario.Name,
                        Texto = control.Text // Texto visible al usuario
                    });
                }

                // Recorre controles hijos
                foreach (Control childControl in control.Controls)
                {
                    AgregarEtiquetas(childControl);
                }
            }

            // Inicia la recopilación de controles desde el formulario
            foreach (Control control in formulario.Controls)
            {
                AgregarEtiquetas(control);
            }

            return etiquetas;
        }
        private List<Etiqueta> ObtenerEtiquetasDeDropDownMenu(UI.Design.DropDownMenu dropDownMenu, string formName)
        {
            var etiquetas = new List<Etiqueta>();

            void AgregarEtiquetasDeMenu(ToolStripMenuItem menuItem)
            {
                // Agregar una nueva Etiqueta para el menú actual
                etiquetas.Add(new Etiqueta
                {
                    Id = Guid.NewGuid(),
                    Nombre = menuItem.Name,
                    Form = formName,
                    Texto = menuItem.Text // Texto visible al usuario
                });

                // Recorrer submenús, si existen
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    if (subItem is ToolStripMenuItem subMenuItem)
                    {
                        AgregarEtiquetasDeMenu(subMenuItem); // Llamada recursiva para submenús
                    }
                }
            }

            // Recorremos todos los elementos del DropDownMenu
            foreach (ToolStripItem item in dropDownMenu.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    AgregarEtiquetasDeMenu(menuItem);
                }
            }

            return etiquetas;
        }


        public void TraducirFormulario(Form formulario, IIdioma idiomaSeleccionado)
        {
            // Obtener el diccionario de traducciones en el idioma seleccionado
           
            IDictionary<string, ITraduccion> traducciones = _traduccionBLL.ObtenerTraducciones(idiomaSeleccionado);

            // Método recursivo para aplicar traducción a cada control
            void AplicarTraduccion(Control control)
            {
                // Crear la clave en formato "formulario.control"
                string clave = $"{formulario.Name}.{control.Name}";

                // Buscar la traducción para el control actual
                if (traducciones.ContainsKey(clave))
                {
                    control.Text = traducciones[clave].Texto; // Asignar el texto traducido
                }

                // Recorre controles hijos para aplicar traducción
                foreach (Control childControl in control.Controls)
                {
                    AplicarTraduccion(childControl);
                }
            }

            // Aplicar traducción a cada control en el formulario
            foreach (Control control in formulario.Controls)
            {
                AplicarTraduccion(control);
            }
        }

        public void TraducirDropDownMenu(UI.Design.DropDownMenu dropDownMenu, string formName, IDictionary<string, ITraduccion> traducciones)
        {
            // Método recursivo para traducir cada elemento del menú
            void AplicarTraduccionMenuItem(ToolStripMenuItem menuItem)
            {
                // Crear la clave en formato "formulario.menuItem"
                string clave = $"{formName}.{menuItem.Name}";

                // Buscar la traducción para el menú actual
                if (traducciones.ContainsKey(clave))
                {
                    menuItem.Text = traducciones[clave].Texto; // Asignar el texto traducido
                }

                // Recorrer submenús, si existen
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    if (subItem is ToolStripMenuItem subMenuItem)
                    {
                        AplicarTraduccionMenuItem(subMenuItem); // Llamada recursiva para submenús
                    }
                }
            }

            // Recorremos todos los elementos del DropDownMenu
            foreach (ToolStripItem item in dropDownMenu.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    AplicarTraduccionMenuItem(menuItem);
                }
            }
        }


        // Función para cargar los idiomas disponibles en el ToolStripMenu
        private void CargarIdiomas()
        {
            _idiomaBLL = new IdiomaBLL();
            // Obtener la lista de idiomas desde la capa de negocios
            IList<Idioma> idiomas = _idiomaBLL.ObtenerIdiomas();

            // Limpiar los elementos existentes para evitar duplicados
            cambiarIdiomaToolStripMenuItem.DropDownItems.Clear();

            // Verificar si hay idiomas disponibles
            if (idiomas != null && idiomas.Count > 0)
            {
                foreach (var idioma in idiomas)
                {
                    // Crear un nuevo ToolStripMenuItem para cada idioma
                    ToolStripMenuItem idiomaMenuItem = new ToolStripMenuItem(idioma.Nombre)
                    {
                        Text = idioma.Nombre
                    };

                    // Agregar el nuevo ToolStripMenuItem como hijo del ToolStripMenuItem principal
                    cambiarIdiomaToolStripMenuItem.DropDownItems.Add(idiomaMenuItem);

                    // Agregar un evento de clic a cada item de idioma
                    idiomaMenuItem.Click += (s, args) =>
                    {
                        // Verificar si el idioma seleccionado es el mismo que el actual
                        if (SingletonSesion.Instancia.Usuario.Idioma.Nombre == idioma.Nombre)
                        {
                            MessageBox.Show($"Ya se encuentra en el idioma {idioma.Nombre}");
                        }
                        else
                        {
                            MessageBox.Show($"Idioma seleccionado: {idioma.Nombre}");
                            // Lógica para cambiar el idioma de la aplicación
                            TraducirFormulario(this,idioma);
                            TraducirDropDownMenu(dropDownMenu1, this.Name, _traduccionBLL.ObtenerTraducciones(idioma));
                            TraducirDropDownMenu(dropDownMenu2, this.Name, _traduccionBLL.ObtenerTraducciones(idioma));

                        }
                    };
                }
            }
            else
            {
                MessageBox.Show("No hay idiomas disponibles para seleccionar.");
            }
        }

        private void cambiarIdiomaToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            CargarIdiomas();
        }
    }


}

