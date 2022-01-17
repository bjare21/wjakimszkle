using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float AlcoholByVolume { get; set; }

        public string DrinkTypeName { get; set; }
        public int DrinkTypeId { get; set; }

        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public List<Glass> Glasses { get; set; } = new List<Glass>();

        public int ServingTemperature { get; set; }
    }
}
