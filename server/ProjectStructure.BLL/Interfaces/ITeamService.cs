using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectStructure.Common.DTO.Team;

namespace ProjectStructure.BLL.Interfaces
{
    public interface ITeamService
    {
        Task<TeamDTO> AddTeam(TeamCreateDTO team);
        Task<IEnumerable<TeamDTO>> GetAll();
        Task<TeamDTO> GetTeamById(int id);
        Task UpdateTeam(TeamUpdateDTO team);
        Task DeleteTeam(int id);
    }
}