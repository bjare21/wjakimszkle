using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Mappings
{
    public class RolesProfile:Profile
    {
        public RolesProfile()
        {
            this.CreateMap<IdentityRole, Domain.Models.Role>()
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name));
        }
    }
}
