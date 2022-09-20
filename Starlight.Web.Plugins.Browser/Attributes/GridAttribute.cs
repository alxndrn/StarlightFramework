using OpenQA.Selenium;
using Starlight.Web.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web.Plugins
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class GridAttribute : ExecutionBrowserAttribute
    {
        public GridAttribute(Web.Browser browser, string browserVersion, PlatformType platformType, BrowserBehavior browserBehavior)
            : base(browser, browserBehavior)
        {
            BrowserConfiguration.ExecutionType = ExecutionType.Grid;
            BrowserVersion = browserVersion;
            PlatformType = platformType;
        }

        public string BrowserVersion { get; }

        public PlatformType PlatformType { get; }
    }
}
