﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Users
{
    public class GetProfileRequest:RequestBase<GetProfileResponse>
    {
        public int Id { get; set; }
}
}
