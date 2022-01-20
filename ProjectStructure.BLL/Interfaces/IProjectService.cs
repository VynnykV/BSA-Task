using System.Collections.Generic;
using ProjectStructure.Common.DTO.Project;

namespace ProjectStructure.BLL.Interfaces
{
    public interface IProjectService
    {
        ProjectDTO AddProject(ProjectCreateDTO project);
        IEnumerable<ProjectDTO> GetAll();
        ProjectDTO GetProjectById(int id);
        void UpdateProject(ProjectUpdateDTO project);
        void DeleteProject(int id);
    }
}