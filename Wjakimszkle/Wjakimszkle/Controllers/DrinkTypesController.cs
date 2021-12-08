using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        [Route("Remove/{Id}")]
        public async Task<IActionResult> RemoveDrinkType([FromRoute] RemoveDrinkTypeRequest request)
        {
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
        public async Task<IActionResult> GetAllDrinkTypesPaged ([FromQuery] GetAllDrinkTypesPagedRequest request)
        {
            var result = await this.HandleRequest<GetAllDrinkTypesPagedRequest, GetAllDrinkTypesPagedResponse>(request);

            if (result is OkObjectResult)
            {
                var okResult = (OkObjectResult)result;
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(((GetAllDrinkTypesPagedResponse)okResult.Value).Data.MetaData));
            };

            return result;
        }


        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllDrinkTypes([FromQuery] GetAllDrinkTypesRequest request)
        {
            return await this.HandleRequest<GetAllDrinkTypesRequest, GetAllDrinkTypesResponse>(request);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddDrinkTypeRequest request)
        {
            return await this.HandleRequest<AddDrinkTypeRequest, AddDrinkTypeResponse>(request); 
        }
    }
}
