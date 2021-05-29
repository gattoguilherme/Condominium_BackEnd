using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Domain.Entities;

namespace CondominiumContext.Domain.Repositories
{
    public interface IDwallerRepository
    {
        void CreateDwaller(Dweller dwaller);
    }
}
