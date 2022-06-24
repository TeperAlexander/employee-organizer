using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Services
{
    public interface ILogicService<TEntity>
    {
        Task<TEntity> GetByIdAsync(long id);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(long id);
    }
}
