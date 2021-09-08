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
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Dishes
{
    public class GetDishByIdHandler : IRequestHandler<GetDishByIdRequest, GetDishByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDishByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDishByIdResponse> Handle(GetDishByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDishByIdQuery()
            {
                Id = request.Id
            };

            var dish = await this.queryExecutor.Execute(query);

            var response = new GetDishByIdResponse();

            if (dish == null)
            {
                response.Error = new Domain.ErrorModel("DISH_NOT_FOUND");
            }
            else
            {
                response.Data = dish;
            }
            return response;
        }
    }
}
