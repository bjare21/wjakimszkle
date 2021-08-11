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
        [Route("Me")]
        public Task<IActionResult> Me([FromQuery] GetProfileRequest request)
        {
            return this.HandleRequest<GetProfileRequest, GetProfileResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Create")]
        public Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            return this.HandleRequest<CreateUserRequest, CreateUserResponse>(request);
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAll([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Post([FromBody] ValidateUserRequest request)
        {
            return await this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }
    }
}
