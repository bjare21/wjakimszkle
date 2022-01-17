using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.Shared.Models.Drinks;

namespace Wjakimszkle.DataAccess.Entities
{
    public class DrinkType:EntityBase
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public List<Drink> Drinks { get; set; } = new List<Drink>();
        public List<Glass> Glasses { get; set; } = new List<Glass>();
        public List<Dish> Dishes { get; set; } = new List<Dish>();

        public int ServingTemperature { get; set; }
    }

    
}
