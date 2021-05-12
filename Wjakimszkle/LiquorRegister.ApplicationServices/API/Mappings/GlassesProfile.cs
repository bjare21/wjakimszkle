using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain;
using Wjakimszkle.ApplicationServices.API.Domain.Models;

namespace Wjakimszkle.ApplicationServices.API.Mappings
{
    public class GlassesProfile : Profile
    {
        public GlassesProfile()
        {
            this.CreateMap<AddGlassRequest, DataAccess.Entities.Glass>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<DataAccess.Entities.Glass, Glass>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

        }
    }

}
