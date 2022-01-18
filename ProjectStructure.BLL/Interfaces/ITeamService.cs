using System.Collections.Generic;
using ProjectStructure.Common.DTO.Team;

namespace ProjectStructure.BLL.Interfaces
{
    public interface ITeamService
    {
        TeamDTO AddTeam(TeamCreateDTO team);
        IEnumerable<TeamDTO> GetAll();
        TeamDTO GetTeamById(int id);
        void UpdateTeam(TeamDTO team);
        void DeleteTeam(int id);
    }
}