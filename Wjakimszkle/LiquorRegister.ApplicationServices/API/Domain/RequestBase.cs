using AutoMapper.Configuration.Annotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain
{
    public class RequestBase<T>:IRequest<T>
    {
        //public AuthorizationClaim AuthorizationClaim { get; set; } = new AuthorizationClaim();
    }
}
