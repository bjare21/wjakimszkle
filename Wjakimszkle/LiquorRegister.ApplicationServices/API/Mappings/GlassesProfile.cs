using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Glasses;
using Wjakimszkle.ApplicationServices.API.Domain.Models;

namespace Wjakimszkle.ApplicationServices.API.Mappings
{
    public class GlassesProfile : Profile
    {
        public GlassesProfile()
        {
            this.CreateMap<AddGlassRequest, DataAccess.Entities.Glass>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<EditGlassRequest, DataAccess.Entities.Glass>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name));

            this.CreateMap<DataAccess.Entities.Glass, Glass>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Drinks, y => y.MapFrom(z => z.Drinks != null ? z.Drinks.Select(d => d.Name) : new List<string>()));

        }
    }

}
