using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.Team;

namespace ProjectStructure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public IActionResult CreateTeam([FromBody] TeamCreateDTO team)
        {
            var createdTeam = _teamService.AddTeam(team);
            return CreatedAtAction("GetById", "teams", new { id = createdTeam.Id }, createdTeam);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamDTO>> Get()
        {
            return Ok(_teamService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<TeamDTO> GetById(int id)
        {
            return Ok(_teamService.GetTeamById(id));
        }

        [HttpPut]
        public IActionResult Put([FromBody] TeamUpdateDTO team)
        {
            _teamService.UpdateTeam(team);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teamService.DeleteTeam(id);
            return NoContent();
        }
    }
}