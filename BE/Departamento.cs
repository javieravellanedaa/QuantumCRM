using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Departamento
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private List<Usuario> usuarios;

		public List<Usuario> Usuarios
		{
			get { return usuarios; }
			set { usuarios = value; }
		}

		private List<Ticket> bandejaDeTickets;

		public List<Ticket> BandejaDeTickets
		{
			get { return bandejaDeTickets; }
			set { bandejaDeTickets = value; }
		}

		//***************MODIFICAR ESTO ********************/////

		//private List<Tecnico> tecnicos;

		//public List<Tecnico> Tecnicos
		//{
		//	get { return tecnicos; }
		//	set { tecnicos = value; }
		//}






	}
}
