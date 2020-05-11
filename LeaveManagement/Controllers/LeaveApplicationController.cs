using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Models;

namespace LeaveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveApplicationController : ControllerBase
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveApplicationController(LeaveManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeLeaveApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeLeaveApplication>>> GetEmployeeLeaveApplication()
        {
            return await _context.EmployeeLeaveApplication.ToListAsync();
        }

        // GET: api/EmployeeLeaveApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeLeaveApplication>> GetEmployeeLeaveApplication(int id)
        {
            var employeeLeaveApplication = await _context.EmployeeLeaveApplication.FindAsync(id);

            if (employeeLeaveApplication == null)
            {
                return NotFound();
            }

            return employeeLeaveApplication;
        }

        // PUT: api/EmployeeLeaveApplications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeLeaveApplication(int id, EmployeeLeaveApplication employeeLeaveApplication)
        {
            if (id != employeeLeaveApplication.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeLeaveApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeLeaveApplicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeLeaveApplications
        [HttpPost]
        public async Task<ActionResult<EmployeeLeaveApplication>> PostEmployeeLeaveApplication(EmployeeLeaveApplication employeeLeaveApplication)
        {
            _context.EmployeeLeaveApplication.Add(employeeLeaveApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeLeaveApplication", new { id = employeeLeaveApplication.Id }, employeeLeaveApplication);
        }

        // DELETE: api/EmployeeLeaveApplications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeLeaveApplication>> DeleteEmployeeLeaveApplication(int id)
        {
            var employeeLeaveApplication = await _context.EmployeeLeaveApplication.FindAsync(id);
            if (employeeLeaveApplication == null)
            {
                return NotFound();
            }

            _context.EmployeeLeaveApplication.Remove(employeeLeaveApplication);
            await _context.SaveChangesAsync();

            return employeeLeaveApplication;
        }

        private bool EmployeeLeaveApplicationExists(int id)
        {
            return _context.EmployeeLeaveApplication.Any(e => e.Id == id);
        }
    }
}
