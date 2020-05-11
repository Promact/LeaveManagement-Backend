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
    //TODO: Allow only admin to call all methods of this controller except get
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveTypeController(LeaveManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/LeaveTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveType>>> GetLeaveType()
        {
            return await _context.LeaveType.ToListAsync();
        }

        // GET: api/LeaveTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveType>> GetLeaveType(int id)
        {
            var leaveType = await _context.LeaveType.FindAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            return leaveType;
        }

        // PUT: api/LeaveTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveType(int id, LeaveType leaveType)
        {
            if (id != leaveType.Id)
            {
                return BadRequest();
            }

            _context.Entry(leaveType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveTypeExists(id))
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

        // POST: api/LeaveTypes
        [HttpPost]
        public async Task<ActionResult<LeaveType>> PostLeaveType(LeaveType leaveType)
        {
            _context.LeaveType.Add(leaveType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveType", new { id = leaveType.Id }, leaveType);
        }

        // DELETE: api/LeaveTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveType>> DeleteLeaveType(int id)
        {
            var leaveType = await _context.LeaveType.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            _context.LeaveType.Remove(leaveType);
            await _context.SaveChangesAsync();

            return leaveType;
        }

        private bool LeaveTypeExists(int id)
        {
            return _context.LeaveType.Any(e => e.Id == id);
        }
    }
}
