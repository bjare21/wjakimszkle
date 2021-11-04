using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;
using Wjakimszkle.DataAccess.Paging;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetAllDishesQuery:QueryBase<List<Dish>>
    {
        public override async Task<List<Dish>> Execute(LiquorRegisterContext context)
        {
            return await context.Dishes.ToListAsync();
        }
    }
}
