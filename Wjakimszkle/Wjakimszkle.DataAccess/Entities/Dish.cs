using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.DataAccess.Entities
{
    public class Dish:EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public List<DrinkType> DrinkTypes { get; set; }
    }
}
