using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public DishesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddDishRequest request)
        {
            return await this.HandleRequest<AddDishRequest, AddDishResponse>(request);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditDishRequest request)
        {
            return await this.HandleRequest<EditDishRequest, EditDishResponse>(request);
        }

        [HttpDelete]
        [Route("Remove/{Id}")]
        public async Task<IActionResult> Remove([FromRoute] RemoveDishRequest request)
        {
            return await this.HandleRequest<RemoveDishRequest, RemoveDishResponse>(request);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<IActionResult> GetDishById([FromRoute] GetDishByIdRequest request)
        {
            return await this.HandleRequest<GetDishByIdRequest, GetDishByIdResponse>(request);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllDishes([FromQuery] GetDishesRequest request)
        {
            return await this.HandleRequest<GetDishesRequest, GetDishesResponse>(request);
        }
    }
}
