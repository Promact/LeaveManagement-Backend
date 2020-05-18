using AutoMapper;
using LeaveManagement.DomainModel.DataRepository;
using LeaveManagement.Repository.Automapper;
using LeaveManagement.Repository.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;

namespace LeaveManagement.Test
{
    public class Bootstrap
    {
        #region public properties

        public readonly IServiceProvider ServiceProvider;

        #endregion

        #region Constructor
        public Bootstrap()
        {
            var services = new ServiceCollection();

            #region Setup parameters

            #endregion

            #region Dependecy-Injection

            services.AddScoped<IEmployeeService, EmployeeService>();

            #endregion

            #region Mocks

            //DataRepository
            var dataRepositoryMock = new Mock<IDataRepository>();
            dataRepositoryMock.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0));
            services.AddSingleton(x => dataRepositoryMock);
            services.AddSingleton(x => dataRepositoryMock.Object);
            services.AddAutoMapper(typeof(Bootstrap));

            #endregion

            #region AutoMapper

            #endregion

            ServiceProvider = services.BuildServiceProvider();
        }
        #endregion

    }
}
