using INTERFACES;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class EventManager
    {

		private readonly IDictionary<string, IList<IEventListener>> _listeners = new Dictionary<string, IList<IEventListener>>();


		// Método para suscribirse a un tipo específico de evento
		public void Subscribe(string eventType, IEventListener listener)
		{
			if (!_listeners.ContainsKey(eventType))
			{
				_listeners[eventType] = new List<IEventListener>();
			}
			_listeners[eventType].Add(listener);
		}

		// Método para desuscribirse de un tipo específico de evento
		public void Unsubscribe(string eventType, IEventListener listener)
		{
			if (_listeners.ContainsKey(eventType))
			{
				_listeners[eventType].Remove(listener);
			}
		}

		// Método para notificar a los observadores sobre un evento
		public void Notify(string eventType, object data)
		{
			if (_listeners.ContainsKey(eventType))
			{
				foreach (var listener in _listeners[eventType])
				{
					listener.Update(eventType, data);
				}
			}
		}
	}


}

