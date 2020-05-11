using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfJoining { get; set; }

        public int Salary { get; set; }

        public string Email { get; set; }
    }
}
