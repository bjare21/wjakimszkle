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
        public int DrinkTypeId { get; set; }
        public override async Task<Drink> Execute(LiquorRegisterContext context)
        {
            var drinkType = context.DrinkTypes.FirstOrDefault(dt => dt.Id == this.DrinkTypeId);

            if (drinkType != null) this.Parameter.DrinkType = drinkType;
            
            await context.Drinks.AddAsync(this.Parameter);
            await context.SaveChangesAsync();

            return this.Parameter;
        }
    }
}
