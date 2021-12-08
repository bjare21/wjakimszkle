using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.Shared.QueryFeatures
{
    public class DrinksParameters:ItemParameters
    {
        public string SearchName { get; set; }
        public int SearchDrinkTypeId { get; set; }
    }
}
