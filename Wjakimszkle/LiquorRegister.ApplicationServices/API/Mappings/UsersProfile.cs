using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
            this.CreateMap<ApplicationUser, Domain.Models.User>()
                .ForMember(u=>u.Id, x=>x.MapFrom(r=>r.Id))
                .ForMember(u => u.Username, x => x.MapFrom(r => r.UserName))
                .ForMember(u => u.Email, x => x.MapFrom(r => r.Email))
                .ForMember(u => u.FirstName, x => x.MapFrom(r => r.FirstName))
                .ForMember(u => u.LastName, x => x.MapFrom(r => r.LastName))
                .ForMember(u => u.RegisterDate, x => x.MapFrom(r => r.RegisterDate));

            //this.CreateMap<CreateUserRequest, User>()
            //    .ForMember(u => u.FirstName, x => x.MapFrom(r => r.FirstName))
            //    .ForMember(u => u.LastName, x => x.MapFrom(r => r.LastName))
            //    .ForMember(u => u.Username, x => x.MapFrom(r => r.Username))
            //    .ForMember(u => u.Email, x => x.MapFrom(r => r.Email))
            //    .ForMember(u => u.Role, x => x.MapFrom(r => r.Role))
            //    .ForMember(u=>u.RegisterDate, x=>x.MapFrom(r=>r.RegisterDate))
            //    ;


            //this.CreateMap<User, Domain.Models.User>()
            //    .ForMember(d => d.FirstName, e => e.MapFrom(u => u.FirstName))
            //    .ForMember(d => d.LastName, e => e.MapFrom(u => u.LastName))
            //    .ForMember(d => d.Username, e => e.MapFrom(u => u.Username))
            //    .ForMember(d => d.Password, e => e.MapFrom(u => u.Password))
            //    .ForMember(d => d.Role, e => e.MapFrom(u => Enum.GetName(u.Role)))
            //    .ForMember(d => d.RegisterDate, e => e.MapFrom(u => u.RegisterDate));


        }
    }
}
