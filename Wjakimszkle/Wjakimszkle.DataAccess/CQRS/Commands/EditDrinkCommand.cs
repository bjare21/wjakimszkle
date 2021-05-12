using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class EditDrinkCommand:CommandBase<Drink, Drink>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override async Task<Drink> Execute(LiquorRegisterContext context)
        {
            var drinkToEdit = context.Drinks.FirstOrDefault(x => x.Id == this.Id);
            if (drinkToEdit != null)
            {
                drinkToEdit.Name = this.Name;
                await context.SaveChangesAsync();
            }
            return drinkToEdit;
        }
    }
}
