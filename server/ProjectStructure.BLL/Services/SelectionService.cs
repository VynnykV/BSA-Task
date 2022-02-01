using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.Project;
using ProjectStructure.Common.DTO.Selection;
using ProjectStructure.Common.DTO.Task;
using ProjectStructure.Common.DTO.User;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.BLL.Services
{
    public class SelectionService : BaseService, ISelectionService
    {
        public SelectionService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ProjectCountTasksDTO>> TasksInProjectByUserCount(int userId)
        {
            var result = await (_unitOfWork.ProjectRepository
                .Query()
                .Include(p=>p.Tasks))
                .Where(p => p.AuthorId == userId)
                .Select(project => new ProjectCountTasksDTO()
                {
                    Project = _mapper.Map<ProjectDTO>(project),
                    NumsOfTasks = project.Tasks.Count
                })
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<TaskDTO>> GetTasksLimitedByName(int userId, int symbolsQuantity)
        {
            var result = await _unitOfWork.TaskRepository
                .Query()
                .Where(t => t.PerformerId == userId && t.Name.Length < symbolsQuantity)
                .ToListAsync();
            return _mapper.Map<IEnumerable<TaskDTO>>(result);
        }

        public async Task<IEnumerable<FinishedTaskDTO>> GetFinishedTasks(int userId, int year)
        {
            var result = await _unitOfWork.TaskRepository
                .Query()
                .Where(t => t.FinishedAt.Value.Year == year && t.PerformerId == userId)
                .Select(r => new FinishedTaskDTO()
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<TeamUsersDTO>> GetOlderUsers(int age)
        {
            var result = await _unitOfWork.TeamRepository
                .Query()
                .Include(t=>t.Users)
                .Select(team => new TeamUsersDTO
                {
                    Id = team.Id,
                    Name = team.Name,
                    Users = _mapper.Map<IEnumerable<UserDTO>>(team.Users
                        .Where(u => (DateTime.Now.Year - u.BirthDay.Year) > age)
                        .OrderByDescending(u => u.RegisteredAt)
                        .Select(u => u))
                })
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<UserWithTasksDTO>> GetSortedUsersWithTasks()
        {
            var users = await _unitOfWork.UserRepository
                .Query()
                .Include(u => u.Tasks)
                .ToListAsync();
            var result = users
                .Select(u => new UserWithTasksDTO()
                {
                    User = _mapper.Map<UserDTO>(u),
                    Tasks = _mapper.Map<IEnumerable<TaskDTO>>(u.Tasks.OrderByDescending(t => t.Name).ToList())
                })
                .OrderBy(u => u.User.FirstName)
                .AsEnumerable();

            return result;
        }

        public async Task<UserInfoDTO> GetUserInfo(int userId)
        {
            var users = await _unitOfWork.UserRepository
                .Query()
                .Include(u=>u.Tasks)
                .Include(u=>u.Projects)
                .ThenInclude(p=>p.Tasks)
                .ToListAsync();
            var result = users
                .Select(u => new UserInfoDTO()
                {
                    User = _mapper.Map<UserDTO>(u),
                    LastProject =
                        _mapper.Map<ProjectDTO>(u.Projects.FirstOrDefault(p =>
                            p.CreatedAt == u.Projects.Max(p => p.CreatedAt))),
                    TasksQuantityLastProject = u.Projects
                        .FirstOrDefault(p => p.CreatedAt == u.Projects.Max(p => p.CreatedAt))?.Tasks
                        .Count() ?? 0,
                    GeneralQuantityCancelledTasks = u.Tasks.Count(t => t.State == TaskState.Cancelled),
                    GeneralQuantityUnfinishedTasks = u.Tasks.Count(t => t.FinishedAt == null),
                    LongestTaskByDuration = _mapper.Map<TaskDTO>(u.Tasks
                        .Where(t => t.FinishedAt is not null)
                        .FirstOrDefault(t =>
                            t.FinishedAt.Value - t.CreatedAt == u.Tasks.Where(t => t.FinishedAt is not null)
                                .Max(t => t.FinishedAt.Value - t.CreatedAt)))
                })
                .FirstOrDefault(u => u.User.Id == userId);
            return result;
        }

        public async Task<ProjectInfoDTO> GetProjectInfo(int projectId)
        {
            var projects =  await _unitOfWork.ProjectRepository
                .Query()
                .Include(p=>p.Tasks)
                .Include(p=>p.Team)
                .ThenInclude(t=>t.Users)
                .ToListAsync();
            var result = projects
                .Select(p => new ProjectInfoDTO()
                {
                    Project = _mapper.Map<ProjectDTO>(p),
                    LongestProjectTaskByDesc = _mapper.Map<TaskDTO>(p.Tasks
                        .FirstOrDefault(t => t.Description.Length == p.Tasks.Max(t => t.Description.Length))),
                    ShortestProjectTaskByName = _mapper.Map<TaskDTO>(p.Tasks
                        .FirstOrDefault(t => t.Name.Length == p.Tasks.Min(t => t.Name.Length))),
                    TeamUsersCount = projects
                        .Where(p => p.Description.Length > 20 || p.Tasks.Count() < 3)
                        .Sum(p => p.Team.Users.Count)
                })
                .FirstOrDefault(p => p.Project.Id == projectId);
            return result;
        }
    }
}