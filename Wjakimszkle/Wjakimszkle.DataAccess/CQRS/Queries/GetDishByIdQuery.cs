using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetDishByIdQuery : QueryBase<Dish>
    {
        public int Id { get; set; }


        public override async Task<Dish> Execute(LiquorRegisterContext context)
        {
            var dish = await context.Dishes.
                 Include(d => d.DrinkTypes)
                 .FirstOrDefaultAsync(d => d.Id == this.Id);

            return dish;
        }
    }
}
