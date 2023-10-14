using Jazani.Domain.Admins.Models;
using AutoMapper;

namespace Jazani.Application.Admins.Dtos.Users.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<User, UserSaveDto>().ReverseMap();
        }

    }
}
