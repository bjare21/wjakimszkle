using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Dishes;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Commands;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Dishes
{
    class PairDrinkTypesWithDishHandler:IRequestHandler<PairDrinkTypesWithDishRequest, PairDrinkTypesWithDishResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PairDrinkTypesWithDishHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PairDrinkTypesWithDishResponse> Handle(PairDrinkTypesWithDishRequest request, CancellationToken cancellationToken)
        {
            var command = new AddDrinkTypesPairingsToDishCommand
            {
                DrinkTypesPaired = request.DrinkTypes.Select(dt=>dt.Id.ToString()).ToList(),
                Id = request.Id
            };

            var result = await this.commandExecutor.Execute(command);

            var domainDish = this.mapper.Map<Domain.Models.Dish>(result);

            return new PairDrinkTypesWithDishResponse() { Data = domainDish };
        }
    }
}
