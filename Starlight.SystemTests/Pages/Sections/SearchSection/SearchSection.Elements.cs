using Starlight.Web;
using Starlight.Web.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests.Pages.Sections.SearchSection
{
    public partial class SearchSection : Page
    {
        public TextField SearchField => ElementCreateService.CreateById<TextField>("woocommerce-product-search-field-0");
    }
}
