using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente : Usuario
    {
        public int ClienteId { get; set; } 

        private int departamentoId;
        public int DepartamentoId
        {
            get { return departamentoId; }
            set { departamentoId = value; }
        }

        private Departamento departamento;
        public Departamento Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        private DateTime? fechaRegistro;
        public DateTime? FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
        // no tiene tabla creada
        private int estadoClienteId;
        public int EstadoClienteId
        {
            get { return estadoClienteId; }
            set { estadoClienteId = value; }
        }

      
        private int tipoClienteId;
        public int TipoClienteId
        {
            get { return tipoClienteId; }
            set { tipoClienteId = value; }
        }

        private TipoCliente tipoCliente;

        public TipoCliente TipoCliente
        {
            get { return tipoCliente; }
            set { tipoCliente = value; }
        }


        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string emailContacto;
        public string EmailContacto
        {
            get { return emailContacto; }
            set { emailContacto = value; }
        }

        private bool esInterno;
        public bool EsInterno
        {
            get { return esInterno; }
            set { esInterno = value; }
        }

        private string empresa;
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        private DateTime? fechaUltimaInteraccion;
        public DateTime? FechaUltimaInteraccion
        {
            get { return fechaUltimaInteraccion; }
            set { fechaUltimaInteraccion = value; }
        }

        private string preferenciaContacto;
        public string PreferenciaContacto
        {
            get { return preferenciaContacto; }
            set { preferenciaContacto = value; }
        }
    }
}
