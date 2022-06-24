using EmployeeOrganizer.Models;

namespace EmployeeOrganizer.Repositories
{
    public class RankRepository : GenericRepository<Rank>, IRankRepository
    {
        public RankRepository(ApplicationContext context) : base(context)
        {
        }


    }
}
