using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class RemoveDrinkTypeCommand : CommandBase<int, DrinkType>
    {
        public override async Task<DrinkType> Execute(LiquorRegisterContext context)
        {
            var drinkTypeToRemove = context.DrinkTypes.FirstOrDefault(dt => dt.Id == this.Parameter);
            if (drinkTypeToRemove != null)
            {
                context.DrinkTypes.Remove(drinkTypeToRemove);
                await context.SaveChangesAsync();
            }
            return drinkTypeToRemove;
        }
    }
}
