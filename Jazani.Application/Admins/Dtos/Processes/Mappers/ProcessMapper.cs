using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Processes.Mappers
{
    public class ProcessMapper : Profile
    {
        public ProcessMapper() 
        {
            CreateMap<Process, ProcessDto>();
        }
    }
}
