using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class LeaveType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MaximumLeavesAllowed { get; set; }
    }
}
