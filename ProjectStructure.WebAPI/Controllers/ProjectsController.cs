using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.Project;

namespace ProjectStructure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public ActionResult<ProjectDTO> CreateProject([FromBody] ProjectCreateDTO project)
        {
            var createdProject = _projectService.AddProject(project);
            return CreatedAtAction("GetById", "projects", new { id = createdProject.Id }, createdProject);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> Get()
        {
            return Ok(_projectService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDTO> GetById(int id)
        {
            return Ok(_projectService.GetProjectById(id));
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProjectUpdateDTO project)
        {
            _projectService.UpdateProject(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.DeleteProject(id);
            return NoContent();
        }
    }
}