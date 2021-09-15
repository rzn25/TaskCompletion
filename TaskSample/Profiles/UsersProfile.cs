using AutoMapper;
using TaskSample.Dtos;
using TaskSample.Models;

namespace TaskSample.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();

        }
    }
}