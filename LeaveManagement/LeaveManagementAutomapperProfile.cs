using AutoMapper;
using LeaveManagement.DTOs;
using LeaveManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement
{
    public class LeaveManagementAutomapperProfile : Profile
    {
        public LeaveManagementAutomapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<LeaveType, LeaveType>().ReverseMap();
            CreateMap<LeaveApplication, LeaveApplicationDTO>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.LeaveTypeName, opt => opt.MapFrom(src => src.LeaveType.Name))
                .ReverseMap();
        }
    }
}
