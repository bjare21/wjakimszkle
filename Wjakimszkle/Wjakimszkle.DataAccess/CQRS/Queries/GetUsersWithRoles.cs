using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess.CQRS.Queries
{
    public class GetUsersWithRoles:QueryBase<List<ApplicationUser>>
    {
        public override async Task<List<ApplicationUser>> Execute(LiquorRegisterContext context)
        {
            var users = context.Users;
            //var usersWithUserRoles = users.Include(u => u.UserRoles);

            throw new NotImplementedException();
            //return await context.Users.Include(u => u.UserRoles).ThenInclude(x => x.Role).ToListAsync();
        }
    }
}
