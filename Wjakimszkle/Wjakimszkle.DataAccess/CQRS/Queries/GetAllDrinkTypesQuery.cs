using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetAllDrinkTypesQuery : QueryBase<List<DrinkType>>
    {
        public override async Task<List<DrinkType>> Execute(LiquorRegisterContext context)
        {
            return await context.DrinkTypes.ToListAsync();
        }
    }
}
