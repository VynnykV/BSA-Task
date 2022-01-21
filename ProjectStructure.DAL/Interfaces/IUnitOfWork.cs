namespace ProjectStructure.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ITaskRepository TaskRepository { get; }
        ITeamRepository TeamRepository { get; }
        void SaveChanges();
    }
}