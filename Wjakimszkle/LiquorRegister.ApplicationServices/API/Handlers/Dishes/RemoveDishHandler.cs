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
    public class RemoveDishHandler:IRequestHandler<RemoveDishRequest,RemoveDishResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public RemoveDishHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveDishResponse> Handle(RemoveDishRequest request, CancellationToken cancellationToken)
        {
            var dish = this.mapper.Map<Dish>(request);

            var command = new RemoveDishCommand()
            {
               Parameter = dish
            };

            var response = await this.commandExecutor.Execute(command);

            return new RemoveDishResponse()
            {
                Data = this.mapper.Map<Domain.Models.Dish>(response)
            };
        }
    }
}
