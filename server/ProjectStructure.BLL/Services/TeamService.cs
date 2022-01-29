using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.BLL.Exceptions;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.Team;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ProjectStructure.BLL.Services
{
    public class TeamService : BaseService, ITeamService
    {
        public TeamService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<TeamDTO> AddTeam(TeamCreateDTO team)
        {
            var teamEntity = _mapper.Map<Team>(team);
            teamEntity.CreatedAt = DateTime.Now;
            await _unitOfWork.TeamRepository.Create(teamEntity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TeamDTO>(teamEntity);
        }

        public async Task<IEnumerable<TeamDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<TeamDTO>>(await _unitOfWork.TeamRepository.Query().ToListAsync());
        }

        public async Task<TeamDTO> GetTeamById(int id)
        {
            var teamEntity = await _unitOfWork.TeamRepository.GetById(id);
            if (teamEntity is null)
                throw new NotFoundException(nameof(Team), id);
            return _mapper.Map<TeamDTO>(teamEntity);
        }

        public async Task UpdateTeam(TeamUpdateDTO team)
        {
            var teamEntity = await _unitOfWork.TeamRepository.GetById(team.Id);
            if (teamEntity is null)
                throw new NotFoundException((nameof(Team), team.Id));
            teamEntity.Name = team.Name;
            _unitOfWork.TeamRepository.Update(teamEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTeam(int id)
        {
            var teamEntity = await _unitOfWork.TeamRepository.GetById(id);
            if (teamEntity is null)
                throw new NotFoundException(nameof(Team), id);
            await _unitOfWork.TeamRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}