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
    //TODO: Allow only admin to call all methods of this controller except get (which is restricted to specific employee to get his own data in profile page)
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEntityRepository<Employee,EmployeeDTO> _entityRepository;
        

        public EmployeeController(IEntityRepository<Employee,EmployeeDTO> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployee()
        {
            
            IEnumerable<EmployeeDTO> employeeDTOs = await _entityRepository.GetEntityAsync();

            return Ok(employeeDTOs);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            try
            {
                var employeeDTO = await _entityRepository.GetEntityAsync(id);
                return employeeDTO;
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _entityRepository.PutEntityAsync(id, employeeDTO);
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

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee(EmployeeDTO employeeDTO)
        {
            
            employeeDTO = await _entityRepository.PostEntityAsync(employeeDTO);

            return CreatedAtAction("GetEmployee", new { id = employeeDTO.Id }, employeeDTO);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDTO>> DeleteEmployee(int id)
        {
            try
            {
                var employeeDTO = await _entityRepository.DeleteEntityAsync(id);
                return employeeDTO;
            }
            catch (NullReferenceException)
            {
                return NoContent();
            }
        }

        
    }
}
