using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Manufacturers;

namespace Wjakimszkle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturersController:ApiControllerBase
    {
        public ManufacturersController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll([FromQuery] GetManufacturersRequest request)
        {
            return await this.HandleRequest<GetManufacturersRequest, GetManufacturersResponse>(request);
        }
    }
}
