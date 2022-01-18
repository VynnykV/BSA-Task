using System;
using System.Collections.Generic;
using AutoMapper;
using ProjectStructure.BLL.Exceptions;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.Team;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.BLL.Services
{
    public class TeamService : BaseService, ITeamService
    {
        public TeamService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public TeamDTO AddTeam(TeamCreateDTO team)
        {
            var teamEntity = _mapper.Map<Team>(team);
            teamEntity.CreatedAt = DateTime.Now;
            _unitOfWork.TeamRepository.Create(teamEntity);
            return _mapper.Map<TeamDTO>(teamEntity);
        }

        public IEnumerable<TeamDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<TeamDTO>>(_unitOfWork.TeamRepository.GetAll());
        }

        public TeamDTO GetTeamById(int id)
        {
            var teamEntity = _unitOfWork.TeamRepository.GetById(id);
            if (teamEntity is null)
                throw new NotFoundException(nameof(Team), id);
            return _mapper.Map<TeamDTO>(teamEntity);
        }

        public void UpdateTeam(TeamDTO team)
        {
            var teamEntity = _mapper.Map<Team>(team);
            if (_unitOfWork.TeamRepository.GetById(team.Id) is null)
                throw new NotFoundException((nameof(Team), team.Id));
            _unitOfWork.TeamRepository.Update(teamEntity);
        }

        public void DeleteTeam(int id)
        {
            var teamEntity = _unitOfWork.TeamRepository.GetById(id);
            if (teamEntity is null)
                throw new NotFoundException(nameof(Team), id);
            _unitOfWork.UserRepository.Delete(id);
        }
    }
}