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
        public List<string> GlassesIds { get; set; }
        public async override Task<DrinkType> Execute(LiquorRegisterContext context)
        {
            var typeToEdit = await context.DrinkTypes.Include(dt=>dt.Glasses).FirstOrDefaultAsync(t => t.Id == this.Parameter.Id);
            if (typeToEdit == null) return null;
            var glasses =  context.Glasses.Where(g => GlassesIds.Contains(g.Id.ToString()));
            typeToEdit.Glasses.Clear();
            typeToEdit.Glasses.AddRange(glasses);
            context.Entry(typeToEdit).CurrentValues.SetValues(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
