using LeaveManagement.DomainModel.DataRepository;
using LeaveManagement.DomainModel.Models;
using LeaveManagement.Repository.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace LeaveManagement.Test.EmployeeServiceTest
{
    [Collection("Register Dependency")]
    public class EmployeeServiceTest : BaseTest
    {
        #region Private Variables

        private Mock<IDataRepository> _dataRepository;
        private IEmployeeService _employeeService;

        #endregion

        #region Constructor
        public EmployeeServiceTest(Bootstrap bootstrap) : base(bootstrap)
        {
            _employeeService = bootstrap.ServiceProvider.GetService<IEmployeeService>();
            _dataRepository = bootstrap.ServiceProvider.GetService<Mock<IDataRepository>>();
            _dataRepository.Reset();
        }
        #endregion

        #region Test Methods

        #endregion
    }
}
