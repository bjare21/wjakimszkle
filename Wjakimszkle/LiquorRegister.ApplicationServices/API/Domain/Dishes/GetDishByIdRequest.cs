using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.Shared.QueryFeatures;

namespace Wjakimszkle.ApplicationServices.API.Domain.Dishes
{
    public class GetDishByIdRequest:RequestBase<GetDishByIdResponse>
    {
        public int Id { get; set; }
    }
}
