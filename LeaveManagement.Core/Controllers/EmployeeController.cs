using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeaveManagement.Repository.DTOs;
using LeaveManagement.Repository.Services;

namespace LeaveManagement.Core.Controllers
{
    //TODO: Allow only admin to call all methods of this controller except get (which is restricted to specific employee to get his own data in profile page)
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {
            
            IEnumerable<EmployeeDTO> employeeDTOs = await _employeeService.GetAllEmployees();
            return Ok(employeeDTOs);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> Get(int id)
        {
            EmployeeDTO employeeDTO = await _employeeService.GetEmployeeById(id);
            return employeeDTO;
        }

        //// PUT: api/Employee/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, EmployeeDTO employeeDTO)
        //{
        //    if (id != employeeDTO.Id)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _entityRepository.PutEntityAsync(id, employeeDTO);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }
        //    catch (MissingFieldException)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        //// POST: api/Employee
        //[HttpPost]
        //public async Task<ActionResult<EmployeeDTO>> Add(EmployeeDTO employeeDTO)
        //{

        //    employeeDTO = await _entityRepository.PostEntityAsync(employeeDTO);

        //    return CreatedAtAction("GetEmployee", new { id = employeeDTO.Id }, employeeDTO);
        //}

        //// DELETE: api/Employee/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<EmployeeDTO>> Delete(int id)
        //{
        //    try
        //    {
        //        var employeeDTO = await _entityRepository.DeleteEntityAsync(id);
        //        return employeeDTO;
        //    }
        //    catch (NullReferenceException)
        //    {
        //        return NoContent();
        //    }
        //}


    }
}
