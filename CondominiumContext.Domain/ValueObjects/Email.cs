using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Shared.ValueObjects;

namespace CondominiumContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address {get; private set;}
    }
}
