using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class AddGlassCommand : CommandBase<Glass, Glass>
    {
        public override async Task<Glass> Execute(LiquorRegisterContext context)
        {
            await context.Glasses.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
