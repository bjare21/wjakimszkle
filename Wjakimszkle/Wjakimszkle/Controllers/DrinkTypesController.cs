using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes;

namespace Wjakimszkle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinkTypesController:ApiControllerBase
    {
        private readonly ILogger<DrinkTypesController> logger;
        public DrinkTypesController(IMediator mediator, ILogger<DrinkTypesController> logger) : base(mediator)
        {
            this.logger = logger;
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> RemoveDrinkType([FromQuery] int drinkTypeId)
        {
            var request = new RemoveDrinkTypeRequest()
            {
                Id = drinkTypeId
            };
            return await this.HandleRequest<RemoveDrinkTypeRequest, RemoveDrinkTypeResponse>(request);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditDrinkTypeRequest request)
        {
            return await this.HandleRequest<EditDrinkTypeRequest, EditDrinkTypeResponse>(request);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetDrinkTypeById([FromRoute]int id)
        {
            var request = new GetDrinkTypeByIdRequest()
            {
                Id = id
            };
            return await this.HandleRequest<GetDrinkTypeByIdRequest, GetDrinkTypeByIdResponse>(request);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllDrinkTypes()
        {
            return await this.HandleRequest<GetAllDrinkTypesRequest, GetAllDrinkTypesResponse>(new GetAllDrinkTypesRequest());
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddDrinkTypeRequest request)
        {
            return await this.HandleRequest<AddDrinkTypeRequest, AddDrinkTypeResponse>(request); 
        }
    }
}
