using ProjectStructure.Common.DTO.Project;
using ProjectStructure.Common.DTO.Task;
using ProjectStructure.Common.DTO.User;

namespace ProjectStructure.Common.DTO.Selection
{
    public class UserInfoDTO
    {
        public UserDTO User { get; set; }
        public ProjectDTO LastProject { get; set; }
        public int TasksQuantityLastProject { get; set; }
        public int GeneralQuantityUnfinishedTasks { get; set; }
        public int GeneralQuantityCancelledTasks { get; set; }
        public TaskDTO LongestTaskByDuration { get; set; }
    }
}