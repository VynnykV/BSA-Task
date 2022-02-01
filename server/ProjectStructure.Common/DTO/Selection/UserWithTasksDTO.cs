using System.Collections.Generic;
using ProjectStructure.Common.DTO.Task;
using ProjectStructure.Common.DTO.User;

namespace ProjectStructure.Common.DTO.Selection
{
    public class UserWithTasksDTO
    {
        public UserDTO User { get; set; }
        public IEnumerable<TaskDTO> Tasks { get; set; }
    }
}