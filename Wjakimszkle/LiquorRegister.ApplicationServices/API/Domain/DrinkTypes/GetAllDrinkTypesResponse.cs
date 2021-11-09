using System.Collections.Generic;
using Wjakimszkle.ApplicationServices.API.Domain.Models;
using Wjakimszkle.DataAccess.Paging;

namespace Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes
{
    public class GetAllDrinkTypesResponse:ResponseBase<PagedList<DrinkType>>
    {
    }
}