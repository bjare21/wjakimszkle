using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Users
{
    public class SetUserRoleRequest:RequestBase<SetUserRoleResponse>
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
