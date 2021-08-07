using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Shared.ValueObjects;
using CondominiumContext.Domain.Enums;

namespace CondominiumContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document()
        {

        }

        public Document(string number, EDocumentType type, Guid? id = null) : base(id)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}
