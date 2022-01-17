using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes
{
    public class EditDrinkTypeRequest:RequestBase<EditDrinkTypeResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Genre { get; set; }

        public List<string> Glasses { get; set; }
    }
}
