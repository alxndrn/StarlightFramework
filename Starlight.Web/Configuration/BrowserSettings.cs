using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web
{
    public class BrowserSettings
    {
        public int PageLoadTimeout { get; set; } = 30;
        public int ScriptTimeout { get; set; } = 10;
    }
}
