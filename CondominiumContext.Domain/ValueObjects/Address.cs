using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Shared.ValueObjects;

namespace CondominiumContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string buildName, string number, string floor)
        {
            BuildName = buildName;
            Number = number;
            Floor = floor;
        }

        public string BuildName { get; private set; }
        public string Number { get; private set; }
        public string Floor { get; private set; }
    }
}
