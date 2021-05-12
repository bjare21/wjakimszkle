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

namespace Wjakimszkle.ApplicationServices.API.Handlers.Drinks
{
    public class EditDrinkHandler : IRequestHandler<EditDrinkRequest, EditDrinkResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        public EditDrinkHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<EditDrinkResponse> Handle(EditDrinkRequest request, CancellationToken cancellationToken)
        {
            var command = new EditDrinkCommand()
            {
                Id = request.Id,
                Name = request.Name
            };

            var response = await this.commandExecutor.Execute(command);

            return new EditDrinkResponse()
            {
                Data = this.mapper.Map<Domain.Models.Drink>(response)
            };
        }
    }
}
