using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class RemoveGlassCommand:CommandBase<Glass, Glass>
    {
        public int Id { get; set; }
        public override async Task<Glass> Execute(LiquorRegisterContext context)
        {
            var glassToRemove = context.Glasses.FirstOrDefault(x => x.Id == this.Id);
            if (glassToRemove != null)
            {
                context.Glasses.Remove(glassToRemove);
                await context.SaveChangesAsync();
            }
            return glassToRemove;
        }
    }
}
