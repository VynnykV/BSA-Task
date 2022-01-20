using System;
using System.Collections.Generic;
using AutoMapper;
using ProjectStructure.BLL.Exceptions;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.Project;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.BLL.Services
{
    public class ProjectService : BaseService, IProjectService
    {
        public ProjectService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public ProjectDTO AddProject(ProjectCreateDTO project)
        {
            var projectEntity = _mapper.Map<Project>(project);
            projectEntity.CreatedAt = DateTime.Now;
            _unitOfWork.ProjectRepository.Create(projectEntity);
            return _mapper.Map<ProjectDTO>(projectEntity);
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ProjectDTO>>(_unitOfWork.ProjectRepository.GetAll());
        }

        public ProjectDTO GetProjectById(int id)
        {
            var projectEntity = _unitOfWork.ProjectRepository.GetById(id);
            if (projectEntity is null)
                throw new NotFoundException(nameof(Project), id);
            return _mapper.Map<ProjectDTO>(projectEntity);
        }

        public void UpdateProject(ProjectUpdateDTO project)
        {
            var projectEntity = _mapper.Map<Project>(project);
            if (_unitOfWork.ProjectRepository.GetById(project.Id) is null)
                throw new NotFoundException(nameof(Project), project.Id);
            _unitOfWork.ProjectRepository.Update(projectEntity);
        }

        public void DeleteProject(int id)
        {
            var projectEntity = _unitOfWork.ProjectRepository.GetById(id);
            if (projectEntity is null)
                throw new NotFoundException(nameof(Project), id);
            _unitOfWork.ProjectRepository.Delete(id);
        }
    }
}