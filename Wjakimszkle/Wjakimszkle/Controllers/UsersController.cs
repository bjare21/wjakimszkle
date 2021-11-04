using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Users;
using Wjakimszkle.ApplicationServices.API.Domain.Users.Models;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(IMediator mediator, UserManager<ApplicationUser> userManager) : base(mediator)
        {
            this._userManager = userManager;
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

        [Authorize(Roles ="Admin")]
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        public Task<IActionResult> Get([FromRoute] GetUserRequest request)
        {
            return this.HandleRequest<GetUserRequest, GetUserResponse>(request);
        }


        [HttpGet]
        [Route("GetUserRole/{Id}")]
        public Task<IActionResult> GetUserRole([FromRoute] GetUserRoleRequest request)
        {
            return this.HandleRequest<GetUserRoleRequest, GetUserRoleResponse>(request); 
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetRoles")]
        public Task<IActionResult> GetRoles([FromQuery] GetRolesRequest request)
        {
            return this.HandleRequest<GetRolesRequest, GetRolesResponse>(request);
        }

        [HttpGet]
        [Route("UsersWithRole")]
        public Task<IActionResult> GetUsersWithRole([FromQuery] GetUsersWithRoleRequest request)
        {
            return this.HandleRequest<GetUsersWithRoleRequest, GetUsersWithRoleResponse>(request);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("SetUserRoles")]
        public async Task<IActionResult> SetUsersRole([FromBody] SetUserRolesRequest request)
        {
            var context = this.HttpContext;
            var authHeader = context.Request.Headers["Authorization"];
            var user = context.User;
            return await this.HandleRequest<SetUserRolesRequest, SetUserRolesResponse>(request);
        }


        [HttpPost]
        [Route("SetUserRole")]
        public Task<IActionResult> SetUserRole([FromQuery] SetUserRoleRequest request)
        {
            return this.HandleRequest<SetUserRoleRequest, SetUserRoleResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Post([FromBody] ValidateUserRequest request)
        {
            return await this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return BadRequest(new RegisterResult { Successful = false, Errors = errors });
            }

            await _userManager.AddToRoleAsync(newUser, "User");

            return Ok(new RegisterResult { Successful = true });
        }
    }
}
