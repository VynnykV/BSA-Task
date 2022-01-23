using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.Selection;
using ProjectStructure.Common.DTO.Task;

namespace ProjectStructure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionController : ControllerBase
    {
        private readonly ISelectionService _selectionService;

        public SelectionController(ISelectionService selectionService)
        {
            _selectionService = selectionService;
        }

        [HttpGet("tasksQuantityInProject/{userId}")]
        public async Task<ActionResult<IEnumerable<ProjectCountTasksDTO>>> TasksInProjectByUserCount(int userId)
        {
            return Ok(await _selectionService.TasksInProjectByUserCount(userId));
        }

        [HttpGet("tasksLimitedByName/{userId}/{symbolsQuantity}")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasksLimitedByName(int userId, int symbolsQuantity)
        {
            return Ok(await _selectionService.GetTasksLimitedByName(userId, symbolsQuantity));
        }

        [HttpGet("finishedTasks/{userId}/{year}")]
        public async Task<ActionResult<IEnumerable<FinishedTaskDTO>>> GetFinishedTasks(int userId, int year)
        {
            return Ok((await _selectionService.GetFinishedTasks(userId, year)));
        }

        [HttpGet("olderUsers/{age}")]
        public async Task<ActionResult<IEnumerable<TeamUsersDTO>>> GetOlderUsers(int age)
        {
            return Ok(await _selectionService.GetOlderUsers(age));
        }

        [HttpGet("sortedUsersWithTasks")]
        public async Task<ActionResult<IEnumerable<UserWithTasksDTO>>> GetSortedUsersWithTasks()
        {
            return Ok(await _selectionService.GetSortedUsersWithTasks());
        }

        [HttpGet("getUserInfo/{userId}")]
        public async Task<ActionResult<UserInfoDTO>> GetUserInfo(int userId)
        {
            return Ok(await _selectionService.GetUserInfo(userId));
        }

        [HttpGet("getProjectInfo/{projectId}")]
        public async Task<ActionResult<ProjectInfoDTO>> GetProjectInfo(int projectId)
        {
            return Ok(await _selectionService.GetProjectInfo(projectId));
        }
    }
}