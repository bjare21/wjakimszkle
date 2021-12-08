using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Models;

namespace Wjakimszkle.ApplicationServices.API.Domain.Dishes
{
    public class PairDrinkTypesWithDishRequest:RequestBase<PairDrinkTypesWithDishResponse>
    {
        public int Id { get; set; }

        public List<DrinkType> DrinkTypes { get; set; }
    }
}
