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
    }
}
