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
    public class GetUserHandler:IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public GetUserHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            GetUserResponse response = new GetUserResponse();

            if (!string.IsNullOrEmpty(request.Id))
            {
                var user = userManager.Users.FirstOrDefault(u => u.Id == request.Id);
                if (user != null)
                {
                    response.Data = this.mapper.Map<Domain.Models.User>(user);
                    return response;
                }
            }

            response.Error = new ErrorModel("NOT_FOUND");
            return response;
        }
    }
}
