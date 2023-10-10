using AutoMapper;
using Jazani.Domain.Ges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Ges.Dtos.Periodtypes.Profiles
{
    public class PeriodtypeProfile : Profile
    {
        public PeriodtypeProfile() 
        {
            CreateMap<Periodtype, PeriodtypeDto>();
            CreateMap<Periodtype, PeriodtypeSimpleDto>();
            CreateMap<Periodtype, PeriodtypeSaveDto>().ReverseMap();
        }
    }
}
