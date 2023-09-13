using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TaskDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(TaskDbContext taskDbContext)
        {
            _dbContext = taskDbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity, Guid id)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
                return existingEntity;
            }

            return null;
        }

        public async Task<T> Delete(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }

            return null;
        }

    }
}
