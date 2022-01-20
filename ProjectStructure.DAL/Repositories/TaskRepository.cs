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
            entity.Id = _context.Tasks.Last().Id + 1;
            var project = _context.Projects.FirstOrDefault(p => p.Id == entity.ProjectId);
            var performer = _context.Users.FirstOrDefault(u => u.Id == entity.PerformerId);
            if (project is not null && performer is not null)
            {
                entity.Project = project;
                entity.Performer = performer;
                entity.Project.Tasks.Add(entity);
                entity.Performer.Tasks.Add(entity);
            }
            else
                throw new ArgumentException("Project or performer with such an id doesn't exists");
            _context.Tasks.Add(entity);
            return entity;
        }

        public void Update(Task entity)
        {
            var task = GetById(entity.Id);
            if (task is null)
            {
                throw new ArgumentException("Task with such an id is not found", nameof(entity.Id));
            }

            if (entity.PerformerId != task.PerformerId)
            {
                var newPerformer = _context.Users.FirstOrDefault(u => u.Id == entity.PerformerId);
                if (newPerformer is not null)
                {
                    task.PerformerId = newPerformer.Id;
                    task.Performer = newPerformer;
                    task.Performer.Tasks.Add(entity);
                }
                else
                    throw new ArgumentException("Performer with such an id is not found", nameof(entity.PerformerId));
            }

            task.Name = entity.Name;
            task.Description = entity.Description;
            task.State = entity.State;
            task.FinishedAt = entity.FinishedAt;
        }

        public void Delete(int id)
        {
            var task = GetById(id);
            if (task is null)
                throw new ArgumentException("Task with such an id is not found", nameof(id));
            task.Performer.Tasks.Remove(task);
            task.Project.Tasks.Remove(task);
            _context.Tasks.Remove(task);
        }
    }
}