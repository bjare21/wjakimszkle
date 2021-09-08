using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class RemoveDishCommand:CommandBase<Dish, Dish>
    {

        public override async Task<Dish> Execute(LiquorRegisterContext context)
        {
            var dishToRemove = context
                .Dishes
                .FirstOrDefault(x => x.Id == Parameter.Id);

            if (dishToRemove != null)
            {
                context.Dishes.Remove(dishToRemove);
                await context.SaveChangesAsync();
            }

            return dishToRemove;
        }
    }
}
