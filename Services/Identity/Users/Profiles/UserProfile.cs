using AutoMapper;
using Identity.Users.Commands;

namespace Identity.Users.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<NewUserRequest, User>();
        }
    }
}