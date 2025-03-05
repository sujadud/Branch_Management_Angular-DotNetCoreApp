using ExamCore.Database.DatabaseContexts;
using ExamCore.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ExamCore.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DatabaseContext dbContext;
        protected BaseRepository() => dbContext = new DatabaseContext();

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            var getAllAsync = await dbContext.Set<T>().ToListAsync();
            return getAllAsync;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var getByIdAsync = await dbContext.Set<T>().FindAsync(id);
            return getByIdAsync;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            var createAsync = await dbContext.SaveChangesAsync() > 0;

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            var updateAsync = await dbContext.SaveChangesAsync() > 0;

            return entity;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            var deleteAsync = await dbContext.SaveChangesAsync() > 0;

            return deleteAsync;
        }
    }
}