using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetDrinksByGlassIdQuery : QueryBase<List<Drink>>
    {
        public int GlassId { get; set; }
        public override async Task<List<Drink>> Execute(LiquorRegisterContext context)
        {
            var glass = context.Glasses.Include(g=>g.DrinkTypes).FirstOrDefault(g => g.Id == GlassId);
            if (glass != null)
            {
                return await context.Drinks.Where(d => d.DrinkType.Glasses.Contains(glass)).ToListAsync();
            }
            return new List<Drink>();
        }
    }
}
