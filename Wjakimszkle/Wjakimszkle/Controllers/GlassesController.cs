using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;

namespace Wjakimszkle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlassesController : ControllerBase
    {
        private readonly IMediator mediator;
        public GlassesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("Remove")]
        public async Task<IActionResult> RemoveGlass([FromQuery] RemoveGlassRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddGlass([FromBody] AddGlassRequest request)
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
