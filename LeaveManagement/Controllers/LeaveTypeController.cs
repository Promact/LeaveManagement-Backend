using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Models;
using AutoMapper;
using LeaveManagement.DTOs;

namespace LeaveManagement.Controllers
{
    //TODO: Allow only admin to call all methods of this controller except get
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly LeaveManagementDbContext _context;
        private readonly IMapper _mapper;

        public LeaveTypeController(LeaveManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/LeaveType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveTypeDTO>>> GetLeaveType()
        {
            var dbLeaveTypes = await _context.LeaveType.ToListAsync();

            var leaveTypeDTOs = _mapper.Map<List<LeaveTypeDTO>>(dbLeaveTypes);

            return leaveTypeDTOs;
        }

        // GET: api/LeaveType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> GetLeaveType(int id)
        {
            var dbLeaveType = await _context.LeaveType.FindAsync(id);

            if (dbLeaveType == null)
            {
                return NotFound();
            }

            var leaveTypeDTO = _mapper.Map<LeaveTypeDTO>(dbLeaveType);

            return leaveTypeDTO;
        }

        // PUT: api/LeaveType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveType(int id, LeaveTypeDTO leaveTypeDTO)
        {
            if (id != leaveTypeDTO.Id)
            {
                return BadRequest();
            }

            var dbLeaveType = _mapper.Map<LeaveType>(leaveTypeDTO);

            _context.Entry(dbLeaveType).State = EntityState.Modified;

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

        // POST: api/LeaveType
        [HttpPost]
        public async Task<ActionResult<LeaveTypeDTO>> PostLeaveType(LeaveTypeDTO leaveTypeDTO)
        {
            var dbLeaveType = _mapper.Map<LeaveType>(leaveTypeDTO);

            _context.LeaveType.Add(dbLeaveType);
            await _context.SaveChangesAsync();

            leaveTypeDTO.Id = dbLeaveType.Id;

            return CreatedAtAction("GetLeaveType", new { id = leaveTypeDTO.Id }, leaveTypeDTO);
        }

        // DELETE: api/LeaveType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> DeleteLeaveType(int id)
        {
            var dbLeaveType = await _context.LeaveType.FindAsync(id);
            if (dbLeaveType == null)
            {
                return NotFound();
            }

            _context.LeaveType.Remove(dbLeaveType);
            await _context.SaveChangesAsync();

            var leaveTypeDTO = _mapper.Map<LeaveTypeDTO>(dbLeaveType);

            return leaveTypeDTO;
        }

        private bool LeaveTypeExists(int id)
        {
            return _context.LeaveType.Any(e => e.Id == id);
        }
    }
}
