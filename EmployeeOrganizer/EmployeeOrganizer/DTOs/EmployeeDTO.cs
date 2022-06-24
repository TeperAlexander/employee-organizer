using EmployeeOrganizer.Models;

namespace EmployeeOrganizer.DTOs
{
    public class EmployeeDTO
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public long? SuperiorId { get; set; }
        public long? DepartmentId { get; set; }
        public long? RankId { get; set; }
        public string Password { get; set; }

        public Rank Rank { get; set; }
        public Department Department { get; set; }

        public EmployeeDTO(Employee employee)
        {
            PhoneNumber = employee.PhoneNumber;
            Username = employee.Username;
            SuperiorId = employee.SuperiorId;
            DepartmentId = employee.DepartmentId;
            RankId = employee.RankId;
            Name = employee.Name;
            Id = employee.Id;
            Department = employee.Department;
            Rank = employee.Rank;
            Password = employee.Password;
        }
    }
}
