using Starlight.Web.Enums;
using Starlight.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web.Plugins
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ExecutionBrowserAttribute : Attribute
    {
        public ExecutionBrowserAttribute(Web.Browser browser, BrowserBehavior browserBehavior)
        {
            BrowserConfiguration = new BrowserConfiguration(browser, browserBehavior);
        }

        public BrowserConfiguration BrowserConfiguration { get; set; }
    }
}
