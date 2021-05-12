using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Commands;

namespace Wjakimszkle.ApplicationServices.API.Handlers
{
    public class RemoveGlassHandler:IRequestHandler<RemoveGlassRequest, RemoveGlassResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        
        public RemoveGlassHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveGlassResponse> Handle(RemoveGlassRequest request, CancellationToken cancellationToken)
        {
            var command = new RemoveGlassCommand()
            {
                Id = request.Id
            };

            var removedGlass = await this.commandExecutor.Execute(command);

            var response = new RemoveGlassResponse()
            {
                Data = this.mapper.Map<ApplicationServices.API.Domain.Models.Glass>(removedGlass)
            };


            return response;
        }
    }
}
