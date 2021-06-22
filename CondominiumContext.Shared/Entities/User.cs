using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumContext.Shared.Entities
{
    public class User : Entity
    {
        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
