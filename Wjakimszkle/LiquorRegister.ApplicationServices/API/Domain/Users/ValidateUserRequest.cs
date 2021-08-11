using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Users
{
    public class ValidateUserRequest:RequestBase<ValidateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
