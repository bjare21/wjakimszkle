﻿using MediatR;
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

namespace Wjakimszkle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinksController : ApiControllerBase
    {
        public DrinksController(IMediator mediator, ILogger<DrinksController> logger) : base(mediator)
        {
            logger.LogInformation(message:"We are in drinks controller");
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddDrinkRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromQuery] EditDrinkRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> Remove([FromQuery] RemoveDrinkRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllDrinks([FromQuery] GetDrinksRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{drinkId}")]
        public Task<IActionResult> GetDrinkById([FromRoute] int drinkId)
        {
            var request = new GetDrinkByIdRequest()
            {
                DrinkId = drinkId
            };
            return this.HandleRequest<GetDrinkByIdRequest, GetDrinkByIdResponse>(request);
        }

        //[HttpGet]
        //[Route("{drinkId}")]
        //public Drink GetDrinkById(int drinkId) => this.drinkRepository.GetById(drinkId);
    }
}
