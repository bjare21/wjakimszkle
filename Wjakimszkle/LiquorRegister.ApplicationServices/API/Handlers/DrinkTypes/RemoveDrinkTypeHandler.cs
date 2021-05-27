using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Commands;

namespace Wjakimszkle.ApplicationServices.API.Handlers.DrinkTypes
{
    public class RemoveDrinkTypeHandler:IRequestHandler<RemoveDrinkTypeRequest, RemoveDrinkTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public RemoveDrinkTypeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveDrinkTypeResponse> Handle(RemoveDrinkTypeRequest request, CancellationToken cancellationToken)
        {
            var command = new RemoveDrinkTypeCommand()
            {
                Parameter = request.Id
            };

            var removedDrinkType = await this.commandExecutor.Execute(command);
            return new RemoveDrinkTypeResponse()
            {
                Data = this.mapper.Map<ApplicationServices.API.Domain.Models.DrinkType>(removedDrinkType)
            };

        }
    }
}
