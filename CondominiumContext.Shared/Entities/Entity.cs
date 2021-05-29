using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumContext.Shared.Entities
{
    public class Entity
    {
        protected Entity()
        {
            id = Guid.NewGuid();
        }

        public Guid id { get; set; }

    }
}
