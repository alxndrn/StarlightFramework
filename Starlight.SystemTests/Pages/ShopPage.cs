using Starlight.SystemTests.Pages.Sections;
using Starlight.SystemTests.Pages.Sections.SearchSection;
using Starlight.SystemTests.Pages.Sections.ViewCartSection;
using Starlight.Web.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests
{
    public abstract class ShopPage : Page
    {
        public MenuSection MainMenu => new MenuSection();
        public SearchSection SearchProduct => new SearchSection();
        public ViewCartSection ViewCart => new ViewCartSection();
    }
}
