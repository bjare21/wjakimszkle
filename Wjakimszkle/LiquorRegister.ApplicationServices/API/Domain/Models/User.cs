﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
