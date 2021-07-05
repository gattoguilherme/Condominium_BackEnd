using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumContext.Shared.ValueObjects
{
    public class ValueObject
    {
        protected ValueObject()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
