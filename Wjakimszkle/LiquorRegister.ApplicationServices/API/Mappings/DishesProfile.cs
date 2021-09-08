using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Dishes;
using Wjakimszkle.ApplicationServices.API.Domain.Models;

namespace Wjakimszkle.ApplicationServices.API.Mappings
{
    public class DishesProfile:Profile
    {
        public DishesProfile()
        {
            this.CreateMap<AddDishRequest, DataAccess.Entities.Dish>()
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name));

            this.CreateMap<DataAccess.Entities.Dish, Dish>()
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name));

            this.CreateMap<RemoveDishRequest, DataAccess.Entities.Dish>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id));

            this.CreateMap<DataAccess.Entities.Dish, Dish>()
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name));

            this.CreateMap<EditDishRequest, DataAccess.Entities.Dish>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name));

            this.CreateMap<Dish, Domain.Models.Dish>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name));
        }

    }
}
