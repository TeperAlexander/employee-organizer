
namespace EmployeeOrganizer.Models
{
    public class Employee : Entity
    {
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Employee Superior { get; set; }
        public long? SuperiorId { get; set; }
        public Department Department { get; set; }
        public long? DepartmentId { get; set; }
        public long? RankId { get; set; }
        public Rank Rank { get; set; }

    }
}
