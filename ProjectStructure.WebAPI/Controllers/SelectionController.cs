using System.Collections.Generic;
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
        public ActionResult<IEnumerable<ProjectCountTasksDTO>> TasksInProjectByUserCount(int userId)
        {
            return Ok(_selectionService.TasksInProjectByUserCount(userId));
        }

        [HttpGet("tasksLimitedByName/{userId}/{symbolsQuantity}")]
        public ActionResult<IEnumerable<TaskDTO>> GetTasksLimitedByName(int userId, int symbolsQuantity)
        {
            return Ok(_selectionService.GetTasksLimitedByName(userId, symbolsQuantity));
        }

        [HttpGet("finishedTasks/{userId}/{year}")]
        public ActionResult<IEnumerable<FinishedTaskDTO>> GetFinishedTasks(int userId, int year)
        {
            return Ok((_selectionService.GetFinishedTasks(userId, year)));
        }

        [HttpGet("olderUsers/{age}")]
        public ActionResult<IEnumerable<TeamUsersDTO>> GetOlderUsers(int age)
        {
            return Ok(_selectionService.GetOlderUsers(age));
        }

        [HttpGet("sortedUsersWithTasks")]
        public ActionResult<IEnumerable<UserWithTasksDTO>> GetSortedUsersWithTasks()
        {
            return Ok(_selectionService.GetSortedUsersWithTasks());
        }

        [HttpGet("getUserInfo/{userId}")]
        public ActionResult<UserInfoDTO> GetUserInfo(int userId)
        {
            return Ok(_selectionService.GetUserInfo(userId));
        }

        [HttpGet("getProjectInfo/{projectId}")]
        public ActionResult<ProjectInfoDTO> GetProjectInfo(int projectId)
        {
            return Ok(_selectionService.GetProjectInfo(projectId));
        }
    }
}