using AutoMapper;
using Jazani.Domain.Lias.Models;

namespace Jazani.Application.Lias.Dtos.Activities.Mappers
{
    public class ActivityMapper : Profile
    {
        public ActivityMapper()
        {
            CreateMap<Activity, ActivityDto>();
        }
    }
}
