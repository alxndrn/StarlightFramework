using Starlight.App;
using Starlight.Web.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web
{
    public class WebApp : BaseApp
    {
        private IDriver _driver;

        public WebApp()
        {
            _driver = ServiceContainer.Resolve<IDriver>();
        }

        public IElementCreateService ElementCreateService => _driver;
        public IBrowserService BrowserService => _driver;
        public INavigationService NavigationService => _driver;
        public ICookiesService CookiesService => _driver;
        public IDialogService DialogService => _driver;
        public IInteractionsService InteractionsService => _driver;
        public IJavaScriptService JavaScriptService => _driver;

        public void AddBrowserOptions<TOption>(TOption customOptions)
            where TOption : class
        {
            ServiceContainer.RegisterInstance(customOptions, Guid.NewGuid().ToString());
        }

        public TPage Create<TPage>()
            where TPage : Page
        {
            return ServiceContainer.Resolve<TPage>();
        }

        public TPage GoTo<TPage>()
           where TPage : NavigatablePage
        {
            var page = ServiceContainer.Resolve<TPage>();
            page.Open();
            return page;
        }
    }
}
