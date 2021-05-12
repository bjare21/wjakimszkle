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

namespace Wjakimszkle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly IMediator mediator;
        public DrinksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromQuery] EditDrinkRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
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

        //[HttpGet]
        //[Route("{drinkId}")]
        //public Drink GetDrinkById(int drinkId) => this.drinkRepository.GetById(drinkId);
    }
}
