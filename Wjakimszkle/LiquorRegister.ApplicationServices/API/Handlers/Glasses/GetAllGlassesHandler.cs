using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Glasses;
using Wjakimszkle.ApplicationServices.API.Domain.Models;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Glasses
{
    public class GetAllGlassesHandler : IRequestHandler<GetAllGlassesRequest, GetAllGlassesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllGlassesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllGlassesResponse> Handle(GetAllGlassesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllGlassesQuery() { };
            var glasses = await this.queryExecutor.Execute(query);
            if (glasses == null)
            {
                return new GetAllGlassesResponse()
                {
                    Error = new Domain.ErrorModel(
                        "NOT_FOUND"
                        )
                };
            }
            var domainGlasses = this.mapper.Map<List<Glass>>(glasses);

            return new GetAllGlassesResponse()
            {
                Data = domainGlasses
            };
        }
    }
}
