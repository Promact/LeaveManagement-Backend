
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class EmployeeLeaveMapping
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int LeaveId { get; set; }

        public DateTime LeaveStartDate { get; set; }

        public DateTime LeaveEndDate { get; set; }

        public LeaveStatus LeaveStatus { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("LeaveId")]
        public virtual Leave Leave { get; set; }
    }
}
