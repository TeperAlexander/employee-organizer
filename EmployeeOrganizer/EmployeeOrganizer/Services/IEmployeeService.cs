using EmployeeOrganizer.DTOs;
using EmployeeOrganizer.Models;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Services
{
    public interface IEmployeeService : ILogicService<Employee>
    {
        Task<Employee> AddAsync(CreateEmployeeRequestDTO request);
        Task<Employee> FindByUsernameAsync(string username);
        new Task<Employee> UpdateAsync(Employee employee);
    }
}
