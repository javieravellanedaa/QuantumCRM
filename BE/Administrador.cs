using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Administrador : Usuario
    {
		private bool estado;

		public bool Estado
		{
			get { return estado; }
			set { estado = value; }
		}

		private DateTime? fechaCreacion;

		public DateTime? FechaCreacion
		{
			get { return fechaCreacion; }
			set { fechaCreacion = value; }
		}

		private Guid idAdministrador;

		public Guid IdAdministrador
		{
			get { return idAdministrador; }
			set { idAdministrador = value; }
		}






	}
}
