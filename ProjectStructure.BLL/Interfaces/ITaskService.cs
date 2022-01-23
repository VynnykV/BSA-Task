using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectStructure.Common.DTO.Task;

namespace ProjectStructure.BLL.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDTO> AddTask(TaskCreateDTO task);
        Task<IEnumerable<TaskDTO>> GetAll();
        Task<TaskDTO> GetTaskById(int id);
        Task UpdateTask(TaskUpdateDTO task);
        Task DeleteTask(int id);
    }
}