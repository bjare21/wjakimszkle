using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.Shared.QueryFeatures;

namespace Wjakimszkle.ApplicationServices.API.Domain.Glasses
{
    public class GetGlassesRequest:RequestBase<GetGlassesResponse>
    {
        public ItemParameters ItemParameters { get; set; }
    }
}
