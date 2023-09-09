using AutoMapper;
using TodoApp.Data.dtos;
using TodoApp.Models;

namespace TodoApp.Profiles;


public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, ReadUserDto>();
        CreateMap<User, UpdateUserDto>();
    }
}