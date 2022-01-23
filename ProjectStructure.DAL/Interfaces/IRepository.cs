using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectStructure.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace ProjectStructure.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(int id);
    }
}