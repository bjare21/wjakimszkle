using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Mappings
{
    public class UsersProfile:Profile
    {
        public UsersProfile()
        {
            this.CreateMap<User, Domain.Models.User>()
                .ForMember(d => d.FirstName, e => e.MapFrom(u => u.FirstName))
                .ForMember(d => d.LastName, e => e.MapFrom(u => u.LastName))
                .ForMember(d => d.Username, e => e.MapFrom(u => u.Username))
                .ForMember(d => d.Password, e => e.MapFrom(u => u.Password));
        }
    }
}
