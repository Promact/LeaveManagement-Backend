using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Repository.DTOs
{
    public class LeaveTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MaximumLeavesAllowed { get; set; }
    }
}
