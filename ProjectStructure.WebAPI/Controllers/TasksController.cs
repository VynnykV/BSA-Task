using System.Collections.Generic;
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
        public IActionResult CreateTask([FromBody] TaskCreateDTO task)
        {
            var createdTask = _taskService.AddTask(task);
            return CreatedAtAction("GetById", "tasks", new { id = createdTask.Id }, createdTask);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskDTO>> Get()
        {
            return Ok(_taskService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<TaskDTO> GetById(int id)
        {
            return Ok(_taskService.GetTaskById(id));
        }

        [HttpPut]
        public IActionResult Put([FromBody] TaskUpdateDTO task)
        {
            _taskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}