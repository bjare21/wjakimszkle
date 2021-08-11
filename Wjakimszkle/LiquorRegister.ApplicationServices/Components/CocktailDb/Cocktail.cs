using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wjakimszkle.ApplicationServices.Components.CocktailDb
{
    public class Cocktail
    {
        [JsonProperty("Drinks")]
       public List<Drink> Drinks { get; set; }
    }

    public class Drink
    {
        [JsonProperty("idDrink")]
        public string Id { get; set; }
        [JsonProperty("strDrink")]
        public string Name { get; set; }
    }
}