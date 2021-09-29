﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Users;
using Wjakimszkle.ApplicationServices.API.Domain.Users.Models;

namespace Wjakimszkle.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersController(IMediator mediator, UserManager<IdentityUser> userManager) : base(mediator)
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

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return Ok(new RegisterResult { Successful = false, Errors = errors });
            }
            return Ok(new RegisterResult { Successful = true });
        }
    }
}
