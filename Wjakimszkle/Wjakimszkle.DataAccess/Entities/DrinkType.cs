using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.DataAccess.Entities
{
    public class DrinkType:EntityBase
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public List<Drink> Drinks { get; set; }
        public List<Glass> Glasses { get; set; }
        public List<Dish> Dishes { get; set; }
    }

    public enum Genre
    {
        Beer,
        Wine,
        Whiskey,
        Vodka,
        Cider,
        Mead,
        Sake,
        Gin,
        Brandy,
        Rum,
        Tequila,
        Absinthe,
        Everclear
    }
}
