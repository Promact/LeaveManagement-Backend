using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class LeaveManagementDbContext : DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<LeaveType> LeaveType { get; set; }

        public DbSet<EmployeeLeaveApplication> EmployeeLeaveApplication { get; set; }
    }
}
