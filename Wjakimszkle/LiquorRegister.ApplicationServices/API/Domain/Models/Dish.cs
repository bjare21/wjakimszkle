using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public List<DrinkType> DrinkTypes { get; set; } = new List<DrinkType>();
    }
}
