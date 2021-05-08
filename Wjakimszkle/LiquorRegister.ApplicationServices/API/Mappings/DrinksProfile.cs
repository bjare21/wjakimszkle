using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Models;

namespace Wjakimszkle.ApplicationServices.API.Mappings
{
    public class DrinksProfile:Profile
    {
        public DrinksProfile()
        {
            this.CreateMap<DataAccess.Entities.Drink, Drink>()
                .ForMember(d => d.Id, m => m.MapFrom(r => r.Id))
                .ForMember(d => d.Name, m => m.MapFrom(r => r.Name));
        }
    }
}
