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
    public class GetDishesHandler:IRequestHandler<GetDishesRequest, GetDishesResponse>
    {
        private readonly IRepository<Dish> dishRepository;
        public GetDishesHandler(IRepository<Dish> dishRepository)
        {
            this.dishRepository = dishRepository;
        }

        public async Task<GetDishesResponse> Handle(GetDishesRequest request, CancellationToken cancellationToken)
        {
            var dishes = await this.dishRepository.GetAll();
            var domainDishes = dishes.Select(d => new Domain.Models.Dish()
            {
                Id = d.Id,
                Name = d.Name
            });

            var response = new GetDishesResponse()
            {
                Data = domainDishes.ToList()
            };

            return response;
        }
    }
}
