using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Glasses;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Commands;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Glasses
{
    public class EditGlassHandler : IRequestHandler<EditGlassRequest, EditGlassResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public EditGlassHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<EditGlassResponse> Handle(EditGlassRequest request, CancellationToken cancellationToken)
        {
            var glass = this.mapper.Map<DataAccess.Entities.Glass>(request);
            var command = new EditGlassCommand()
            {
                Parameter = glass
            };
            var response = await this.commandExecutor.Execute(command);
            return new EditGlassResponse()
            {
                Data = this.mapper.Map<ApplicationServices.API.Domain.Models.Glass>(response)
            };
        }
    }
}
