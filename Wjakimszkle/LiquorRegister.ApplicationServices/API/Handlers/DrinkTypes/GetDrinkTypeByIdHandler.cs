using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes;
using Wjakimszkle.ApplicationServices.API.ErrorHandling;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.DrinkTypes
{
    public class GetDrinkTypeByIdHandler:IRequestHandler<GetDrinkTypeByIdRequest, GetDrinkTypeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDrinkTypeByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDrinkTypeByIdResponse> Handle(GetDrinkTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDrinkTypeByIdQuery()
            {
                Id = request.Id
            };

            var drinkType =  await this.queryExecutor.Execute(query);

            if (drinkType == null)
            {
                return new GetDrinkTypeByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetDrinkTypeByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.DrinkType>(drinkType)
            };

        }
    }
}
