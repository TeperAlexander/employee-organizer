using EmployeeOrganizer.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Services
{
    public class LogicService<TEntity> : ILogicService<TEntity> where TEntity : class
    {
    
        private readonly IGenericRepository<TEntity> _repository;

        public LogicService(IGenericRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Query(predicate);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
