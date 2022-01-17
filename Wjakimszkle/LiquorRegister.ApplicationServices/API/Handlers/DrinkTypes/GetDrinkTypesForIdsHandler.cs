using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes;
using Wjakimszkle.ApplicationServices.API.Domain.Models;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers.DrinkTypes
{
    public class GetDrinkTypesForIdsHandler:IRequestHandler<GetDrinkTypesForIdsRequest, GetDrinkTypesForIdsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDrinkTypesForIdsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDrinkTypesForIdsResponse> Handle(GetDrinkTypesForIdsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDrinkTypesForIdsQuery
            {
                Ids = request.Ids.Select(i => int.Parse(i)).ToArray()
            };

            var drinkTypes = await this.queryExecutor.Execute(query);

            var mapped = this.mapper.Map<List<DrinkType>>(drinkTypes);

            return new GetDrinkTypesForIdsResponse
            {
                Data = mapped
            };
        }
    }
}
