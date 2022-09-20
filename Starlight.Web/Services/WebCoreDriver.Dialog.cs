using OpenQA.Selenium;
using Starlight.Web.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web.Services
{
    public partial class WebCoreDriver : IDialogService
    {
        public void Handle(Action<IAlert> action = null, DialogButton dialogButton = DialogButton.Ok)
        {
            var alert = _webDriver.SwitchTo().Alert();
            action?.Invoke(alert);
            if (dialogButton == DialogButton.Ok)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }

            _webDriver.SwitchTo().DefaultContent();
        }
    }
}
