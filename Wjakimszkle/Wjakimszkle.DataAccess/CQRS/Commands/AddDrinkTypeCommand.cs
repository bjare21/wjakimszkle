using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class AddDrinkTypeCommand:CommandBase<DrinkType, DrinkType>
    {
        public override async Task<DrinkType> Execute(LiquorRegisterContext context)
        {
            await context.DrinkTypes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();

            return this.Parameter;
        }
    }
}
