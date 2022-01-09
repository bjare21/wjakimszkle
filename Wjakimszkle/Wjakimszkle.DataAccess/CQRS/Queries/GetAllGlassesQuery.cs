using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetAllGlassesQuery:QueryBase<List<Glass>>
    {
        public override async Task<List<Glass>> Execute(LiquorRegisterContext context)
        {
            var glasses =  await context.Glasses.ToListAsync();
            return glasses;
        }
    }
}
