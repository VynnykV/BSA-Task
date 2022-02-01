using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectStructure.Common.DTO.Project;
using ProjectStructure.Common.DTO.Selection;
using ProjectStructure.Common.DTO.Task;
using ProjectStructure.Common.DTO.User;

namespace ProjectStructure.BLL.Interfaces
{
    public interface ISelectionService
    {
        Task<IEnumerable<ProjectCountTasksDTO>> TasksInProjectByUserCount(int userId);
        Task<IEnumerable<TaskDTO>> GetTasksLimitedByName(int userId, int symbolsQuantity);
        Task<IEnumerable<FinishedTaskDTO>> GetFinishedTasks(int userId, int year);
        Task<IEnumerable<TeamUsersDTO>> GetOlderUsers(int age);
        Task<IEnumerable<UserWithTasksDTO>> GetSortedUsersWithTasks();
        Task<UserInfoDTO> GetUserInfo(int userId);
        Task<ProjectInfoDTO> GetProjectInfo(int projectId);
    }
}