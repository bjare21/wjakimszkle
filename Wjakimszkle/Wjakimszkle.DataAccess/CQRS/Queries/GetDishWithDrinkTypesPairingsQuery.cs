using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetDishWithDrinkTypesPairingsQuery:QueryBase<List<DrinkType>>
    {
        public int Id { get;set; }
        public override async Task<List<DrinkType>> Execute(LiquorRegisterContext context)
        {
            return context.Dishes.Find(this.Id).DrinkTypes;
        }
    }
}
