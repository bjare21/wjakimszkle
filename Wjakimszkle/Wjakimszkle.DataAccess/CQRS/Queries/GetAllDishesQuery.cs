using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetAllDishesQuery:QueryBase<List<Dish>>
    {
        public int DrinkTypeId { get; set; }
        public override async Task<List<Dish>> Execute(LiquorRegisterContext context)
        {
            if (DrinkTypeId > 0)
            {
                var drinkType = await context.DrinkTypes.FirstOrDefaultAsync(dt => dt.Id == DrinkTypeId);
                return await context.Dishes.Where(d => d.DrinkTypes.Contains(drinkType)).ToListAsync();
            }
            return await context.Dishes.ToListAsync();
        }
    }
}
