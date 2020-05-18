using AutoMapper;
using LeaveManagement.DomainModel.Models;
using LeaveManagement.Repository.DTOs;

namespace LeaveManagement.Repository.Automapper
{
    public class AutoMapperConfig : Profile
    {
        public void AutoMapping()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
