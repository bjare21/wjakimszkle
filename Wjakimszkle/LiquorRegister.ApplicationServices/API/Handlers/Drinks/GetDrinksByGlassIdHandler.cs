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
    public class GetDrinksByGlassIdHandler : IRequestHandler<GetDrinksByGlassIdRequest, GetDrinksByGlassIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDrinksByGlassIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetDrinksByGlassIdResponse> Handle(GetDrinksByGlassIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDrinksByGlassIdQuery()
            {
                GlassId = request.GlassId
            };

            var drinks = await this.queryExecutor.Execute(query);

            var mappedDrinks = this.mapper.Map<List<Domain.Models.Drink>>(drinks);

            return new GetDrinksByGlassIdResponse()
            {
                Data = mappedDrinks
            };
        }
    }
}
