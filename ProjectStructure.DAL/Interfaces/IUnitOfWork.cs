using ProjectStructure.DAL.Entities;

namespace ProjectStructure.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Project> ProjectRepository { get; }
        IRepository<Task> TaskRepository { get; }
        IRepository<Team> TeamRepository { get; }
    }
}