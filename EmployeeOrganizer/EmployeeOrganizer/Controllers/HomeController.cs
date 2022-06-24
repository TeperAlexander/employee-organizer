using EmployeeOrganizer.DTOs;
using EmployeeOrganizer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IRankService _rankService;

        public HomeController(IEmployeeService employeeService, IDepartmentService departmentService, IRankService rankService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _rankService = rankService;
        }


        [HttpGet]
        public async Task<IActionResult> GetGlobalState()
        {
            var employees = await _employeeService.Query(e => e.Id > 0).ToListAsync();
            var ranks = await _rankService.Query(e => e.Id > 0).ToListAsync();
            var departments = await _departmentService.Query(e => e.Id > 0).ToListAsync();


            var globalState = new GlobalStateDTO
            {
                Employees = employees.Select(e => new EmployeeDTO(e)).ToList(),
                Ranks = ranks,
                Departments = departments
            };
            return Ok(globalState);

        }
    }
}
