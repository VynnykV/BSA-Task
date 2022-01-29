using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ProjectStructure.DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : BaseEntity
    {
        private protected readonly DataContext _context;
        private readonly DbSet<TEntity> _dbEntities;

        protected Repository(DataContext context)
        {
            _context = context;
            _dbEntities = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = _context.Set<TEntity>();
            var query = includes
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(dbSet, (current, include) => current.Include(include));

            return query ?? dbSet;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbEntities.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "The entity cannot be null.");
            await _dbEntities.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "The entity cannot be null.");
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            _context.Entry(await GetById(id)).State = EntityState.Deleted;
        }
    }
}