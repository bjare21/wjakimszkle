using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Drinks;
using Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Commands;
using Wjakimszkle.DataAccess.CQRS.Queries;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Drinks
{
    public class EditDrinkHandler : IRequestHandler<EditDrinkRequest, EditDrinkResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        public EditDrinkHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<EditDrinkResponse> Handle(EditDrinkRequest request, CancellationToken cancellationToken)
        {
            var drinkTypeQuery = new GetDrinkTypeByIdQuery()
            {
                Id = request.DrinkTypeId
            };

            var dtResponse = this.queryExecutor.Execute(drinkTypeQuery);

            //TUTAJ SIĘ ZATRZYMAŁEM

            var command = new EditDrinkCommand()
            {
                Parameter = this.mapper.Map<Drink>(request),
                DrinkType = this.mapper.Map<DrinkType>(dtResponse)
            };

            var response = await this.commandExecutor.Execute(command);

            return new EditDrinkResponse()
            {
                Data = this.mapper.Map<Domain.Models.Drink>(response)
            };
        }
    }
}
