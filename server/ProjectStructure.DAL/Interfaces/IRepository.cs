using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectStructure.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace ProjectStructure.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        void Update(TEntity entity);

        Task Delete(int id);
    }
}