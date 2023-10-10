using AutoMapper;
using Jazani.Domain.Ges.Models;

namespace Jazani.Application.Ges.Dtos.Measureunits.Profiles
{
    public class MeasureunitProfile : Profile
    {
        public MeasureunitProfile() 
        {
            CreateMap<Measureunit, MeasureunitDto>();
            CreateMap<Measureunit, MeasureunitSimpleDto>();
            CreateMap<Measureunit, MeasureunitSaveDto>().ReverseMap();
        }
    }
}
