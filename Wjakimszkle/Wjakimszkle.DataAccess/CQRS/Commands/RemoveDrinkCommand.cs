using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class RemoveDrinkCommand:CommandBase<Drink, Drink>
    {
        public int Id { get; set; }

        public override async Task<Drink> Execute(LiquorRegisterContext context)
        {
            var drinkToRemove = context.Drinks.FirstOrDefault(x => x.Id == this.Id);
            if (drinkToRemove !=null)
            {
                context.Drinks.Remove(drinkToRemove);
                await context.SaveChangesAsync();
            }

            return drinkToRemove;
        }
    }
}
