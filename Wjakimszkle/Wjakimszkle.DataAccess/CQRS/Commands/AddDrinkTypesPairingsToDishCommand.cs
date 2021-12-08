using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Commands
{
    public class AddDrinkTypesPairingsToDishCommand:CommandBase<Dish, Dish>
    {
        public int Id { get; set; }
        public List<string> DrinkTypesPaired { get; set; }
        public override async Task<Dish> Execute(LiquorRegisterContext context)
        {
            var pairedDrinkTypes = DrinkTypesPaired.Select(id => context.DrinkTypes.Find(int.Parse(id)));
            try
            {
                if ((Id > 0))
                {
                    context.Dishes.Include(d => d.DrinkTypes).First(d => d.Id == Id).DrinkTypes.Clear();
                    //await context.SaveChangesAsync();

                    context.Dishes.Include(d=>d.DrinkTypes).First(d=>d.Id==Id).DrinkTypes.AddRange(pairedDrinkTypes);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return context.Dishes.Find(Id);
        }
    }
}
