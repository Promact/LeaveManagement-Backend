using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Repository.Repository;
using LeaveManagement.Repository.DTOs;
using LeaveManagement.DomainModel.Models;

namespace LeaveManagement.Core.Controllers
{
    //TODO: Allow only admin to call all methods of this controller except get
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IEntityRepository<LeaveType, LeaveTypeDTO> _entityRepository;
        

        public LeaveTypeController(IEntityRepository<LeaveType, LeaveTypeDTO> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        // GET: api/LeaveType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveTypeDTO>>> GetLeaveType()
        {

            var leaveTypeDTOs = await _entityRepository.GetEntityAsync();

            return Ok(leaveTypeDTOs);
        }

        // GET: api/LeaveType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> GetLeaveType(int id)
        {
            try
            {
                var leaveTypeDTO = await _entityRepository.GetEntityAsync(id);

                return leaveTypeDTO;
            }
            catch(NullReferenceException)
            {
                return NotFound();
            }
            
        }

        // PUT: api/LeaveType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveType(int id, LeaveTypeDTO leaveTypeDTO)
        {
            if (id != leaveTypeDTO.Id)
            {
                return BadRequest();
            }
            
            try
            {
                await _entityRepository.PutEntityAsync(id, leaveTypeDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (MissingFieldException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/LeaveType
        [HttpPost]
        public async Task<ActionResult<LeaveTypeDTO>> PostLeaveType(LeaveTypeDTO leaveTypeDTO)
        {
            leaveTypeDTO = await _entityRepository.PostEntityAsync(leaveTypeDTO);

            return CreatedAtAction("GetLeaveType", new { id = leaveTypeDTO.Id }, leaveTypeDTO);
        }

        // DELETE: api/LeaveType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> DeleteLeaveType(int id)
        {
            try
            {
                var leaveTypeDTO = await _entityRepository.DeleteEntityAsync(id);
                return leaveTypeDTO;
            }
            catch (NullReferenceException)
            {
                return NoContent();
            }
        }

    }
}
