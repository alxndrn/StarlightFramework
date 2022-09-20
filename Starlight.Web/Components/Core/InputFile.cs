using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web
{
    public class InputFile : Element
    {
        public void Upload(string file)
        {
            WrappedElement.SendKeys(file);
        }
    }
}
