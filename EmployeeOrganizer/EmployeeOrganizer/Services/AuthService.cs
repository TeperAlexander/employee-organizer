using EmployeeOrganizer.DTOs;
using EmployeeOrganizer.Repositories;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly IEmployeeRepository _employeeRepository;
        public AuthService(IJwtService jwtService, IEmployeeRepository employeeRepository)
        {
            _jwtService = jwtService;
            _employeeRepository = employeeRepository;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var employee = await _employeeRepository.FindByUsernameAsync(loginRequestDTO.Username);
            if (employee == null || !BCrypt.Net.BCrypt.Verify(loginRequestDTO.Password, employee.Password))
            {
                return null;
            }

            var token = _jwtService.CreateToken(loginRequestDTO.Username);
            return new LoginResponseDTO { Token = token, UserId = employee.Id, Username = employee.Username };

        }
    }
}
