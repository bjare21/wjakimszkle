using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.Shared.QueryFeatures;

namespace Wjakimszkle.ApplicationServices.API.Domain.Drinks
{
    public class GetDrinksRequest:RequestBase<GetDrinksResponse>
    {
        public string Name { get; set; }
        public DrinksParameters ItemParameters { get; set; }
    }
}
