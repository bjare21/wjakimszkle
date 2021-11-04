using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Users;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Users
{
    public class GetUsersWithRoleHandler:IRequestHandler<GetUsersWithRoleRequest, GetUsersWithRoleResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public GetUsersWithRoleHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<GetUsersWithRoleResponse> Handle(GetUsersWithRoleRequest request, CancellationToken cancellationToken)
        {
            var roleName = request.RoleName;
            var users = await this.userManager.GetUsersInRoleAsync(roleName);

            var mappedUsers = this.mapper.Map<List<Domain.Models.User>>(users);

            return new GetUsersWithRoleResponse()
            {
                Data = mappedUsers
            };
        }
    }
}
