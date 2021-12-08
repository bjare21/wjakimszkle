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
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.Description, b => b.MapFrom(c => c.Description))
                .ForMember(a => a.ImageUrl, b => b.MapFrom(c => c.ImageUrl));

            this.CreateMap<DataAccess.Entities.Dish, Dish>()
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.Description, b => b.MapFrom(c => c.Description))
                .ForMember(a => a.ImageUrl, b => b.MapFrom(c => c.ImageUrl))
                .ForMember(a => a.DrinkTypes, b => b.MapFrom(c => c.DrinkTypes));

            this.CreateMap<RemoveDishRequest, DataAccess.Entities.Dish>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id));

            this.CreateMap<EditDishRequest, DataAccess.Entities.Dish>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.Description, b => b.MapFrom(c => c.Description))
                .ForMember(a => a.ImageUrl, b => b.MapFrom(c => c.ImageUrl));

        }

    }
}
