using BE.PN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tecnico:Usuario
    {
        public int TecnicoId { get; set; }  // ID único del técnico


		private Departamento departamento;

		public Departamento Departamento
		{
			get { return departamento; }
			set { departamento = value; }
		}
		private GrupoTecnico grupoTecnico;

		public GrupoTecnico GrupoTecnico
		{
			get { return grupoTecnico; }
			set { grupoTecnico = value; }
		}


	}
}
