using ActivesAPI.Dtos;
using ActivesAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivesAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Computer, ComputerForShowDto>()
                .ForMember(d => d.LastUpdate, o =>
                o.MapFrom(s => s.LastUpdate.ToLocalTime().ToString()));
            CreateMap<ComputerNewDto, Computer>()
                .ForMember(d => d.LastUpdate, o =>
                {
                    o.MapFrom(s => DateTime.Now);
                });
            CreateMap<ComputerUpdateDto, Computer>()
                .ForMember(d => d.LastUpdate, o =>
                {
                    o.MapFrom(s => DateTime.Now);
                });

        }
    }
}
