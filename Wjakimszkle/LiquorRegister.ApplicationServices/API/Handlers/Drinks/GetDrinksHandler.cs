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
using Wjakimszkle.ApplicationServices.Components.CocktailDb;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;
using Wjakimszkle.DataAccess.Entities;
using Wjakimszkle.Shared.QueryFeatures;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Drinks
{
    public class GetDrinksHandler:IRequestHandler<GetDrinksRequest, GetDrinksResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        private readonly ICocktailDbConnector cocktailDbConnector;
        public GetDrinksHandler(IMapper mapper, IQueryExecutor queryExecutor, ICocktailDbConnector cocktailDbConnector)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
            this.cocktailDbConnector = cocktailDbConnector;
        }
        public async Task<GetDrinksResponse> Handle(GetDrinksRequest request, CancellationToken cancellationToken)
        {
            //var cocktails = await this.cocktailDbConnector.Fetch("Cocktail_glass");

            

            var query = new GetDrinksQuery()
            {
                ItemParameters = request.ItemParameters
            };

            var drinks = await this.queryExecutor.Execute(query);
            var mappedDrink = this.mapper.Map<List<Domain.Models.Drink>>(drinks);

            //var domainDrinks = drinks.Select(d => new Domain.Models.Drink()
            //{
            //    Id = d.Id,
            //    Name = d.Name
            //});

            PagedList<Domain.Models.Drink> list =
                PagedList<Domain.Models.Drink>
                .ToPagedList(
                    mappedDrink, 
                request.ItemParameters.PageNumber,
                request.ItemParameters.PageSize
                );

            var response = new GetDrinksResponse()
            {
                Data = list
            };

            return response;
        }
    }
}
