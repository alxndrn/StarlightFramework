using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web
{
    public interface IDriver : INavigationService, IBrowserService, ICookiesService, IElementCreateService, IDialogService, IJavaScriptService, IInteractionsService
    {
    }
}
