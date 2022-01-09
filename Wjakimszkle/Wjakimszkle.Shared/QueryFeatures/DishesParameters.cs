using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.Shared.QueryFeatures
{
    public class DishesParameters:ItemParameters
    {
        /// <summary>
        /// Id rodzaju drinka z jakim sparowane są wyszukiwane dania
        /// </summary>
        public int DrinkTypeId { get; set; }
    }
}
