using AutoMapper;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Application.Mcs.Dtos.Investmentconcepts.Profiles
{
    public class InvestmentconceptProfile : Profile
    {
        public InvestmentconceptProfile() 
        {
            CreateMap<Investmentconcept, InvestmentconceptDto>();
            CreateMap<Investmentconcept, InvestmentconceptSimpleDto>();
            CreateMap<Investmentconcept, InvestmentconceptSaveDto>().ReverseMap();
        }
    }
}
