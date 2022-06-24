using EmployeeOrganizer.Models;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationContext context) : base(context)
        {
        }

       
    }
}
