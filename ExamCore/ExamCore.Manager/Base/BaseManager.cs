using ExamCore.Manager.Contracts;
using ExamCore.Repository.Contracts;

namespace ExamCore.Manager.Base
{
    public abstract class BaseManager<T> : IBaseManager<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseManager(IBaseRepository<T> baseRepository) => _baseRepository = baseRepository;

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            var getAllAsync = await _baseRepository.GetAllAsync();
            return getAllAsync;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var getByIdAsync = await _baseRepository.GetByIdAsync(id);
            return getByIdAsync;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            var createAsync = await _baseRepository.CreateAsync(entity);
            return createAsync;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var updateAsync = await _baseRepository.UpdateAsync(entity);
            return updateAsync;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            var deleteAsync = await _baseRepository.DeleteAsync(entity);
            return deleteAsync;
        }
    }
}