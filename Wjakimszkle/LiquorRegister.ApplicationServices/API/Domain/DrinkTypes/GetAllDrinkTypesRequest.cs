using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Paging;

namespace Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes
{
    public class GetAllDrinkTypesRequest : RequestBase<GetAllDrinkTypesResponse>
    {
        public ItemParameters ItemParameters { get; set; }
    }
}
