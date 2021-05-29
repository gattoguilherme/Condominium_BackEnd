
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Domain.ValueObjects;
using CondominiumContext.Domain.Entities;
using CondominiumContext.Domain.Repositories;
using CondominiumContext.Domain.Commands;
using CondominiumContext.Shared.Commands;
using CondominiumContext.Shared.Handlers;
using Newtonsoft.Json;

namespace CondominiumContext.Domain.Handlers
{
    public class DwellerHandler : IHandler<CreateDwallerCommand>
    {
        private readonly IDwallerRepository _repository;

        public DwellerHandler(IDwallerRepository repository)
        {
            this._repository = repository;
        }

        public ICommandResult Handle(CreateDwallerCommand command)
        {
            // Generating VOs
            var address = new Address(command.BuildName, command.BuildNumber, command.Floor);
            var date = new Date(command.Day, command.Month, command.Year);
            var document = new Document(command.DocNumber, command.Type);
            var email = new Email(command.MailAddress);
            var name = new Name(command.FirstName, command.LastName);

            // Generating Entity
            var dwaller = new Dweller(address, date, document, email, name);

            // Adding contacts to entity
            if (command.Contacts != null)
                command.Contacts.ToList().ForEach(x => { dwaller.AddContact(x); } );

            // Call recording dwaller service
            _repository.CreateDwaller(dwaller);

            return new CommandResult(true, "Dwaller successfully created.");
        }
    }
}
