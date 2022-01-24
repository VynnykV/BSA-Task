using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> CreateTeam([FromBody] TeamCreateDTO team)
        {
            var createdTeam = await _teamService.AddTeam(team);
            return CreatedAtAction("GetById", "teams", new { id = createdTeam.Id }, createdTeam);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDTO>>> Get()
        {
            return Ok(await _teamService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDTO>> GetById(int id)
        {
            return Ok(await _teamService.GetTeamById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TeamUpdateDTO team)
        {
            await _teamService.UpdateTeam(team);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamService.DeleteTeam(id);
            return NoContent();
        }
    }
}