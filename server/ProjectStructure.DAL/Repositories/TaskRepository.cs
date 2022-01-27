using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.DAL.Interfaces;
using Assignment = ProjectStructure.DAL.Entities.Task;

namespace ProjectStructure.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;

        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assignment>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Assignment> GetById(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Create(Assignment entity)
        {
            await _context.Tasks.AddAsync(entity);
        }

        public async Task Update(Assignment entity)
        {
            var task = await GetById(entity.Id);
            if (task is null)
            {
                throw new ArgumentException("Task with such an id is not found", nameof(entity.Id));
            }

            task.PerformerId = entity.PerformerId;
            task.Name = entity.Name;
            task.Description = entity.Description;
            task.State = entity.State;
            task.FinishedAt = entity.FinishedAt;
            _context.Tasks.Update(task);
        }

        public async Task Delete(int id)
        {
            var task = await GetById(id);
            if (task is null)
                throw new ArgumentException("Task with such an id is not found", nameof(id));
            _context.Tasks.Remove(task);
        }
    }
}