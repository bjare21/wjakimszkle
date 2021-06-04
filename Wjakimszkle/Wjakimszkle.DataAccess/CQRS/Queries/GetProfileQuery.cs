using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetProfileQuery:QueryBase<User>
    {
        public int Id { get; set; }
        public override async Task<User> Execute(LiquorRegisterContext context)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == this.Id);
        }
    }
}
