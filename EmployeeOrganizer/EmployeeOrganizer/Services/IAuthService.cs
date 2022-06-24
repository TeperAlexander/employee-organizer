using EmployeeOrganizer.DTOs;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
    }
}
