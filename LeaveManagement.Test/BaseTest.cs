using Microsoft.Extensions.DependencyInjection;
using System;

namespace LeaveManagement.Test
{
    /// <summary>
    /// Base unit test class boilerplate
    /// Initializes/Disposes scope for each test case
    /// </summary>
    public class BaseTest : IDisposable
    {
        protected readonly IServiceScope _scope;

        public BaseTest(Bootstrap bootstrap)
        {
            _scope = bootstrap.ServiceProvider.CreateScope();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}