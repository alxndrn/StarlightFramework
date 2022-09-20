using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web
{
    public interface INavigationService
    {
        void GoToUrl(string url);
        Uri Url { get; }
    }
}
