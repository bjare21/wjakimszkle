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
using Wjakimszkle.Shared.QueryFeatures;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Wjakimszkle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinksController : ApiControllerBase
    {
        private readonly ILogger<DrinksController> logger;
        private readonly UserManager<ApplicationUser> userManager;

        public DrinksController(IMediator mediator, ILogger<DrinksController> logger, UserManager<ApplicationUser> userManager) : base(mediator)
        {
            this.logger = logger;
            this.userManager = userManager;
        }

        [Authorize(Roles ="Editor")]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddDrinkRequest request)
        {
            this.logger.LogInformation(message: "Adding drink with name = {0}", request.Name);
            
            var result = await this.HandleRequest<AddDrinkRequest, AddDrinkResponse>(request);

            return result;
        }

        [Authorize(Roles ="Editor")]
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

            //var user = this.HttpContext.User;
            
            this.logger.LogInformation(message: "User access all drinks.");

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
            this.logger.LogInformation("Get drink {id}", id);

            var request = new GetDrinkByIdRequest()
            {
                DrinkId = id
            };
            return this.HandleRequest<GetDrinkByIdRequest, GetDrinkByIdResponse>(request);
        }

        [Authorize("User")]
        [HttpGet]
        [Route("GetWithRelated/{Id}")]
        public async Task<IActionResult> GetDrinkWithRelated([FromRoute] GetDrinkWithRelatedRequest request)
        {
            return await this.HandleRequest<GetDrinkWithRelatedRequest, GetDrinkWithRelatedResponse>(request);
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
        [Route("GetDrinksForDrinkTypes")]
        public async Task<IActionResult> GetDrinksForDrinkTypes([FromQuery] GetDrinksForDrinkTypesRequest request)
        {
            return await this.HandleRequest<GetDrinksForDrinkTypesRequest, GetDrinksForDrinkTypesResponse>(request);
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
