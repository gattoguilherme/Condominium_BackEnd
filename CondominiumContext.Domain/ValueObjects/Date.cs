using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Shared.ValueObjects;

namespace CondominiumContext.Domain.ValueObjects
{
    public class Date : ValueObject
    {
        public Date()
        {

        }

        public Date(string day, string month, string year, Guid? id = null) : base(id)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public string Day { get; private set; }
        public string Month { get; private set; }
        public string Year { get; private set; }
    }
}
