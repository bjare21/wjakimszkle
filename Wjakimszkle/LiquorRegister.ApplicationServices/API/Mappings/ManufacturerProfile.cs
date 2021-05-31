using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.ApplicationServices.API.Mappings
{
    public class ManufacturerProfile:Profile
    {
        public ManufacturerProfile()
        {
            this.CreateMap<Manufacturer, Domain.Models.Manufacturer>()
                .ForMember(m => m.Name, d => d.MapFrom(ma => ma.Name));
        }
    }
}
