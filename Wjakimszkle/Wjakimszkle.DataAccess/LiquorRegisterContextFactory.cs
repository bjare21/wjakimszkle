using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.Shared.Configuration;

namespace Wjakimszkle.DataAccess
{
    public class LiquorRegisterContextFactory : IDesignTimeDbContextFactory<LiquorRegisterContext>
    {
        private readonly AppSettings appSettings;

        public LiquorRegisterContextFactory(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }
        public LiquorRegisterContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LiquorRegisterContext>();
            optionsBuilder.UseSqlServer(appSettings.ConnectionString);

            return new LiquorRegisterContext(optionsBuilder.Options);
        }
    }
}
