using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Models;
using Wjakimszkle.Shared.QueryFeatures;

namespace Wjakimszkle.ApplicationServices.API.Domain.Drinks
{
    public class GetDrinksResponse : ResponseBase<PagedList<Drink>>
    {

    }
}
