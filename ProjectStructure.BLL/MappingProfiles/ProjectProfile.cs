using AutoMapper;
using ProjectStructure.Common.DTO.Project;
using ProjectStructure.DAL.Entities;

namespace ProjectStructure.BLL.MappingProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<ProjectCreateDTO, Project>();
        }
    }
}