using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class EditDrinkTypeCommand : CommandBase<DrinkType, DrinkType>
    {
        public async override Task<DrinkType> Execute(LiquorRegisterContext context)
        {
            var typeToEdit = await context.DrinkTypes.FirstOrDefaultAsync(t => t.Id == this.Parameter.Id);
            if (typeToEdit == null) return null;
            context.Entry(typeToEdit).CurrentValues.SetValues(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
