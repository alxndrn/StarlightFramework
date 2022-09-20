using Starlight.Web;
using Starlight.Web.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests.Pages.Sections
{
    public partial class BreadcrumbSection : Page
    {
        public void OpenBreadcrumbItem(string itemToOpen)
        {
            Breadcrumb.CreateByLinkText<Anchor>(itemToOpen).Click();
        }
    }
}
