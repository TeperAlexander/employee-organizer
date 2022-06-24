using EmployeeOrganizer.Models;
using EmployeeOrganizer.Repositories;


namespace EmployeeOrganizer.Services
{
    public class DepartmentService : LogicService<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IGenericRepository<Department> repository, IDepartmentRepository repo) : base(repository)
        {
            _repository = repo;
        }

    }
}

