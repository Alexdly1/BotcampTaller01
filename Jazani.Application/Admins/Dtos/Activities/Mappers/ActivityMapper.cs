using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Activities.Mappers
{
    public class ActivityMapper : Profile
    {
        public ActivityMapper() 
        {
            CreateMap<Activity, ActivityDto>();
        }
    }
}
