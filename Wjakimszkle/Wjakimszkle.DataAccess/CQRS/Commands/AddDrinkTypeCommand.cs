using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class AddDrinkTypeCommand:CommandBase<DrinkType, DrinkType>
    {
        public List<int> GlassesIds { get; set; }
        public override async Task<DrinkType> Execute(LiquorRegisterContext context)
        {
            var glasses = context.Glasses.Where(g => GlassesIds.Contains(g.Id));
            if ((glasses != null)&&(glasses.Count()>0))
            {
                this.Parameter.Glasses.AddRange(glasses);
            }
            await context.DrinkTypes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();

            return this.Parameter;
        }
    }
}
