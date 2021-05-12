using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers
{
    public class GetDrinkByIdHandler : IRequestHandler<GetDrinkByIdRequest, GetDrinkByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDrinkByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDrinkByIdResponse> Handle(GetDrinkByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDrinkQuery()
            {
                Id = request.DrinkId
            };

            var drink = await this.queryExecutor.Execute(query);
            var mappedDrink = this.mapper.Map<Domain.Models.Drink>(drink);
            var response = new GetDrinkByIdResponse()
            {
                Data = mappedDrink
            };
            return response;
        }
    }
}
