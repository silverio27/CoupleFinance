using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public class Entity
    {
        public Guid Id { get; private set;}
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}