using System;
using System.Collections.Generic;
using System.Linq;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.DAL.Repositories
{
    public class TeamRepository : IRepository<Team>
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetAll()
        {
            return _context.Teams;
        }

        public Team GetById(int id)
        {
            return _context.Teams.FirstOrDefault(t => t.Id == id);
        }

        public Team Create(Team entity)
        {
            entity.Id = _context.Teams.Last().Id + 1;
            _context.Teams.Add(entity);
            return entity;
        }

        public void Update(Team entity)
        {
            var team = GetById(entity.Id);
            if (team is null)
            {
                throw new ArgumentException("Team with such an id is not found", nameof(entity.Id));
            }
            team = entity;
        }

        public void Delete(int id)
        {
            var team = GetById(id);
            if (team is null)
                throw new ArgumentException("Team with such an id is not found", nameof(id));
            _context.Teams.Remove(team);
        }
    }
}