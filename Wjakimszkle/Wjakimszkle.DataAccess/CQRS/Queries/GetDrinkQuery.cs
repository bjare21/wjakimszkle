using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetDrinkQuery:QueryBase<Drink>
    {
        public int Id { get; set; }
        public override async Task<Drink> Execute(LiquorRegisterContext context)
        {
            var drink = await context.Drinks.Include(d=>d.DrinkType).ThenInclude(dt=>dt.Glasses).FirstOrDefaultAsync(x=>x.Id == this.Id);
            return drink;
        }
    }
}
