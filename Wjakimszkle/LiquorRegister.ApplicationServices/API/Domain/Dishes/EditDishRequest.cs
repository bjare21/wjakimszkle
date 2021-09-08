using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Dishes
{
    public class EditDishRequest:RequestBase<EditDishResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
