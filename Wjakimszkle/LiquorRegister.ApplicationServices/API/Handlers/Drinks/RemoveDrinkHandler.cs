using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Drinks;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Commands;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Drinks
{
    public class RemoveDrinkHandler : IRequestHandler<RemoveDrinkRequest, RemoveDrinkResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public RemoveDrinkHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveDrinkResponse> Handle(RemoveDrinkRequest request, CancellationToken cancellationToken)
        {
            var command = new RemoveDrinkCommand()
            {
                Id = request.Id
            };

            var removedDrink = await this.commandExecutor.Execute(command);

            return new RemoveDrinkResponse()
            {
                Data = this.mapper.Map<Domain.Models.Drink>(removedDrink)
            };
    }
    }
}
