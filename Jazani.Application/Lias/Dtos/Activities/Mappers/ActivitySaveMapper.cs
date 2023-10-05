using AutoMapper;
using Jazani.Domain.Lias.Models;

namespace Jazani.Application.Lias.Dtos.Activities.Mappers
{
    public class ActivitySaveMapper : Profile
    {
        public ActivitySaveMapper()
        {
            CreateMap<Activity, ActivitySaveDto>().ReverseMap();
        }
    }
}
