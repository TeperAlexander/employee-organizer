using EmployeeOrganizer.DTOs;
using EmployeeOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Employee> AddAsync(CreateEmployeeRequestDTO request)
        {
            var employeeFromDb = await FindByUsernameAsync(request?.Username);
            if (employeeFromDb != null)
            {
                return null;
            }

            var employee = new Employee()
            {
                Name = request.Name,
                Username = request.Username,
                PhoneNumber = request?.PhoneNumber,
                Active = true,
                RankId = request?.RankId,
                DepartmentId = request?.DepartmentId,
                SuperiorId = request?.SuperiorId == 0 ? null : request?.SuperiorId,
                Password = BCrypt.Net.BCrypt.HashPassword(request?.Password)
            };

            
            return await base.AddAsync(employee);
        }

        public async Task<Employee> FindByUsernameAsync(string username)
        {
            return await _context.Set<Employee>().SingleOrDefaultAsync(e => e.Username == username);
        }

        public new async Task<Employee> UpdateAsync(Employee employee)
        {
            var employeeFromDb = await Query(e => e.Username == employee.Username && e.Id != employee.Id).SingleOrDefaultAsync();

            if (employeeFromDb != null)
            {
                return null;
            }

            if (employee.Password != null && employee.Password != "")
            {
                employee.Password = BCrypt.Net.BCrypt.HashPassword(employee?.Password);
            }

            if (employee.SuperiorId == 0)
            {
                employee.SuperiorId = null;
            }

            var newEmployee = await base.UpdateAsync(employee);
            return newEmployee;
        }
    }
}
