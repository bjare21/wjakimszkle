using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers.DrinkTypes
{
    public class GetDrinkTypeWithRelatedFieldsHandler : IRequestHandler<GetDrinkTypeWithRelatedFieldsRequest, GetDrinkTypeWithRelatedFieldsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDrinkTypeWithRelatedFieldsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDrinkTypeWithRelatedFieldsResponse> Handle(GetDrinkTypeWithRelatedFieldsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDrinkTypeWithRelatedFieldsQuery
            {
                Id = int.Parse(request.Id)
            };

            var drinkType = await this.queryExecutor.Execute(query);

            if (drinkType == null)
            {
                return new GetDrinkTypeWithRelatedFieldsResponse
                {
                    Error = new Domain.ErrorModel("NOT_FOUND")
                };
            }

            var drinkTypeDomain = this.mapper.Map<Domain.Models.DrinkType>(drinkType);

            return new GetDrinkTypeWithRelatedFieldsResponse
            {
                Data = drinkTypeDomain
            };
        }
    }
}
