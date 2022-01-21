using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
                .Include(u => u.Tasks)
                .Include(u => u.Projects)
                .ThenInclude(p => p.Tasks);
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User Create(User entity)
        {
            var newEntity = _context.Users.Add(entity);
            return newEntity.Entity;
        }

        public void Update(User entity)
        {
            var user = GetById(entity.Id);
            if (user is null)
                throw new ArgumentException("User with such an id is not found", nameof(entity.Id));

            user.TeamId = entity.TeamId;
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.BirthDay = entity.BirthDay;
            _context.Users.Update(user);
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user is null)
                throw new ArgumentException("User with such an id is not found", nameof(id));
            _context.Users.Remove(user);
        }
    }
}