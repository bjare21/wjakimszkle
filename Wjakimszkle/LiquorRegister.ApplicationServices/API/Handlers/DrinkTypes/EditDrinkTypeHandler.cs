using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes;
using Wjakimszkle.ApplicationServices.API.ErrorHandling;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Commands;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.DrinkTypes
{
    public class EditDrinkTypeHandler : IRequestHandler<EditDrinkTypeRequest, EditDrinkTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public EditDrinkTypeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<EditDrinkTypeResponse> Handle(EditDrinkTypeRequest request, CancellationToken cancellationToken)
        {
            var command = new EditDrinkTypeCommand()
            {
                Parameter = this.mapper.Map<DrinkType>(request),
                GlassesIds = request.Glasses
            };

            var result = await this.commandExecutor.Execute(command);

            if (result == null)
            {
                return new EditDrinkTypeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new EditDrinkTypeResponse()
            {
                Data = this.mapper.Map<Domain.Models.DrinkType>(result)
            };
        }
    }
}
