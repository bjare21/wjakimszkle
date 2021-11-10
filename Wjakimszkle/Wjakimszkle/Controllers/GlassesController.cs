using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Glasses;

namespace Wjakimszkle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlassesController : ApiControllerBase
    {
        public GlassesController(IMediator mediator):base(mediator)
        {
        }

        [HttpDelete]
        [Route("Remove/{Id}")]
        public async Task<IActionResult> RemoveGlass([FromRoute] RemoveGlassRequest request)
        {
            return await this.HandleRequest<RemoveGlassRequest, RemoveGlassResponse>(request);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddGlass([FromBody] AddGlassRequest request)
        {
            return await this.HandleRequest<AddGlassRequest, AddGlassResponse>(request);
            
            //if (!this.ModelState.IsValid)
            //{
            //    return this.BadRequest("BAD_REQUEST_1234");
            //}
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditGlass([FromBody] EditGlassRequest request)
        {
            return await this.HandleRequest<EditGlassRequest, EditGlassResponse>(request);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetGlassById([FromRoute] int id)
        {
            GetGlassByIdRequest request = new GetGlassByIdRequest()
            {
                Id = id
            };

            return await this.HandleRequest<GetGlassByIdRequest, GetGlassByIdResponse>(request);
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGlasses([FromQuery] GetGlassesRequest request)
        {
            var result = await this.HandleRequest<GetGlassesRequest, GetGlassesResponse>(request);
            if (result is OkObjectResult)
            {
                var okResult = (OkObjectResult)result;
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(((GetGlassesResponse)okResult.Value).Data.MetaData));
            };

            return result;
        }

        
    }
}
