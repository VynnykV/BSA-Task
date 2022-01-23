using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.Task;

namespace ProjectStructure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDTO task)
        {
            var createdTask = await _taskService.AddTask(task);
            return CreatedAtAction("GetById", "tasks", new { id = createdTask.Id }, createdTask);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> Get()
        {
            return Ok(await _taskService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetById(int id)
        {
            return Ok(await _taskService.GetTaskById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TaskUpdateDTO task)
        {
            await _taskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}