using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ProjectStructure.DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects
                .Include(p => p.Tasks)
                .Include(p=>p.Team)
                .ThenInclude(t=>t.Users)
                .ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Create(Project entity)
        {
            await _context.Projects.AddAsync(entity);
        }

        public async Task Update(Project entity)
        {
            var project = await GetById(entity.Id);
            if (project is null)
                throw new ArgumentException("Project with such an id is not found", nameof(entity.Id));
            
            project.TeamId = entity.TeamId;
            project.Name = entity.Name;
            project.Description = entity.Description;
            project.Deadline = entity.Deadline;
            _context.Projects.Update(project);
        }

        public async Task Delete(int id)
        {
            var project = await GetById(id);
            if (project is null)
                throw new ArgumentException("Project with such an id is not found", nameof(id));
            _context.Projects.Remove(project);
        }
    }
}