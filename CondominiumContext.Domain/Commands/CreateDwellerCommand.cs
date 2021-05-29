using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Domain.Enums;
using CondominiumContext.Domain.ValueObjects;
using CondominiumContext.Shared.Commands;

namespace CondominiumContext.Domain.Commands
{
    public class CreateDwellerCommand : ICommand
    {
        public string BuildName { get; set; }
        public string BuildNumber { get; set; }
        public string Floor { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string DocNumber { get; set; }
        public EDocumentType Type { get; set; }
        public string MailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Contact> Contacts { get; set; }
    }
}
