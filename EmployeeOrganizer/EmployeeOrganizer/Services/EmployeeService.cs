using EmployeeOrganizer.DTOs;
using EmployeeOrganizer.Models;
using EmployeeOrganizer.Repositories;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Services
{
    public class EmployeeService : LogicService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IGenericRepository<Employee> repository, IEmployeeRepository employeeRepository) : base(repository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> AddAsync(CreateEmployeeRequestDTO request)
        {
            var result = await _employeeRepository.AddAsync(request);
            return result;
        }

        public async Task<Employee> FindByUsernameAsync(string username)
        {
            return await _employeeRepository.FindByUsernameAsync(username);
        }

        public new async Task<Employee> UpdateAsync(Employee e)
        {
            var employee = await _employeeRepository.UpdateAsync(e);
            return employee;
        }
    }
}
