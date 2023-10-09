using AutoMapper;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Application.Mcs.Dtos.Miningconcessions.Profiles
{
    public class MiningconcessionProfile : Profile
    {
        public MiningconcessionProfile() 
        {
            CreateMap<Miningconcession, MiningconcessionDto>();
            CreateMap<Miningconcession, MiningconcessionSimpleDto>();
            CreateMap<Miningconcession, MiningconcessionSaveDto>().ReverseMap();
        }
    }
}
