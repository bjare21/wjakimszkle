using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetDrinkTypeByIdQuery:QueryBase<DrinkType>
    {
        public int Id { get; set; }

        public override Task<DrinkType> Execute(LiquorRegisterContext context)
        {
            return context.DrinkTypes.Include(dt=>dt.Glasses).FirstOrDefaultAsync(dt => dt.Id == this.Id);
        }
    }
}
