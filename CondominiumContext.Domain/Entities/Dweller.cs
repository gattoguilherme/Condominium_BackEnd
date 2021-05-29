using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Domain.ValueObjects;
using CondominiumContext.Shared.Entities;

namespace CondominiumContext.Domain.Entities
{
    public class Dweller : Entity
    {
        private IList<Contact> _contacts;

        public Dweller()
        {

        }

        public Dweller(Address address, Date bornDate, Document document, Email email, Name name)
        {
            Address = address;
            BornDate = bornDate;
            Document = document;
            Email = email;
            Name = name;
            _contacts = new List<Contact>(); 
        }

        public Address Address { get; private set; }
        public Date BornDate { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Name Name { get; private set; }
        public IList<Contact> Contacts { get { return this._contacts.ToArray(); } }

        public void AddContact(Contact contact)
        {
            this._contacts.Add(contact);
        }
    }
}
