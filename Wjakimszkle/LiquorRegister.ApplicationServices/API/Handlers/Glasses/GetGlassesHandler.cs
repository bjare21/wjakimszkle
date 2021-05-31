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
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Glasses
{
    public class GetGlassesHandler : IRequestHandler<GetGlassesRequest, GetGlassesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetGlassesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetGlassesResponse> Handle(GetGlassesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGlassesQuery();

            var glasses = await this.queryExecutor.Execute(query);

            var response = new GetGlassesResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.Glass>>(glasses)
            };

            return response;
        }

    }
}
