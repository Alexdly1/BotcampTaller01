using AutoMapper;
using Jazani.Domain.Socs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Socs.Dtos.Holders.Profiles
{
    public class HolderProfile : Profile
    {
        public HolderProfile() 
        {
            CreateMap<Holder, HolderDto>();
            CreateMap<Holder, HolderSimpleDto>();
            CreateMap<Holder, HolderSaveDto>().ReverseMap();
        }
    }
}
