using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Domain.Enums;
using CondominiumContext.Shared.Commands;

namespace CondominiumContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(EResultType result, object message)
        {
            Result = result.ToString();
            Message = message;
        }

        public string Result { get; set; }
        public object Message { get; set; }
    }
}
