using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectStructure.Common.DTO.Project;

namespace ProjectStructure.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDTO> AddProject(ProjectCreateDTO project);
        Task<IEnumerable<ProjectDTO>> GetAll();
        Task<ProjectDTO> GetProjectById(int id);
        Task UpdateProject(ProjectUpdateDTO project);
        Task DeleteProject(int id);
    }
}