using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Domain.Users
{
    public class CreateUserRequest : RequestBase<CreateUserResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        [BindNever]
        public DateTime RegisterDate { get; set; }
    }
}
