using Starlight.Web;
using Starlight.Web.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests.Pages.Sections.ViewCartSection
{
    public partial class ViewCartSection : Page
    {
        public Web.Span CartAmount => ElementCreateService.CreateByClass<Web.Span>("amount");
        public Anchor CartIcon => ElementCreateService.CreateByClass<Anchor>("cart-contents");
    }
}
