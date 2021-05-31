using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetManufacturersQuery:QueryBase<List<Manufacturer>>
    {
        public override async Task<List<Manufacturer>> Execute(LiquorRegisterContext context)
        {
            return await context.Manufacturers.ToListAsync();
        }
    }
}
