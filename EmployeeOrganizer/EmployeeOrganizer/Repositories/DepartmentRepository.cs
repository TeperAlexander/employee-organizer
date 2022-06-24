using EmployeeOrganizer.Models;

namespace EmployeeOrganizer.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationContext context) : base(context)
        {

        }
    }
}

