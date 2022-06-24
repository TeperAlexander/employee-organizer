using EmployeeOrganizer.DTOs;
using EmployeeOrganizer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost()]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            var loginResponse = await _authService.LoginAsync(loginRequestDTO);
            if (loginResponse == null)
            {
                return BadRequest("Username or password mismatch");
            }
            return Ok(loginResponse);
        }
    }
}
