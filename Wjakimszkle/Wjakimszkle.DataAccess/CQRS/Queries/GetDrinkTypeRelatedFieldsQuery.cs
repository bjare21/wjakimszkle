using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetDrinkTypeRelatedFieldsQuery:QueryBase<DrinkType>
    {
        public int Id { get; set; }
        public override async Task<DrinkType> Execute(LiquorRegisterContext context)
        {
            if (Id == 0) return null;

            var dt = await context.DrinkTypes.FirstOrDefaultAsync(dt => dt.Id == Id);

            if (dt == null) return null;

            return await context.DrinkTypes.Include(dt => dt.Glasses).Include(dt => dt.Dishes).FirstAsync(dt => dt.Id == Id);
        }
    }
}
