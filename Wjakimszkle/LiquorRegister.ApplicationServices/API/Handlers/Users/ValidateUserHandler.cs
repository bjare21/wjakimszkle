using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Users;
using Wjakimszkle.ApplicationServices.API.Security;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Users
{
    public class ValidateUserHandler:IRequestHandler<ValidateUserRequest, ValidateUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        public ValidateUserHandler(IMapper mapper, IQueryExecutor queryExecutor, IPasswordHasher passwordHasher)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
        }

        public async Task<ValidateUserResponse> Handle(ValidateUserRequest request, CancellationToken cancallationToken)
        {
            var query = new GetUserQuery()
            {
                Username = request.Username
            };

            var user = await this.queryExecutor.Execute(query);

            var response = new ValidateUserResponse();
            if (user == null)
            {
                response.Error = new Domain.ErrorModel("USER_NOT_FOUND");
                return response;
            }

            if (!this.passwordHasher.Verify(user.Password, request.Password))
            {
                response.Error = new Domain.ErrorModel("AUTHENTICATION_ERROR");
                return response;
            }

            response.Data = this.mapper.Map<Domain.Models.User>(user);

            return response;
        }
    }
}
