using AutoMapper;
using DataServiceLib;

namespace WebService.Controllers
{
    public class UserCreationDto
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreationDto, User>();
        }
    }
}