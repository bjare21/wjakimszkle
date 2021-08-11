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
            //optionsBuilder.UseSqlServer("Server=tcp:wjakimszkle.database.windows.net,1433;Initial Catalog=LiquorRegister;Persist Security Info=False;User ID=jarek;Password=8?~}k\\]jkb4MJ4]H;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=LiquorRegister;Integrated Security=True");
            return new LiquorRegisterContext(optionsBuilder.Options);
        }
    }
}
