using EmployeeOrganizer.Models;
using EmployeeOrganizer.Repositories;

namespace EmployeeOrganizer.Services
{
    public class RankService : LogicService<Rank>, IRankService
    {

        private readonly IRankRepository _rankRepository;
        public RankService(IGenericRepository<Rank> repository, IRankRepository rankRepository) : base(repository)
        {
            _rankRepository = rankRepository;
        }

    }
}
