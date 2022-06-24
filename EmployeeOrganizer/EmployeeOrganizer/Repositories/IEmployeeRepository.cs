using EmployeeOrganizer.DTOs;
using EmployeeOrganizer.Models;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> AddAsync(CreateEmployeeRequestDTO request);
        Task<Employee> FindByUsernameAsync(string username);
        new Task<Employee> UpdateAsync(Employee e);
    }
}
