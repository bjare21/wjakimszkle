using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Users;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Mappings
{
    public class UsersProfile:Profile
    {
        public UsersProfile()
        {
            this.CreateMap<CreateUserRequest, User>()
                .ForMember(u => u.FirstName, x => x.MapFrom(r => r.FirstName))
                .ForMember(u => u.LastName, x => x.MapFrom(r => r.LastName))
                .ForMember(u => u.Username, x => x.MapFrom(r => r.Username))
                .ForMember(u=>u.Email, x=>x.MapFrom(r=>r.Email))
                .ForMember(u => u.Password, x => x.MapFrom(r => r.Password));


            this.CreateMap<User, Domain.Models.User>()
                .ForMember(d => d.FirstName, e => e.MapFrom(u => u.FirstName))
                .ForMember(d => d.LastName, e => e.MapFrom(u => u.LastName))
                .ForMember(d => d.Username, e => e.MapFrom(u => u.Username))
                .ForMember(d => d.Password, e => e.MapFrom(u => u.Password));
        }
    }
}
