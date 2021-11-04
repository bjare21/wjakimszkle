using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Users;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Users
{
    public class SetUserRoleHandler:IRequestHandler<SetUserRoleRequest, SetUserRoleResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public SetUserRoleHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<SetUserRoleResponse> Handle(SetUserRoleRequest request, CancellationToken cancellationToken)
        {
            var user = userManager.Users.FirstOrDefault(u => u.UserName == request.UserName);

            var result = await userManager.AddToRoleAsync(user, request.RoleName);

            var response = new SetUserRoleResponse();

            if (result.Succeeded)
            {
                response.Data = this.mapper.Map<Domain.Models.User>(user);
            }
            else
            {
                response.Error = new ErrorModel(result.Errors.First().Code);
            }

            return response;
        }
    }
}
