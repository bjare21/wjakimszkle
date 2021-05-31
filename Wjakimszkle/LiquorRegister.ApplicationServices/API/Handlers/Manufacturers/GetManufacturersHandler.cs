using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Manufacturers;
using Wjakimszkle.ApplicationServices.API.Domain.Models;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Manufacturers
{
    public class GetManufacturersHandler:IRequestHandler<GetManufacturersRequest, GetManufacturersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetManufacturersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetManufacturersResponse> Handle(GetManufacturersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetManufacturersQuery();
            var manufacturers = await this.queryExecutor.Execute(query);

            return new GetManufacturersResponse()
            {
                Data = this.mapper.Map<List<Manufacturer>>(manufacturers)
            };
        }
    }
}
