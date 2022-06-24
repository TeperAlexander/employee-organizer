using Microsoft.EntityFrameworkCore;

namespace EmployeeOrganizer.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> DbSet { get; }
    }
}
