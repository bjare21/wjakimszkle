using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Drinks;
using Wjakimszkle.ApplicationServices.API.ErrorHandling;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Drinks
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

            if (drink == null)
            {
                return new GetDrinkByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDrink = this.mapper.Map<Domain.Models.Drink>(drink);
            var response = new GetDrinkByIdResponse()
            {
                Data = mappedDrink
            };
            return response;
        }
    }
}
