using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class EditDishCommand:CommandBase<Dish, Dish>
    {
        public override async Task<Dish> Execute(LiquorRegisterContext context)
        {
            var dishToEdit = context.Dishes
                .FirstOrDefault(x => x.Id == this.Parameter.Id);

            if (dishToEdit == null) return null;

            context.Entry(dishToEdit).CurrentValues.SetValues(this.Parameter);
            await context.SaveChangesAsync();
            return dishToEdit;
        }
    }
}
