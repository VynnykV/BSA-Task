using System;
using System.Collections.Generic;
using System.Linq;
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
            return _context.Projects;
        }

        public Project GetById(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public Project Create(Project entity)
        {
            entity.Id = _context.Projects.Last().Id + 1;
            var team = _context.Teams.FirstOrDefault(t => t.Id == entity.TeamId);
            var author = _context.Users.FirstOrDefault(u => u.Id == entity.AuthorId);
            if (team is not null && author is not null)
            {
                entity.Author = author;
                entity.Team = team;
                entity.Author.Projects.Add(entity);
                entity.Team.Projects.Add(entity);
            }
            else
                throw new ArgumentException("Team or author with such an id doesn't exists");
            _context.Projects.Add(entity);
            return entity;
        }

        public void Update(Project entity)
        {
            var project = GetById(entity.Id);
            if (project is null)
                throw new ArgumentException("Project with such an id is not found", nameof(entity.Id));

            if (entity.TeamId != project.TeamId)
            {
                var newTeam = _context.Teams.FirstOrDefault(t => t.Id == entity.TeamId);
                if (newTeam is not null)
                {
                    project.TeamId = newTeam.Id;
                    project.Team = newTeam;
                    project.Team.Projects.Add(entity);
                }
                else
                    throw new ArgumentException("Team with such an id is not found", nameof(entity.TeamId));
            }

            project.Name = entity.Name;
            project.Description = entity.Description;
            project.Deadline = entity.Deadline;
        }

        public void Delete(int id)
        {
            var project = GetById(id);
            if (project is null)
                throw new ArgumentException("Project with such an id is not found", nameof(id));
            project.Author.Projects.Remove(project);
            project.Team.Projects.Remove(project);
            _context.Projects.Remove(project);
        }
    }
}