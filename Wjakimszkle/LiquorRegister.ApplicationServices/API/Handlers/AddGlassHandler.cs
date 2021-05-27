using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Glasses;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Commands;

namespace Wjakimszkle.ApplicationServices.API.Handlers
{
    public class AddGlassHandler:IRequestHandler<AddGlassRequest, AddGlassResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddGlassHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddGlassResponse> Handle(AddGlassRequest request, CancellationToken cancellationToken)
        {
            var glass = this.mapper.Map<DataAccess.Entities.Glass>(request);
            var command = new AddGlassCommand() { Parameter = glass };
            var glassFromDb = await this.commandExecutor.Execute(command);

            return new AddGlassResponse()
            {
                Data = this.mapper.Map<ApplicationServices.API.Domain.Models.Glass>(glassFromDb)
            };

        }
    }
}
