using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class AddDrinkCommand:CommandBase<Drink, Drink>
    {
        public override async Task<Drink> Execute(LiquorRegisterContext context)
        {
            await context.Drinks.AddAsync(this.Parameter);
            await context.SaveChangesAsync();

            return this.Parameter;
        }
    }
}
