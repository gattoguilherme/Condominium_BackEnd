using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Shared.Commands;

namespace CondominiumContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
