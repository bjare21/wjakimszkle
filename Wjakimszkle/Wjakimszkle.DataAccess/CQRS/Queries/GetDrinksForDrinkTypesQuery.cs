using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetDrinksForDrinkTypesQuery:QueryBase<List<Drink>>
    {
        public int[] DrinkTypeIds { get; set; }

        public override async Task<List<Drink>> Execute(LiquorRegisterContext context)
        {
            var result = await context.Drinks
                .Where(d => DrinkTypeIds.Contains(d.DrinkType.Id))
                .ToListAsync();
                
            return result;
        }
    }
}
