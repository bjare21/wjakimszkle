using Microsoft.EntityFrameworkCore;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess
{
    public class LiquorRegisterContext:DbContext
    {
       public LiquorRegisterContext(DbContextOptions<LiquorRegisterContext> opt) : base(opt) { }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Glass> Glasses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DrinkType> DrinkTypes { get; set; }
    }
}
