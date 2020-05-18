//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using LeaveManagement.Repository.Repository;
//using LeaveManagement.Repository.DTOs;
//using LeaveManagement.DomainModel.Models;

//namespace LeaveManagement.Core.Controllers
//{
//    //TODO: Add authentication to specific methods
//    //List method: Admin should get all leaves, employee should get only his/her leave
//    //Post: Only employee can apply his own leave
//    //Put: Only admin can change status of leave application
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LeaveApplicationController : ControllerBase
//    {
//        private readonly IEntityRepository<LeaveApplication,LeaveApplicationDTO> _entityRepository;

//        public LeaveApplicationController(IEntityRepository<LeaveApplication, LeaveApplicationDTO> entityRepository)
//        {
//            _entityRepository = entityRepository;
//        }

//        // GET: api/LeaveApplication
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<LeaveApplicationDTO>>> LeaveApplication()
//        {

//            var leaveApplicationDTOs = await _entityRepository.GetEntityAsync();

//            return Ok(leaveApplicationDTOs);
//        }

//        // PUT: api/LeaveApplication/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutLeaveApplication(int id, LeaveApplicationDTO leaveApplicationDTO)
//        {
//            if (id != leaveApplicationDTO.Id)
//            {
//                return BadRequest();
//            }

//            try
//            {
//                await _entityRepository.PutEntityAsync(id, leaveApplicationDTO, "LeaveStatus");
//            }
//            catch (NullReferenceException)
//            {
//                return NotFound();
//            }

//            return NoContent();
//        }

//        // POST: api/LeaveApplication
//        [HttpPost]
//        public async Task<ActionResult<LeaveApplication>> PostLeaveApplication(LeaveApplicationDTO leaveApplicationDTO)
//        {
//            //TODO: Assign current user id here


//            leaveApplicationDTO.EmployeeId = 12;
            
//           leaveApplicationDTO = await _entityRepository.PostEntityAsync(leaveApplicationDTO);
            

//            return CreatedAtAction("LeaveApplication", new { id = leaveApplicationDTO.Id }, leaveApplicationDTO);
//        }
//    }
//}
