using Microsoft.Extensions.DependencyInjection;
using System;

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

            #endregion

            #region Mocks

            #endregion

            ServiceProvider = services.BuildServiceProvider();
        }
        #endregion

    }
}
