using AutoMapper;
using LeaveManagement.DomainModel.DataRepository;
using LeaveManagement.DomainModel.Models;
using LeaveManagement.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Repository.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        public Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
