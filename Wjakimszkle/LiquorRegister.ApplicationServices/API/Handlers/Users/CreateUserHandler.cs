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
using Wjakimszkle.DataAccess.CQRS.Commands;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Users
{
    public class CreateUserHandler:IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IPasswordHasher passwordHasher;

        public CreateUserHandler(IMapper mapper, ICommandExecutor commandExecutor, IPasswordHasher passwordHasher)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.passwordHasher = passwordHasher;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            request.RegisterDate = DateTime.Now;

            var command = new CreateUserCommand()
            {
                Parameter = this.mapper.Map<User>(request)
            };

            command.Parameter.Password = this.passwordHasher.Hash(request.Password);

            var user = await this.commandExecutor.Execute(command);

            var response = new CreateUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(user)
            };

            return response;
        }
    }
}
