using OpenQA.Selenium;
using Starlight.Web.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web
{
    public interface IDialogService
    {
        void Handle(Action<IAlert> action = null, DialogButton dialogButton = DialogButton.Ok);
    }
}
