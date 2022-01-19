using AutoMapper;
using ProjectStructure.Common.DTO.User;
using ProjectStructure.DAL.Entities;

namespace ProjectStructure.BLL.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserCreateDTO, User>();
        }
    }
}