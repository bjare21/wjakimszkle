using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetDrinksQuery:QueryBase<List<Drink>>
    {
        public string Name { get; set; }
        public override async Task<List<Drink>> Execute(LiquorRegisterContext context)
        {
            return !string.IsNullOrWhiteSpace(this.Name)?
                await context.Drinks.Include(d=>d.DrinkType).Where(x=>x.Name  == this.Name).ToListAsync()
                :await context.Drinks.Include(d=>d.DrinkType).ToListAsync();
        }
    }
}
