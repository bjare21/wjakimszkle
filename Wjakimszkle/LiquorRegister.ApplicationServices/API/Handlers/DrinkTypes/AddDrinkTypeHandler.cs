using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Commands;

namespace Wjakimszkle.ApplicationServices.API.Handlers.DrinkTypes
{
    public class AddDrinkTypeHandler:IRequestHandler<AddDrinkTypeRequest, AddDrinkTypeResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddDrinkTypeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddDrinkTypeResponse> Handle(AddDrinkTypeRequest request, CancellationToken cancellationToken)
        {
            var drinkType = this.mapper.Map<DataAccess.Entities.DrinkType>(request);
            var command = new AddDrinkTypeCommand() { 
                Parameter = drinkType,
                GlassesIds = request.GlassesIds.Select(g=>Int32.Parse(g)).ToList()
            };
            var drinkTypeDb = await this.commandExecutor.Execute(command);

            return new AddDrinkTypeResponse()
            {
                Data = this.mapper.Map<ApplicationServices.API.Domain.Models.DrinkType>(drinkTypeDb)
            };
        }
    }
}
