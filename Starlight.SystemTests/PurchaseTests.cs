using NUnit.Framework;
using Starlight.SystemTests.Pages.CartPage;
using Starlight.SystemTests.Pages.CheckoutPage;
using Starlight.SystemTests.Pages.MainPage;
using Starlight.Web;
using Starlight.Web.Enums;
using Starlight.Web.Plugins;

namespace Starlight.SystemTests
{
    [TestFixture]
    [ExecutionBrowser(Browser.Chrome, BrowserBehavior.RestartEveryTime)]
    public class PurchaseTests : WebTest
    {
        private static MainPage _mainPage;
        private static CartPage _cartPage;
        private static CheckoutPage _checkoutPage;
        private static PurchaseFacade _purchaseFacade;

        public override void ClassInit()
        {
            ////ChromeOptions chromeOptions = new ();
            ////chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            ////App.AddBrowserOptions(chromeOptions);
        }

        public override void TestInit()
        {
            _mainPage = App.Create<MainPage>();
            _cartPage = App.Create<CartPage>();
            _checkoutPage = App.Create<CheckoutPage>();
            _purchaseFacade = new PurchaseFacade(_mainPage, _cartPage, _checkoutPage);
        }

        [Test]
        public void PurchaseFalcon9WithoutFacade()
        {
            App.GoTo<MainPage>();
            _mainPage.AddRocketToShoppingCart("Falcon 9");
            _cartPage.ApplyCoupon("happybirthday");
            _cartPage.AssertCouponAppliedSuccessfully();
            _cartPage.IncreaseProductQuantity(2);
            _cartPage.AssertTotalPrice("114.00€");
            _cartPage.ClickProceedToCheckout();

            var purchaseInfo = new PurchaseInfo()
            {
                Email = "alex@test.com",
                FirstName = "Alexandrina",
                LastName = "Varbanova",
                Company = "Test Company",
                Country = "Bulgaria",
                Address1 = "Kazbek 63",
                Address2 = "Viridian Offices",
                City = "Sofia",
                Zip = "1700",
                Phone = "+00359123456789",
            };
            _checkoutPage.FillBillingInfo(purchaseInfo);
            _checkoutPage.AssertOrderReceived();
        }

        [Test]
        public void PurchaseSaturnVWithoutFacade()
        {
            App.GoTo<MainPage>();
            _mainPage.AddRocketToShoppingCart("Saturn V");
            _cartPage.ApplyCoupon("happybirthday");
            _cartPage.AssertCouponAppliedSuccessfully();
            _cartPage.IncreaseProductQuantity(3);
            _cartPage.AssertTotalPrice("355.00€");
            _cartPage.ClickProceedToCheckout();

            var purchaseInfo = new PurchaseInfo()
            {
                Email = "alex@test.com",
                FirstName = "Alexandrina",
                LastName = "Varbanova",
                Company = "Test Company",
                Country = "Bulgaria",
                Address1 = "Kazbek 63",
                Address2 = "Viridian Offices",
                City = "Sofia",
                Zip = "1700",
                Phone = "+00359123456789",
            };
            _checkoutPage.FillBillingInfo(purchaseInfo);
            _checkoutPage.AssertOrderReceived();
        }

        [Test]
        public void PurchaseFalcon9WithFacade()
        {
            var purchaseInfo = new PurchaseInfo()
            {
                Email = "alex@test.com",
                FirstName = "Alexandrina",
                LastName = "Varbanova",
                Company = "Test Company",
                Country = "Bulgaria",
                Address1 = "Kazbek 63",
                Address2 = "Viridian Offices",
                City = "Sofia",
                Zip = "1700",
                Phone = "+00359123456789",
            };

            _purchaseFacade.PurchaseItem("Falcon 9", "happybirthday", 2, "114.00€", purchaseInfo);
        }

        [Test]
        public void PurchaseSaturnVWithFacade()
        {
            var purchaseInfo = new PurchaseInfo()
            {
                Email = "alex@test.com",
                FirstName = "Nadezhda",
                LastName = "Varbanova",
                Company = "Test Company",
                Country = "Bulgaria",
                Address1 = "Kazbek 63",
                Address2 = "Viridian Offices",
                City = "Sofia",
                Zip = "1700",
                Phone = "+00359123456789",
            };

            _purchaseFacade.PurchaseItem("Saturn V", "happybirthday", 3, "355.00€", purchaseInfo);
        }
    }
}
