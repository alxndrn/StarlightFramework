using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests.Pages.MainPage
{
    public partial class MainPage
    {
        public void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = GetProductBoxByName(name).GetAttribute("href");
            Assert.AreEqual(expectedLink, actualLink);
        }
    }
}
