using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.DataAccess.Entities
{
    public class Drink:EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public float AlcoholByVolume { get; set; }

        public DrinkType DrinkType { get; set; }

        public Manufacturer Manufacturer { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }

    
}
