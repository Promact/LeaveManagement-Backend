using LeaveManagement.Repository.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Repository.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeById(int id);
    }
}
