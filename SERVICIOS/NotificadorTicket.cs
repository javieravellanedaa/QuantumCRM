using INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class NotificadorTicket : IEventListener
    {
        public void Update(string eventType, object data)
        {
            if (eventType == "TicketCreated")
            {
                // Código para manejar la creación de un ticket
                Console.WriteLine("Se ha creado un nuevo ticket : aca va alguna notificacion.");
                // Aquí podrías enviar un correo, mostrar un mensaje o realizar cualquier acción.
            }
        }
    }
}
