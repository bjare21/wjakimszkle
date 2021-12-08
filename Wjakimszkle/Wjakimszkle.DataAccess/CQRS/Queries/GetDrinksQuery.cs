using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;
using Wjakimszkle.Shared.QueryFeatures;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetDrinksQuery:QueryBase<List<Drink>>
    {
        public DrinksParameters ItemParameters;
        public override async Task<List<Drink>> Execute(LiquorRegisterContext context)
        {
            var drinks = await context.Drinks.Include(d=>d.DrinkType).ToListAsync();

            if (!string.IsNullOrEmpty(ItemParameters.SearchName))
                drinks = drinks.Where(d => d.Name.ToLower().Contains(ItemParameters.SearchName.ToLower())).ToList();

            if (ItemParameters.SearchDrinkTypeId > 0)
            {
                drinks = drinks.Where(d => d.DrinkType != null && d.DrinkType.Id == ItemParameters.SearchDrinkTypeId).ToList();
            }

            return drinks;
        }
    }
}
