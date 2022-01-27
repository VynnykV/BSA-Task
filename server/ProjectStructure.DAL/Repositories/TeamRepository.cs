using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ProjectStructure.DAL.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _context.Teams
                .Include(t=>t.Users)
                .Include(t=>t.Projects)
                .ToListAsync();
        }

        public async Task<Team> GetById(int id)
        {
            return await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Create(Team entity)
        {
            await _context.Teams.AddAsync(entity);
        }

        public async Task Update(Team entity)
        {
            var team = await GetById(entity.Id);
            if (team is null)
            {
                throw new ArgumentException("Team with such an id is not found", nameof(entity.Id));
            }

            team.Name = entity.Name;
            _context.Teams.Update(team);
        }

        public async Task Delete(int id)
        {
            var team = await GetById(id);
            if (team is null)
                throw new ArgumentException("Team with such an id is not found", nameof(id));
            _context.Teams.Remove(team);
        }
    }
}