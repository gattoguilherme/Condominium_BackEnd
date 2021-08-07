using CondominiumContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumContext.Domain.Commands
{
    public class DwellerGetByIdCommand : ICommand
    {
        public DwellerGetByIdCommand(Guid dwellerID)
        {
            DwellerID = dwellerID;
        }

        public Guid DwellerID { get; set; }
    }
}
