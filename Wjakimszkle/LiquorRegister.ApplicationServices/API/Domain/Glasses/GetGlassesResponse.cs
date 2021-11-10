using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Models;
using Wjakimszkle.DataAccess.Paging;

namespace Wjakimszkle.ApplicationServices.API.Domain.Glasses
{
    public class GetGlassesResponse : ResponseBase<PagedList<Glass>>
    {

    }
}
