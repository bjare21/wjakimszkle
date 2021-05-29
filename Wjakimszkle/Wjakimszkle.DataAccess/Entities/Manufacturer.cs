using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.DataAccess.Entities
{
    public class Manufacturer: EntityBase
    {
        public string Name { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
