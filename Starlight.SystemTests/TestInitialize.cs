using NUnit.Framework;
using Starlight.Plugins;
using Starlight.Web.Plugins.Browser;
using Starlight.Web.Services;
using System;

namespace Starlight.SystemTests
{
    [SetUpFixture]
    public class TestsInitialize
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            ServiceContainer.RegisterType<BaseTestExecutionPluginObserver, BrowserLaunchPluginObserver>(Guid.NewGuid().ToString());
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            var driverFactory = ServiceContainer.Resolve<DriverFactory>();
            driverFactory.Dispose();
        }
    }
}
