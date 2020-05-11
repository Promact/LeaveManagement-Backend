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
    //TODO: Allow only admin to call all methods of this controller except get (which is restricted to specific employee to get his own data in profile page)
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly LeaveManagementDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(LeaveManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployee()
        {
            var dbEmployees = await _context.Employee.ToListAsync();

            var employeeDTOs = _mapper.Map<List<EmployeeDTO>>(dbEmployees);

            return employeeDTOs;
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var dbEmployee = await _context.Employee.FindAsync(id);

            if (dbEmployee == null)
            {
                return NotFound();
            }

            var employeeDTO = _mapper.Map<EmployeeDTO>(dbEmployee);

            return employeeDTO;
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id)
            {
                return BadRequest();
            }

            var dbEmployee = _mapper.Map<Employee>(employeeDTO);

            _context.Entry(dbEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee(EmployeeDTO employeeDTO)
        {
            var dbEmployee = _mapper.Map<Employee>(employeeDTO);

            _context.Employee.Add(dbEmployee);

            await _context.SaveChangesAsync();

            employeeDTO.Id = dbEmployee.Id;

            return CreatedAtAction("GetEmployee", new { id = employeeDTO.Id }, employeeDTO);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDTO>> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return employeeDTO;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
