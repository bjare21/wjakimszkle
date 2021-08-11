using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Drinks;
using Wjakimszkle.ApplicationServices.Components.CocktailDb;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Drinks
{
    public class GetCocktailsByGlassNameHandler:IRequestHandler<GetCocktailsByGlassNameRequest, GetCocktailsByGlassNameResponse>
    {
        private readonly IMapper mapper;
        private readonly ICocktailDbConnector connector;
        private readonly ILogger<GetCocktailsByGlassNameHandler> logger;

        public GetCocktailsByGlassNameHandler(IMapper mapper, ICocktailDbConnector connector, ILogger<GetCocktailsByGlassNameHandler> logger)
        {
            this.mapper = mapper;
            this.connector = connector;
            this.logger = logger;
        }

        public async Task<GetCocktailsByGlassNameResponse> Handle(GetCocktailsByGlassNameRequest request, CancellationToken cancellationToken)
        {
            var cocktailObject = await this.connector.Fetch(request.Name);

            this.logger.LogInformation(message: $"Wysłano zapytanie do zewnętrznego serwisu, w odpowiedzi uzyskano {cocktailObject.Drinks.Count} elementów. ");

            var drinks = this.mapper.Map<List<Domain.Models.Drink>>(cocktailObject.Drinks);

            return new GetCocktailsByGlassNameResponse()
            {
                Data = drinks
            };
        }
    }
}
