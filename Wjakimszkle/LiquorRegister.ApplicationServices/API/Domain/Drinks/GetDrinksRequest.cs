using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Paging;

namespace Wjakimszkle.ApplicationServices.API.Domain.Drinks
{
    public class GetDrinksRequest:RequestBase<GetDrinksResponse>
    {
        public string Name { get; set; }
        public ItemParameters ItemParameters { get; set; }
    }
}
