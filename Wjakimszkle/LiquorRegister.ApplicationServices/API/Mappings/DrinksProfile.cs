using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Drinks;
using Wjakimszkle.ApplicationServices.API.Domain.Models;

namespace Wjakimszkle.ApplicationServices.API.Mappings
{
    public class DrinksProfile:Profile
    {
        public DrinksProfile()
        {
            this.CreateMap<AddDrinkRequest, DataAccess.Entities.Drink>()
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.AlcoholByVolume, b => b.MapFrom(c => c.AlcoholByVolume));

            this.CreateMap<EditDrinkRequest, DataAccess.Entities.Drink>()
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.AlcoholByVolume, b => b.MapFrom(c => c.AlcoholByVolume))
                .ForMember(a => a.DrinkType, b => b.MapFrom(b=>new DrinkType() { Id =  b.DrinkTypeId }));

            this.CreateMap<DataAccess.Entities.Drink, Drink>()
                .ForMember(d => d.Id, m => m.MapFrom(r => r.Id))
                .ForMember(d => d.Name, m => m.MapFrom(r => r.Name))
                .ForMember(d => d.AlcoholByVolume, m => m.MapFrom(r => r.AlcoholByVolume))
                .ForMember(d => d.DrinkTypeName, m => m.MapFrom(r => r.DrinkType.Name));
        }
    }
}
