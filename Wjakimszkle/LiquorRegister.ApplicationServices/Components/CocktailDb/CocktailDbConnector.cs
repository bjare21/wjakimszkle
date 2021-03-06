using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.Components.CocktailDb
{
    public class CocktailDbConnector:ICocktailDbConnector
    {
        private readonly RestClient restClient;
        private readonly string apiKey = "22d8e5afd0msh1583b8d43be4940p17d966jsn175d20e5b4b9";
        private readonly string baseUrl = "https://the-cocktail-db.p.rapidapi.com/";

        public CocktailDbConnector()
        {
            this.restClient = new RestClient(baseUrl);
        }
        public async Task<Cocktail> Fetch(string glassName)
        {
            var request = new RestRequest($"filter.php?g={glassName}",Method.GET);
            
            request.AddHeader("x-rapidapi-key", $"{apiKey}");
            request.AddHeader("x-rapidapi-host", "the-cocktail-db.p.rapidapi.com");
            var queryResult = await restClient.ExecuteAsync(request);
            var cocktails = JsonConvert.DeserializeObject<Cocktail>(queryResult.Content);
            return cocktails;
        }
    }
}
