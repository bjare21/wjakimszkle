using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Handlers
{
    public class GetGlassesHandler : IRequestHandler<GetGlassesRequest, GetGlassesResponse>
    {
        private readonly IRepository<Glass> glassRepository;

        public GetGlassesHandler(IRepository<Glass> glassRepository)
        {
            this.glassRepository = glassRepository;
        }

        public Task<GetGlassesResponse> Handle(GetGlassesRequest request, CancellationToken cancellationToken)
        {
            var glasses = this.glassRepository.GetAll();
            var domainGlasses = glasses.Select(g => new Domain.Models.Glass()
            {
                Id = g.Id,
                Name = g.Name
            });

            var response = new GetGlassesResponse()
            {
                Data = domainGlasses.ToList()
            };

            return Task.FromResult(response);
        }

    }
}
