using LeaveManagement.DomainModel.Enums;
using System;

namespace LeaveManagement.Repository.DTOs
{
    public class LeaveApplicationDTO
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime LeaveStartDate { get; set; }

        public DateTime LeaveEndDate { get; set; }

        public int LeaveTypeId { get; set; }

        public string LeaveTypeName { get; set; }

        public int NumberOfDays { get; set; }

        public LeaveStatus LeaveStatus { get; set; }
    }
}
