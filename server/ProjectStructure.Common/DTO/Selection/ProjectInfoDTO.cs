using ProjectStructure.Common.DTO.Project;
using ProjectStructure.Common.DTO.Task;

namespace ProjectStructure.Common.DTO.Selection
{
    public class ProjectInfoDTO
    {
        public ProjectDTO Project { get; set; }
        public TaskDTO LongestProjectTaskByDesc { get; set; }
        public TaskDTO ShortestProjectTaskByName { get; set; }
        public int TeamUsersCount { get; set; }
    }
}