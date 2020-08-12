using AutoMapper;
using DataLayer.Entities;
using DataLayer.DTOs;

namespace RadioMarket.UserService.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, NewUserDTO>();
            CreateMap<NewUserDTO, User>();
        }
    }
}
