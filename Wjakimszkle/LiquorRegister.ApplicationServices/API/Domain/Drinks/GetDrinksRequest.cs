using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Drinks
{
    public class GetDrinksRequest:IRequest<GetDrinksResponse>
    {
        public string Name { get; set; }
    }
}
