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
    public class GetUserRoleHandler : IRequestHandler<GetUserRoleRequest, GetUserRoleResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public GetUserRoleHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<GetUserRoleResponse> Handle(GetUserRoleRequest request, CancellationToken cancellationToken)
        {
            GetUserRoleResponse response = new GetUserRoleResponse();

            List<Domain.Models.Role> roles = new List<Domain.Models.Role>();

            if (!string.IsNullOrEmpty(request.Id))
            {
                var user = userManager.Users.FirstOrDefault(u => u.Id == request.Id);
                if (user != null)
                {
                    var userRoles = await userManager.GetRolesAsync(user);
                    if (userRoles.Count > 0)
                    {
                        roles.AddRange(
                            userRoles.Select(
                                u => new Domain.Models.Role { Name = u }));
                    }
                    response.Data = roles;
                    return response;
                }
            }
            response.Error = new ErrorModel("NOT_FOUND");
            return response;
        }
    }
}
