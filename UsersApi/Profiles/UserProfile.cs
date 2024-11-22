using AutoMapper;
using UsersApi.Data.Dtos;
using UsersApi.Model;

namespace UsersApi.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
