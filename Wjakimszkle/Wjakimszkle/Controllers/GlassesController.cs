using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [Route("Remove")]
        public async Task<IActionResult> RemoveGlass([FromQuery] RemoveGlassRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("Add")]
        public Task<IActionResult> AddGlass([FromBody] AddGlassRequest request)
        {
            return this.HandleRequest<AddGlassRequest, AddGlassResponse>(request);
            
            //if (!this.ModelState.IsValid)
            //{
            //    return this.BadRequest("BAD_REQUEST_1234");
            //}
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditGlass([FromQuery] EditGlassRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGlasses([FromQuery] GetGlassesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        
    }
}
