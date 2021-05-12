using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.CQRS.Commands;

namespace Wjakimszkle.DataAccess
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly LiquorRegisterContext context;

        public CommandExecutor(LiquorRegisterContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
