using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain
{
    public class AddGlassRequest:IRequest<AddGlassResponse>
    {
        public string Name { get; set; }
    }
}
