using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Dishes;

namespace Wjakimszkle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishesController : ApiControllerBase
    {
        public DishesController(IMediator mediator):base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllDishes([FromQuery] GetDishesRequest request)
        {
            return await this.HandleRequest<GetDishesRequest, GetDishesResponse>(request);
        }
    }
}
