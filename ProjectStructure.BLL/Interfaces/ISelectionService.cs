using System.Collections.Generic;
using ProjectStructure.Common.DTO.Project;
using ProjectStructure.Common.DTO.Selection;
using ProjectStructure.Common.DTO.Task;
using ProjectStructure.Common.DTO.User;

namespace ProjectStructure.BLL.Interfaces
{
    public interface ISelectionService
    {
        IEnumerable<ProjectCountTasksDTO> TasksInProjectByUserCount(int userId);
        IEnumerable<TaskDTO> GetTasksLimitedByName(int userId, int symbolsQuantity);
        IEnumerable<FinishedTaskDTO> GetFinishedTasks(int userId, int year);
        public IEnumerable<TeamUsersDTO> GetOlderUsers(int age);
        IEnumerable<UserWithTasksDTO> GetSortedUsersWithTasks();
        UserInfoDTO GetUserInfo(int userId);
        ProjectInfoDTO GetProjectInfo(int projectId);
    }
}