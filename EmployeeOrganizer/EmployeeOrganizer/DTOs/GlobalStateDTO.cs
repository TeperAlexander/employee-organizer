using EmployeeOrganizer.Models;
using System.Collections.Generic;

namespace EmployeeOrganizer.DTOs
{
    public class GlobalStateDTO
    {
        public List<EmployeeDTO> Employees { get; set; }
        public List<Department> Departments { get; set; }
        public List<Rank> Ranks { get; set; }

    }
}
