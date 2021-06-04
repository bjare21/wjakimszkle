using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain
{
    
    [BindNever]
    public class AuthorizationClaim
    {
        [BindNever]
        public string Username { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
    }
}
