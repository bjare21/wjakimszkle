using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Drinks;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Commands;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Drinks
{
    public class AddDrinkHandler : IRequestHandler<AddDrinkRequest, AddDrinkResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddDrinkHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddDrinkResponse> Handle(AddDrinkRequest request, CancellationToken cancellationToken)
        {
            var drink = this.mapper.Map<Drink>(request);
            var command = new AddDrinkCommand()
            {
                Parameter = drink,
                DrinkTypeId = request.DrinkTypeId
            };

            var response = await this.commandExecutor.Execute(command);

            return new AddDrinkResponse()
            {
                Data = this.mapper.Map<ApplicationServices.API.Domain.Models.Drink>(response)
            };
        }
    }
}
