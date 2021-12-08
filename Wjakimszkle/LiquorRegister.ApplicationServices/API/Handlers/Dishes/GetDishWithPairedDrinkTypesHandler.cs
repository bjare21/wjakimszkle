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
    public class GetDishWithPairedDrinkTypesHandler:IRequestHandler<GetDishWithPairedDrinkTypesRequest, GetDishWithPairedDrinkTypesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDishWithPairedDrinkTypesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDishWithPairedDrinkTypesResponse> Handle(GetDishWithPairedDrinkTypesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDishWithPairedDrinkTypesQuery()
            {
                Id = request.Id
            };

            var dish = await this.queryExecutor.Execute(query);
            var response = new GetDishWithPairedDrinkTypesResponse();
            if (dish == null)
            {
                response.Error = new Domain.ErrorModel("NOT_FOUND");
                return response;
            }
            var mappedDish = this.mapper.Map<Domain.Models.Dish>(dish);

            response.Data = mappedDish;
            return response;
        }
    }
}
