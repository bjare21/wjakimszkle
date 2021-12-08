using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.Shared.QueryFeatures;

namespace Wjakimszkle.ApplicationServices.API.Domain.Dishes
{
    public class GetDishesRequest:RequestBase<GetDishesResponse>
    {
        public ItemParameters ItemParameters { get; set; }
    }

}
