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
    public class GetDrinksHandler:IRequestHandler<GetDrinksRequest, GetDrinksResponse>
    {
        private readonly IRepository<Drink> drinkRepository;
        public GetDrinksHandler(IRepository<Drink> drinkRepository)
        {
            this.drinkRepository = drinkRepository;
        }
        public Task<GetDrinksResponse> Handle(GetDrinksRequest request, CancellationToken cancellationToken)
        {
            var drinks = this.drinkRepository.GetAll();
            var domainDrinks = drinks.Select(d => new Domain.Models.Drink()
            {
                Id = d.Id,
                Name = d.Name
            });

            var response = new GetDrinksResponse()
            {
                Data = domainDrinks.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
