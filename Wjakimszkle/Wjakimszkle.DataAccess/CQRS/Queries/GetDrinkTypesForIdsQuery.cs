using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetDrinkTypesForIdsQuery:QueryBase<List<DrinkType>>
    {
        public int[] Ids { get; set; }

        public async override Task<List<DrinkType>> Execute(LiquorRegisterContext context)
        {
            if (Ids == null) return null;
            if (Ids.Count() == 0) return new List<DrinkType>();
            return await context.DrinkTypes.Where(dt => Ids.Contains(dt.Id)).ToListAsync();
        }
    }
}
