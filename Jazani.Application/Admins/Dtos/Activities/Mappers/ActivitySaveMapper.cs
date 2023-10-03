using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Activities.Mappers
{
    public class ActivitySaveMapper : Profile
    {
        public ActivitySaveMapper() 
        {
            CreateMap<Activity, ActivitySaveDto>().ReverseMap();
        }
    }
}
