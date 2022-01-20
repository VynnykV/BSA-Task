using System.Collections.Generic;
using ProjectStructure.Common.DTO.Task;

namespace ProjectStructure.BLL.Interfaces
{
    public interface ITaskService
    {
        TaskDTO AddTask(TaskCreateDTO task);
        IEnumerable<TaskDTO> GetAll();
        TaskDTO GetTaskById(int id);
        void UpdateTask(TaskUpdateDTO task);
        void DeleteTask(int id);
    }
}