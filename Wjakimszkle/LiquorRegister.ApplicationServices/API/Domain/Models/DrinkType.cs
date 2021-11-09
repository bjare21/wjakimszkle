using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;
using Wjakimszkle.Shared.Models.Drinks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Models
{
    public class DrinkType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
    }
}
