using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using Starlight.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web.Services
{
    public class DriverFactory : IDisposable
    {
        private bool _isDisposed;

        public void Start(BrowserConfiguration browserConfiguration)
        {
            _isDisposed = false;
            switch (browserConfiguration.ExecutionType)
            {
                case Enums.ExecutionType.Regular:
                    StartBrowserRegularMode(browserConfiguration);
                    break;
                case Enums.ExecutionType.Grid:
                    throw new NotImplementedException();
                    break;
                case Enums.ExecutionType.SauceLabs:
                    throw new NotImplementedException();
                    break;
                case Enums.ExecutionType.BrowserStack:
                    throw new NotImplementedException();
                    break;
                case Enums.ExecutionType.CrossBrowserTesting:
                    throw new NotImplementedException();
                    break;
            }
        }

        private void StartBrowserRegularMode(BrowserConfiguration browserConfiguration)
        {
            IWebDriver driver = default;
            switch (browserConfiguration.Browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver(Environment.CurrentDirectory);
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Chrome.PageLoadTimeout);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Chrome.ScriptTimeout);
                    break;
                case Browser.ChromeHeadless:
                    var chromeOptions = ServiceContainer.Resolve<ChromeOptions>("testClassFullName");
                    chromeOptions.AddArguments("--headless");
                    chromeOptions.AddArguments("--log-level=3");
                    driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Chrome.PageLoadTimeout);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Chrome.ScriptTimeout);
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver(Environment.CurrentDirectory);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Firefox.PageLoadTimeout);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Firefox.ScriptTimeout);
                    break;
                case Browser.Edge:
                    driver = new EdgeDriver(Environment.CurrentDirectory);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Edge.PageLoadTimeout);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Edge.ScriptTimeout);
                    break;
                case Browser.Safari:
                    driver = new SafariDriver(Environment.CurrentDirectory);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Safari.PageLoadTimeout);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Safari.ScriptTimeout);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserConfiguration.Browser), browserConfiguration.Browser, null);
            }

            ServiceContainer.RegisterInstance(driver);
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                var driver = ServiceContainer.Resolve<IWebDriver>();
                driver?.Quit();
                ServiceContainer.UnregisterInstance<IWebDriver>();
                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
        }
    }
}
