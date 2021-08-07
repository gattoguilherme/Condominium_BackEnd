using Condominium.AuthenticationService;
using CondominiumContext.Domain.Commands;
using CondominiumContext.Domain.Entities;
using CondominiumContext.Domain.Enums;
using CondominiumContext.Domain.Repositories;
using CondominiumContext.Shared.Commands;
using CondominiumContext.Shared.Entities;
using CondominiumContext.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumContext.Domain.Handlers
{
    public class UserHandler : IHandler<UserAuthenticateCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            this._repository = repository;
        }

        public ICommandResult Handle(UserAuthenticateCommand command)
        {
            string username = command.Username;
            string password = command.Password;

            User user = new User(username, password);

            user = _repository.AuthenticateUser(user);

            string token = user != null ? TokenService.BuildToken(user) : string.Empty;

            return new CommandResult(EResultType.SUCCESS, token);
        }
    }
}
