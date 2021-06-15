using CondominiumContext.Domain.Commands;
using CondominiumContext.Domain.Entities;
using CondominiumContext.Domain.Handlers;
using CondominiumContext.Domain.Repositories;
using CondominiumContext.Shared.Commands;
using CondominiumContext.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult Login([FromBody] UserAuthenticateCommand command)
        {
            //if (string.IsNullOrEmpty(command.Username) || string.IsNullOrEmpty(command.Password))
            //    return BadRequest();

            var mockRepo = new MockRepository();
            var handler = new UserHandler(mockRepo);

            return handler.Handle(command);
        }

        public class MockRepository : IUserRepository
        {
            IList<User> users = new List<User>();
            public MockRepository()
            {
                for (int i = 0; i < 7; i++)
                {
                    string cont = i.ToString();
                    users.Add(new User(("teste" + cont), ("senha" + cont), ("role" + cont) ));
                }
            }

            public User AuthenticateUser(User user)
            {
                return users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            }
        }
    }
}
