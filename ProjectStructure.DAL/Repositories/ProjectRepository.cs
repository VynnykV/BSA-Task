using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects
                .Include(p => p.Tasks)
                .Include(p=>p.Team)
                .ThenInclude(t=>t.Users)
                .ToList();
        }

        public Project GetById(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public Project Create(Project entity)
        {
            var newEntity = _context.Projects.Add(entity);
            return newEntity.Entity;
        }

        public void Update(Project entity)
        {
            var project = GetById(entity.Id);
            if (project is null)
                throw new ArgumentException("Project with such an id is not found", nameof(entity.Id));
            
            project.TeamId = entity.TeamId;
            project.Name = entity.Name;
            project.Description = entity.Description;
            project.Deadline = entity.Deadline;
            _context.Projects.Update(project);
        }

        public void Delete(int id)
        {
            var project = GetById(id);
            if (project is null)
                throw new ArgumentException("Project with such an id is not found", nameof(id));
            _context.Projects.Remove(project);
        }
    }
}