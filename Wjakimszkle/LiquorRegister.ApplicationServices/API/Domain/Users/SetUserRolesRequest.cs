using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.Shared.Models.Users;

namespace Wjakimszkle.ApplicationServices.API.Domain.Users
{
    public class SetUserRolesRequest:RequestBase<SetUserRolesResponse>
    {
        public string UserId { get; set; }
        public string[] RolesNames { get; set; }
    }
}
