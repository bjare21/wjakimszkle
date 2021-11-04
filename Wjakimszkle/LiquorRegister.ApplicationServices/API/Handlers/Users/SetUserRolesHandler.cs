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
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Users
{
    public class SetUserRolesHandler:IRequestHandler<SetUserRolesRequest, SetUserRolesResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public SetUserRolesHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<SetUserRolesResponse> Handle(SetUserRolesRequest request, CancellationToken cancellationToken)
        {
            SetUserRolesResponse response = new SetUserRolesResponse();

            var user = await userManager.FindByIdAsync(request.UserId);
            if ((user != null))
            {
                var presentRoles = await userManager.GetRolesAsync(user);
                var rolesToAdd = request.RolesNames.Where(r => !presentRoles.Contains(r));
                var rolesToRemove = presentRoles.Where(r => !request.RolesNames.Contains(r));
                await userManager.RemoveFromRolesAsync(user, rolesToRemove);
                var result = await userManager.AddToRolesAsync(user, rolesToAdd);
                

                response.Data = this.mapper.Map<Domain.Models.User>(user);
            }
            else
            {
                response.Error = new Domain.ErrorModel("NOT_FOUND");
            }
            return response;
        }
    }
}
