using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Processes.Mappers
{
    public class ProcessSaveMapper : Profile
    {
        public ProcessSaveMapper() 
        {
            CreateMap<Process, ProcessSaveDto>().ReverseMap();
        }
    }
}
