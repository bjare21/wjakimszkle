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
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Drinks
{
    public class GetDrinksForDrinkTypesHandler:IRequestHandler<GetDrinksForDrinkTypesRequest, GetDrinksForDrinkTypesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDrinksForDrinkTypesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDrinksForDrinkTypesResponse> Handle(GetDrinksForDrinkTypesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDrinksForDrinkTypesQuery()
            {
                DrinkTypeIds = request.DrinkTypeIds
            };

            var drinks = await this.queryExecutor.Execute(query);

            var mappedDrinks = this.mapper.Map<List<Domain.Models.Drink>>(drinks);

            return new GetDrinksForDrinkTypesResponse()
            {
                Data = mappedDrinks
            };
        }
    }
}
