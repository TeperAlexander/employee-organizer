namespace EmployeeOrganizer.DTOs
{
    public class CreateEmployeeRequestDTO
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public long RankId { get; set; }
        public long DepartmentId { get; set; }
        public long? SuperiorId { get; set; }
    }
}
