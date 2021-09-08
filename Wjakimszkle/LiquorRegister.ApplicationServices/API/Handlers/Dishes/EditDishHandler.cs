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
    public class EditDishHandler : IRequestHandler<EditDishRequest, EditDishResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public EditDishHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<EditDishResponse> Handle(EditDishRequest request, CancellationToken cancellationToken)
        {
            var dish = this.mapper.Map<Dish>(request);
            var command = new EditDishCommand()
            {
                Parameter = dish
            };

            var response = await this.commandExecutor.Execute(command);

            var editResponse = new EditDishResponse();

            if (response == null)
            {
                editResponse.Error = new Domain.ErrorModel("DISH_NOT_FOUND");
            }

            editResponse.Data = this.mapper.Map<Domain.Models.Dish>(response);


            return editResponse;
        }
    }

}
