using System;
using System.Collections.Generic;
using System.Linq;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User Create(User entity)
        {
            entity.Id = _context.Users.Last().Id + 1;
            entity.Team = _context.Teams.FirstOrDefault(t => t.Id == entity.TeamId);
            if (entity.Team is null)
            {
                entity.TeamId = null;
            }
            else entity.Team.Users.Add(entity);
            _context.Users.Add(entity);
            return entity;
        }

        public void Update(User entity)
        {
            var user = GetById(entity.Id);
            if (user is null)
                throw new ArgumentException("User with such an id is not found", nameof(entity.Id));
            if (entity.TeamId != user.TeamId)
            {
                user.Team.Users.Remove(user);
                var newTeam = _context.Teams.FirstOrDefault(t => t.Id == entity.TeamId);
                if (newTeam is not null)
                {
                    user.TeamId = newTeam.Id;
                    user.Team = newTeam;
                }
                else
                {
                    throw new ArgumentException("Team with such an id is not found", nameof(entity.TeamId));
                }
            }

            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.RegisteredAt = entity.RegisteredAt;
            user.BirthDay = entity.BirthDay;
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user is null)
                throw new ArgumentException("User with such an id is not found", nameof(id));
            user.Team.Users.Remove(user);
            _context.Users.Remove(user);
        }
    }
}