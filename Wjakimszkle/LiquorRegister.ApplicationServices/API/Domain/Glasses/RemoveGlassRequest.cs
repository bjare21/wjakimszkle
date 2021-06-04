﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Glasses
{
    public class RemoveGlassRequest:RequestBase<RemoveGlassResponse>
    {
        public int Id { get; set; }
    }
}
