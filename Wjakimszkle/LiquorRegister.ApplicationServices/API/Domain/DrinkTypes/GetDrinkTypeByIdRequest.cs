using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes
{
    public class GetDrinkTypeByIdRequest:RequestBase<GetDrinkTypeByIdResponse>
    {
        public int Id { get; set; }
    }
}
