using CondominiumContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumContext.Domain.Commands
{
    public class UserAuthenticateCommand : ICommand
    {
        public UserAuthenticateCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Teste";
    }
}
