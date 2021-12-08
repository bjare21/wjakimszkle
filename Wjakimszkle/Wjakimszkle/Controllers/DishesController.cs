using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var user = this.HttpContext.User;
            var result = await this.HandleRequest<GetDishesRequest, GetDishesResponse>(request);

            if (result is OkObjectResult)
            {
                var okResult = (OkObjectResult)result;
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(((GetDishesResponse)okResult.Value).Data.MetaData));
            }

            return result;
        }

        [HttpGet]
        [Route("GetDishWithPairedDrinkTypes/{Id}")]
        public async Task<IActionResult> GetDishWithPairedDrinkTypes([FromRoute] GetDishWithPairedDrinkTypesRequest request)
        {
            return await this.HandleRequest<GetDishWithPairedDrinkTypesRequest, GetDishWithPairedDrinkTypesResponse>(request);
        }


        [HttpPut]
        [Route("AddPairings")]
        public async Task<IActionResult> PairDrinkTypesWithDish([FromBody] PairDrinkTypesWithDishRequest request)
        {
            return await this.HandleRequest<PairDrinkTypesWithDishRequest, PairDrinkTypesWithDishResponse>(request);
        }
    }
}
