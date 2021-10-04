using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.DataAccess.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [DataType(DataType.Text)]
        [StringLength(maximumLength:50)]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [StringLength(maximumLength:50)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }
    }
}
