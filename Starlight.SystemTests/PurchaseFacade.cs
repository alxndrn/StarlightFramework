using Starlight.SystemTests.Pages.CartPage;
using Starlight.SystemTests.Pages.CheckoutPage;
using Starlight.SystemTests.Pages.MainPage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests
{
    public class PurchaseFacade
    {
        private readonly MainPage _mainPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutPage _checkoutPage;

        public PurchaseFacade(MainPage mainPage, CartPage cartPage, CheckoutPage checkoutPage)
        {
            _mainPage = mainPage;
            _cartPage = cartPage;
            _checkoutPage = checkoutPage;
        }

        public void PurchaseItem(string rocketName, string couponName, int quantity, string expectedPrice, PurchaseInfo purchaseInfo)
        {
            _mainPage.Open();
            _mainPage.AddRocketToShoppingCart(rocketName);
            _cartPage.ApplyCoupon(couponName);
            _cartPage.AssertMessageNotification("Coupon code applied successfully.");
            _cartPage.IncreaseProductQuantity(quantity);
            _cartPage.AssertTotalPrice(expectedPrice);
            _cartPage.ClickProceedToCheckout();
            _checkoutPage.FillBillingInfo(purchaseInfo);
            _checkoutPage.AssertOrderReceived();
        }
    }
}
