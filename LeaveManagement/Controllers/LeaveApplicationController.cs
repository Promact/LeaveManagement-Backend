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
    //TODO: Add authentication to specific methods
    //List method: Admin should get all leaves, employee should get only his/her leave
    //Post: Only employee can apply his own leave
    //Put: Only admin can change status of leave application
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveApplicationController : ControllerBase
    {
        private readonly LeaveManagementDbContext _context;
        private readonly IMapper _mapper;

        public LeaveApplicationController(LeaveManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/LeaveApplication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveApplicationDTO>>> LeaveApplication()
        {
            var dbLeaveApplications = await _context.LeaveApplication.Include("Employee").Include("LeaveType").ToListAsync();

            var leaveApplicationDTOs = _mapper.Map<List<LeaveApplicationDTO>>(dbLeaveApplications);

            return leaveApplicationDTOs;
        }

        // PUT: api/LeaveApplication/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveApplication(int id, LeaveApplicationDTO leaveApplicationDTO)
        {
            if (id != leaveApplicationDTO.Id)
            {
                return BadRequest();
            }

            var dbLeaveApplication = _context.LeaveApplication.FirstOrDefault(x => x.Id == leaveApplicationDTO.Id);

            if (dbLeaveApplication == null)
            {
                return NotFound();
            }

            dbLeaveApplication.LeaveStatus = leaveApplicationDTO.LeaveStatus;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/LeaveApplication
        [HttpPost]
        public async Task<ActionResult<LeaveApplication>> PostLeaveApplication(LeaveApplicationDTO leaveApplicationDTO)
        {
            //TODO: Assign current user id here



            var dbLeaveApplication = new LeaveApplication()
            {
                EmployeeId = 12,
                LeaveStartDate = leaveApplicationDTO.LeaveStartDate,
                LeaveEndDate = leaveApplicationDTO.LeaveEndDate,
                LeaveTypeId = leaveApplicationDTO.LeaveTypeId
            };

            _context.LeaveApplication.Add(dbLeaveApplication);
            await _context.SaveChangesAsync();

            leaveApplicationDTO.Id = dbLeaveApplication.Id;

            return CreatedAtAction("LeaveApplication", new { id = leaveApplicationDTO.Id }, leaveApplicationDTO);
        }
    }
}
