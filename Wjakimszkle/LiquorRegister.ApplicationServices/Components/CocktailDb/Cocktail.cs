using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wjakimszkle.ApplicationServices.Components.CocktailDb
{
    public class Cocktail
    {
        [JsonProperty("Ingredients")]
       public List<Ingredients> Ingredients { get; set; }
    }

    public class Ingredients
    {
        public string idIngredient { get; set; }
        [JsonProperty("strIngredient")]
        public string Name { get; set; }
    }
}