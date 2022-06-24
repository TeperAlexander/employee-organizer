using System;

namespace EmployeeOrganizer.Models
{
    public class Activity : Entity
    {
        public long UserId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public long EmployeeId { get; set; }
    }
}
