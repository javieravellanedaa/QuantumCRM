using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using INTERFACES;

namespace BE
{
    public abstract class Entity : IEntity
    {
        public Entity()
        {
           
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
