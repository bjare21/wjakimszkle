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
using Wjakimszkle.DataAccess.Paging;

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

            var mappedGlasses = this.mapper.Map<List<Domain.Models.Glass>>(glasses);

            PagedList<Domain.Models.Glass> list =
                PagedList<Domain.Models.Glass>
                .ToPagedList(
                    mappedGlasses,
                    request.ItemParameters.PageNumber,
                    request.ItemParameters.PageSize
                    );

            var response = new GetGlassesResponse()
            {
                Data = list
            };

            return response;
        }

    }
}
