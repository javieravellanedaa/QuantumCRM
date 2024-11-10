using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmNuevoIdioma : Form
    {
        private readonly EventManagerService _eventManagerService;
        public frmNuevoIdioma (EventManagerService eventManagerService)
        {
            InitializeComponent();
             _eventManagerService = eventManagerService;
           
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(96, 116, 239); // mismo color que frmPpalAdmin
        }


    }
}
