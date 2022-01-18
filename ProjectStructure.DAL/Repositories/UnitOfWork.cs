using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IRepository<User> _userRepository;
        private IRepository<Project> _projectRepository;
        private IRepository<Team> _teamRepository;
        private IRepository<Task> _taskRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRepository<User> UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }

        public IRepository<Project> ProjectRepository
        {
            get { return _projectRepository ??= new ProjectRepository(_context); }
        }

        public IRepository<Task> TaskRepository
        {
            get { return _taskRepository ??= new TaskRepository(_context); }
        }

        public IRepository<Team> TeamRepository
        {
            get { return _teamRepository ??= new TeamRepository(_context); }
        }
    }
}