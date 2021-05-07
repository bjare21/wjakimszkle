using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.DataAccess
{
    public class LiquorRegisterContextFactory : IDesignTimeDbContextFactory<LiquorRegisterContext>
    {
        public LiquorRegisterContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LiquorRegisterContext>();
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDb; Initial Catalog = LiquorRegister; Integrated Security = True");
            return new LiquorRegisterContext(optionsBuilder.Options);
        }
    }
}
