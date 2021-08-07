using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Shared.ValueObjects;

namespace CondominiumContext.Domain.ValueObjects
{
    public class Contact : ValueObject
    {
        public Contact()
        {

        }

        public Contact(string ddd, string number, string countryCode = "55", Guid? id = null) : base(id)
        {
            Ddd = ddd;
            Number = number;
            CountryCode = countryCode;
        }

        public string CountryCode { get; private set; }
        public string Ddd { get; private set; }
        public string Number { get; private set; }
    }
}
