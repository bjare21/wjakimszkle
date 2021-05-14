using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Domain.Models
{
    public class Glass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Drinks { get; set; }
    }
}
