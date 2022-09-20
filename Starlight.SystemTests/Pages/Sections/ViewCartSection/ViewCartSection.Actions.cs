using Starlight.Web.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests.Pages.Sections.ViewCartSection
{
    public partial class ViewCartSection : Page
    {
        public string GetCurrentAmount()
        {
            return CartAmount.InnerText;
        }

        public void OpenCart()
        {
            CartIcon.Click();
        }
    }
}
