using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Dishes;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Dishes
{
    public class GetDishesHandler:IRequestHandler<GetDishesRequest, GetDishesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetDishesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDishesResponse> Handle(GetDishesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllDishesQuery();

            var dishes = await this.queryExecutor.Execute(query);

            var mappedDishes = this.mapper.Map<List<Domain.Models.Dish>>(dishes);

            var response = new GetDishesResponse()
            {
                Data = mappedDishes
            };

            return response;
        }
    }
}
