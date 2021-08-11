using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Drinks
{
    public class GetCocktailsByGlassNameRequest:RequestBase<GetCocktailsByGlassNameResponse>
    {
        public string Name { get; set; }
    }
}
