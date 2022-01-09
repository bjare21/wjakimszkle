using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.Shared.QueryFeatures
{
    public class GlassesParameters:ItemParameters
    {
        /// <summary>
        /// Id rodzaju drinka dla którego wyszukiwane są szklanki.
        /// </summary>
        public int DrinkTypeId { get; set; }
    }
}
