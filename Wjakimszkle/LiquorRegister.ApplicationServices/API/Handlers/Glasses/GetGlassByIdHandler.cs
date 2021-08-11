using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Glasses;
using Wjakimszkle.ApplicationServices.API.ErrorHandling;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Glasses
{
    public class GetGlassByIdHandler:IRequestHandler<GetGlassByIdRequest, GetGlassByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetGlassByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetGlassByIdResponse> Handle(GetGlassByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGlassByIdQuery()
            {
                Id = request.Id
            };

            var glass = await this.queryExecutor.Execute(query);

            if (glass == null)
            {
                return new GetGlassByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var response = new GetGlassByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Glass>(glass)
            };

            return response;
        }
    }
}
