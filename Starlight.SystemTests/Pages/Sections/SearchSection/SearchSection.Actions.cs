using Starlight.Web.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests.Pages.Sections.SearchSection
{
    public partial class SearchSection : Page
    {
        public void Search(string searchFor)
        {
            SearchField.TypeText(searchFor);
        }
    }
}
