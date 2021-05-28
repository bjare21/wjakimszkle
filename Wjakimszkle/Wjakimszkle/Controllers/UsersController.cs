using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Users;

namespace Wjakimszkle.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController:ApiControllerBase
    {
        public UsersController(IMediator mediator):base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAll([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }
    }
}
