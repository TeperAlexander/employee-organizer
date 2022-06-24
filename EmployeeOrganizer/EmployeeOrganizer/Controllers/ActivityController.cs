using EmployeeOrganizer.Models;
using EmployeeOrganizer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Activity activity)
        {
            var result = await _activityRepository.AddAsync(activity);
            return CreatedAtAction(nameof(Add), result);
        }
    }
}
