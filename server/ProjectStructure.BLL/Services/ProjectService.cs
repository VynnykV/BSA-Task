using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.BLL.Exceptions;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.Project;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ProjectStructure.BLL.Services
{
    public class ProjectService : BaseService, IProjectService
    {
        public ProjectService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ProjectDTO> AddProject(ProjectCreateDTO project)
        {
            var projectEntity = _mapper.Map<Project>(project);
            projectEntity.CreatedAt = DateTime.Now;
            await _unitOfWork.ProjectRepository.Create(projectEntity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProjectDTO>(projectEntity);
        }

        public async Task<IEnumerable<ProjectDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProjectDTO>>(await _unitOfWork.ProjectRepository
                .Query()
                .Include(p=>p.Author)
                .ThenInclude(u=>u.Team)
                .Include(p=>p.Team)
                .Include(p=>p.Tasks)
                .ToListAsync());
        }

        public async Task<ProjectDTO> GetProjectById(int id)
        {
            var projectEntity = await _unitOfWork.ProjectRepository
                .Query()
                .Include(p=>p.Author)
                .ThenInclude(u=>u.Team)
                .Include(p=>p.Team)
                .Include(p=>p.Tasks)
                .FirstOrDefaultAsync(p=>p.Id == id);
            if (projectEntity is null)
                throw new NotFoundException(nameof(Project), id);
            return _mapper.Map<ProjectDTO>(projectEntity);
        }

        public async Task UpdateProject(ProjectUpdateDTO project)
        {
            var projectEntity = await _unitOfWork.ProjectRepository.GetById(project.Id);
            if (projectEntity is null)
                throw new NotFoundException(nameof(Project), project.Id);
            projectEntity.TeamId = project.TeamId;
            projectEntity.Name = project.Name;
            projectEntity.Description = project.Description;
            projectEntity.Deadline = project.Deadline;
            _unitOfWork.ProjectRepository.Update(projectEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var projectEntity = await _unitOfWork.ProjectRepository.GetById(id);
            if (projectEntity is null)
                throw new NotFoundException(nameof(Project), id);
            await _unitOfWork.ProjectRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}