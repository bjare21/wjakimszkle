using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class AddDishCommand:CommandBase<Dish,Dish>
    {
        public override async Task<Dish> Execute(LiquorRegisterContext context)
        {
            await context.Dishes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
