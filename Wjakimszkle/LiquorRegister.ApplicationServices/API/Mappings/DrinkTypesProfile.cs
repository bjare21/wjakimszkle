using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.DrinkTypes;

namespace Wjakimszkle.ApplicationServices.API.Mappings
{
    public class DrinkTypesProfile:Profile
    {
        public DrinkTypesProfile()
        {
            this.CreateMap<AddDrinkTypeRequest, DataAccess.Entities.DrinkType>()
                .ForMember(dt => dt.Name, r => r.MapFrom(p => p.Name));

            this.CreateMap<EditDrinkTypeRequest, DataAccess.Entities.DrinkType>()
                .ForMember(dt => dt.Name, r => r.MapFrom(p => p.Name));

            this.CreateMap<DataAccess.Entities.DrinkType, ApplicationServices.API.Domain.Models.DrinkType>()
                .ForMember(d => d.Name, e => e.MapFrom(p => p.Name))
                .ForMember(d => d.Id, e => e.MapFrom(p => p.Id));
        }
    }
}
