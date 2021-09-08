using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class EditDrinkCommand : CommandBase<Drink, Drink>
    {
        public DrinkType DrinkType { get; set; }
        public override async Task<Drink> Execute(LiquorRegisterContext context)
        {
            var drinkToEdit = context.Drinks.FirstOrDefault(x => x.Id == this.Parameter.Id);
            if (drinkToEdit == null) return null;
            
            context.Entry(drinkToEdit).CurrentValues.SetValues(this.Parameter);
            await context.SaveChangesAsync();
            return drinkToEdit;
        }
    }
}
