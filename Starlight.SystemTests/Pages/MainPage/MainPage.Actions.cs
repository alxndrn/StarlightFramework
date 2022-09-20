using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests.Pages.MainPage
{
    public partial class MainPage : NavigatableShopPage
    {
        public override string Url => "http://demos.bellatrix.solutions/";

        public override void WaitForPageToLoad()
        {
            AddToCartFalcon9Button.ToExists().WaitToBe();
        }

        public void AddRocketToShoppingCart(string rocketName)
        {
            Open();
            GetProductBoxByName(rocketName).Click();
            BrowserService.WaitForAjax();
            AddToCartButton.Click();
            ViewCartButton.Click();
        }
    }
}
