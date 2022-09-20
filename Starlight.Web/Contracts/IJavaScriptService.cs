using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web
{
    public interface IJavaScriptService
    {
        object Execute(string script);
    }
}
