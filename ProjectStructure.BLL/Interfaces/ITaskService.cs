using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectStructure.Common.DTO.Task;
using ProjectStructure.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace ProjectStructure.BLL.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDTO> AddTask(TaskCreateDTO task);
        Task<IEnumerable<TaskDTO>> GetAll();
        Task<TaskDTO> GetTaskById(int id);
        Task UpdateTask(TaskUpdateDTO task);
        Task UpdateTaskState(int id, TaskState state);
        Task DeleteTask(int id);
    }
}