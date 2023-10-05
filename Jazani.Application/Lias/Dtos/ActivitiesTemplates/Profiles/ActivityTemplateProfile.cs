using AutoMapper;
using Jazani.Domain.Lias.Models;

namespace Jazani.Application.Lias.Dtos.ActivitiesTemplates.Profiles
{
    public class ActivityTemplateProfile : Profile
    {
        public ActivityTemplateProfile() 
        {
            CreateMap<ActivityTemplate, ActivityTemplateDto>();

            CreateMap<ActivityTemplate, ActivityTemplateSaveDto>().ReverseMap();
        }
    }
}
