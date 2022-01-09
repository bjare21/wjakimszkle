using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Drinks
{
    public class GetDrinkWithRelatedRequest:RequestBase<GetDrinkWithRelatedResponse>
    {
        public string Id { get; set; }
    }
}
