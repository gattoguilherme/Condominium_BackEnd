using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Domain.Entities;

namespace CondominiumContext.Domain.Repositories
{
    public interface IDwellerRepository
    {
        bool CreateDweller(Dweller dweller);
        Dweller GetDwellerByID(int dwellerId);
        IList<Dweller> GetDwellers();
        bool DeleteDwellerById(int dwellerId);
    }
}
