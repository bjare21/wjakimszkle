using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.Entities;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Drinks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wjakimszkle.DataAccess.Paging;

namespace Wjakimszkle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinksController : ApiControllerBase
    {
        private readonly ILogger<DrinksController> logger;

        public DrinksController(IMediator mediator, ILogger<DrinksController> logger) : base(mediator)
        {
            this.logger = logger;
            this.logger.LogInformation(message:"We are in drinks controller");
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddDrinkRequest request)
        {
            return await this.HandleRequest<AddDrinkRequest,AddDrinkResponse>(request);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditDrinkRequest request)
        {
            return await this.HandleRequest<EditDrinkRequest, EditDrinkResponse>(request);
        }

        [HttpDelete]
        [Route("Remove/{Id}")]
        public async Task<IActionResult> Remove([FromRoute] RemoveDrinkRequest request)
        {
            return await this.HandleRequest<RemoveDrinkRequest, RemoveDrinkResponse>(request);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllDrinks([FromQuery] GetDrinksRequest request)
        {
            var result = await this.HandleRequest<GetDrinksRequest, GetDrinksResponse>(request);

            if (result is OkObjectResult)
            {
                var okResult = (OkObjectResult)result;
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(((GetDrinksResponse)okResult.Value).Data.MetaData));
            };
            
            return result;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public Task<IActionResult> GetDrinkById([FromRoute] int id)
        {
            var request = new GetDrinkByIdRequest()
            {
                DrinkId = id
            };
            return this.HandleRequest<GetDrinkByIdRequest, GetDrinkByIdResponse>(request);
        }

        [HttpGet]
        [Route("Glass/{glassId}")]
        public async Task<IActionResult> GetDrinksByGlassId([FromRoute] int glassId)
        {
            var request = new GetDrinksByGlassIdRequest()
            {
                GlassId = glassId
            };

            return await this.HandleRequest<GetDrinksByGlassIdRequest, GetDrinksByGlassIdResponse>(request);
        }

        [HttpGet]
        [Route("GlassName/{glassName}")]
        public async Task<IActionResult> GetCocktailsByGlassName([FromRoute] string glassName)
        {
            var request = new GetCocktailsByGlassNameRequest()
            {
                Name = glassName
            };

            return await this.HandleRequest<GetCocktailsByGlassNameRequest, GetCocktailsByGlassNameResponse>(request);
        }

        //[HttpGet]
        //[Route("{drinkId}")]
        //public Drink GetDrinkById(int drinkId) => this.drinkRepository.GetById(drinkId);
    }
}
