using System.Collections.Generic;
using ProjectStructure.DAL.Entities;

namespace ProjectStructure.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);
    }
}