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
using Wjakimszkle.Shared.QueryFeatures;

namespace Wjakimszkle.ApplicationServices.API.Handlers.DrinkTypes
{
    public class GetAllDrinkTypesPagedHandler : IRequestHandler<GetAllDrinkTypesPagedRequest, GetAllDrinkTypesPagedResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllDrinkTypesPagedHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllDrinkTypesPagedResponse> Handle(GetAllDrinkTypesPagedRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllDrinkTypesQuery();
            var allDrinkTypes = await this.queryExecutor.Execute(query);

            var mappedDrinkTypes = this.mapper.Map<List<Domain.Models.DrinkType>>(allDrinkTypes);

            var pagedDrinkTypes = PagedList<Domain.Models.DrinkType>
                .ToPagedList(mappedDrinkTypes,
                request.ItemParameters.PageNumber,
                request.ItemParameters.PageSize
                );

            var result = new GetAllDrinkTypesPagedResponse
            {
                Data = pagedDrinkTypes
            };

            return result;
        }
    }
}
