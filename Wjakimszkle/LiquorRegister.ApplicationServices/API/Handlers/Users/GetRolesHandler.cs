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

namespace Wjakimszkle.ApplicationServices.API.Handlers.Users
{
    public class GetRolesHandler:IRequestHandler<GetRolesRequest, GetRolesResponse>
    {
        private readonly IMapper mapper;
        private readonly RoleManager<IdentityRole> roleManager;

        public GetRolesHandler(IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            this.mapper = mapper;
            this.roleManager = roleManager;
        }

        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var roles = roleManager.Roles.ToList();

            var mappedRoles = this.mapper.Map<List<Domain.Models.Role>>(roles);

            return new GetRolesResponse
            {
                Data = mappedRoles
            };

        }
    }
}
