using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class EditGlassCommand:CommandBase<Glass, Glass>
    {
        public override async Task<Glass> Execute(LiquorRegisterContext context)
        {
            var glassToEdit = context.Glasses.FirstOrDefault(g => g.Id == Parameter.Id);
            if (glassToEdit == null) return null;
            context.Entry(glassToEdit).CurrentValues.SetValues(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
