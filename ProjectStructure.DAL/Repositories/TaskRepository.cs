using System;
using System.Collections.Generic;
using System.Linq;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;

        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetAll()
        {
            return _context.Tasks;
        }

        public Task GetById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public Task Create(Task entity)
        {
            var newEntity = _context.Tasks.Add(entity);
            return newEntity.Entity;
        }

        public void Update(Task entity)
        {
            var task = GetById(entity.Id);
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

        public void Delete(int id)
        {
            var task = GetById(id);
            if (task is null)
                throw new ArgumentException("Task with such an id is not found", nameof(id));
            _context.Tasks.Remove(task);
        }
    }
}