using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetGlassesQuery:QueryBase<List<Glass>>
    {
        public override Task<List<Glass>> Execute(LiquorRegisterContext context)
        {
            return context.Glasses
                .Include(g => g.Drinks)
                .ToListAsync();
        }
    }
}
