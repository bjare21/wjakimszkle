using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<ApplicationUser>>
    {
        public override async Task<List<ApplicationUser>> Execute(LiquorRegisterContext context)
        {
            var identityUsers =  await context.Users.ToListAsync();

            return identityUsers;
        }
    }
}
