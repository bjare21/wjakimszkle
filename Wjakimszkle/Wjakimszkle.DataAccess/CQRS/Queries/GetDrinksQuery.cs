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
        public override Task<List<Drink>> Execute(LiquorRegisterContext context)
        {
            return context.Drinks.ToListAsync();
        }
    }
}
