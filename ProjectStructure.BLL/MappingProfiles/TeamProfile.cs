using AutoMapper;
using ProjectStructure.Common.DTO.Team;
using ProjectStructure.DAL.Entities;

namespace ProjectStructure.BLL.MappingProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDTO>().ReverseMap();
            CreateMap<TeamCreateDTO, Team>();
        }
    }
}