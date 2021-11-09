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
using Wjakimszkle.DataAccess.Paging;

namespace Wjakimszkle.ApplicationServices.API.Handlers.DrinkTypes
{
    public class GetAllDrinkTypesHandler : IRequestHandler<GetAllDrinkTypesRequest, GetAllDrinkTypesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllDrinkTypesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllDrinkTypesResponse> Handle(GetAllDrinkTypesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllDrinkTypesQuery();
            var drinkTypes = await this.queryExecutor.Execute(query);
            var mappedDrinkTypes = this.mapper.Map<List<DrinkType>>(drinkTypes);

            PagedList<Domain.Models.DrinkType> types =
                PagedList<Domain.Models.DrinkType>
                .ToPagedList(
                    mappedDrinkTypes,
                    request.ItemParameters.PageNumber,
                    request.ItemParameters.PageSize
                    );

            return new GetAllDrinkTypesResponse()
            {
                Data = types
            };
        }
    }
}
