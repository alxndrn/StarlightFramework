using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web.FindStrategies
{
    public class ClassFindStrategy : FindStrategy
    {
        public ClassFindStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.XPath($"//*[@class='{Value}']");
    }
}
