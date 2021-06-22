using CondominiumContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumContext.Domain.Repositories
{
    public interface IUserRepository
    {
        User AuthenticateUser(User user);
    }
}
