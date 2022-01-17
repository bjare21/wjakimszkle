using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes
{
    public class GetDrinkTypesForIdsRequest:RequestBase<GetDrinkTypesForIdsResponse>
    {
        public List<string> Ids { get; set; }
    }
}
