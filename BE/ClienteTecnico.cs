using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClienteTecnico : Entity
    {
        public ClienteTecnico()
        {
        }

        private int clienteTecnicoId;
        public int ClienteTecnicoId
        {
            get { return clienteTecnicoId; }
            set { clienteTecnicoId = value; }
        }

        private int clienteId;
        public int ClienteId
        {
            get { return clienteId; }
            set { clienteId = value; }
        }

        private Cliente cliente;
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        private Guid tecnicoId;
        public Guid TecnicoId
        {
            get { return tecnicoId; }
            set { tecnicoId = value; }
        }

        private Tecnico tecnico;
        public Tecnico Tecnico
        {
            get { return tecnico; }
            set { tecnico = value; }
        }
    }
}

