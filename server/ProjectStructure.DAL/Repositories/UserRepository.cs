using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ProjectStructure.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users
                .Include(u => u.Tasks)
                .Include(u => u.Projects)
                .ThenInclude(p => p.Tasks)
                .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Create(User entity)
        {
            await _context.Users.AddAsync(entity);
        }

        public async Task Update(User entity)
        {
            var user = await GetById(entity.Id);
            if (user is null)
                throw new ArgumentException("User with such an id is not found", nameof(entity.Id));

            user.TeamId = entity.TeamId;
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.BirthDay = entity.BirthDay;
            _context.Users.Update(user);
        }

        public async Task Delete(int id)
        {
            var user = await GetById(id);
            if (user is null)
                throw new ArgumentException("User with such an id is not found", nameof(id));
            _context.Users.Remove(user);
        }
    }
}