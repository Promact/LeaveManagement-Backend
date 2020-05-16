using AutoMapper;
using LeaveManagement.DomainModel.Models;
using LeaveManagement.Repository.DTOs;

namespace LeaveManagement.Web
{
    public class LeaveManagementAutomapperProfile : Profile
    {
        public LeaveManagementAutomapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveApplication, LeaveApplicationDTO>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.LeaveTypeName, opt => opt.MapFrom(src => src.LeaveType.Name))
                .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => (src.LeaveEndDate - src.LeaveStartDate).TotalDays))
                .ReverseMap();
        }
    }
}
