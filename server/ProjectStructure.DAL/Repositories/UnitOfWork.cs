using System.Threading.Tasks;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IUserRepository _userRepository;
        private IProjectRepository _projectRepository;
        private ITeamRepository _teamRepository;
        private ITaskRepository _taskRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }

        public IProjectRepository ProjectRepository
        {
            get { return _projectRepository ??= new ProjectRepository(_context); }
        }

        public ITaskRepository TaskRepository
        {
            get { return _taskRepository ??= new TaskRepository(_context); }
        }

        public ITeamRepository TeamRepository
        {
            get { return _teamRepository ??= new TeamRepository(_context); }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}