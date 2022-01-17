using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetGlassByIdQuery : QueryBase<Glass>
    {
        public int Id { get; set; }
        public override async Task<Glass> Execute(LiquorRegisterContext context)
        {
            return await context.Glasses.Include(g=>g.DrinkTypes).SingleOrDefaultAsync(g => g.Id == Id);
        }
    }
}
