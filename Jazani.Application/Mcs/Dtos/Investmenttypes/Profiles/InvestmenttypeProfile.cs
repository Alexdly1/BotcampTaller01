using AutoMapper;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Application.Mcs.Dtos.Investmenttypes.Profiles
{
    public class InvestmenttypeProfile : Profile
    {
        public InvestmenttypeProfile() 
        {
            CreateMap<Investmenttype, InvestmenttypeDto>();
            CreateMap<Investmenttype, InvestmenttypeSimpleDto>();
            CreateMap<Investmenttype, InvestmenttypeSaveDto>().ReverseMap();
        }

    }
}
