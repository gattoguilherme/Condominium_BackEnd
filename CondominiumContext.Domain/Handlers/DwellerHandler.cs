
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
    public class DwellerHandler : IHandler<DwellerCreateCommand>, IHandler<DwellerGetByIdCommand>
    {
        private readonly IDwellerRepository _repository;

        public DwellerHandler(IDwellerRepository repository)
        {
            this._repository = repository;
        }

        public ICommandResult Handle(DwellerCreateCommand command)
        {
            // Generating VOs
            var address = new Address(command.BuildName, command.BuildNumber, command.Floor);
            var date = new Date(command.Day, command.Month, command.Year);
            var document = new Document(command.DocNumber, command.Type);
            var email = new Email(command.MailAddress);
            var name = new Name(command.FirstName, command.LastName);

            // Generating Entity
            var dweller = new Dweller(address, date, document, email, name);

            // Adding contacts to entity
            if (command.Contacts != null)
                command.Contacts.ToList().ForEach(x => { dweller.AddContact(x); } );

            // Call recording dweller service
            _repository.CreateDweller(dweller);

            return new CommandResult(true, "Dweller successfully created.");
        }

        public ICommandResult Handle(DwellerGetByIdCommand command)
        {
            var dweller = _repository.GetDwellerByID(command.DwellerID);

            return new CommandResult(true, dweller.ToString());
        }

        public ICommandResult Handle(DwellersGetCommand command)
        {
            var dwellers = _repository.GetDwellers();

            return new CommandResult(true, JsonConvert.SerializeObject(dwellers));
        }

        public ICommandResult Handler(DwellerDeleteByIdCommand command)
        {
            _repository.DeleteDwellerById(command.DwellerID);

            return new CommandResult(true, string.Format("{0} successfully deleted.", command.DwellerID));
        }
    }
}
