using Starlight.SystemTests.Pages.Sections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests.Pages.CartPage
{
    public partial class CartPage : ShopPage
    {
        public BreadcrumbSection Breadcrumb => new BreadcrumbSection();

        public void ApplyCoupon(string coupon)
        {
            CouponCodeTextField.TypeText(coupon);
            ApplyCouponButton.Click();
            BrowserService.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            QuantityBox.TypeText(newQuantity.ToString());
            UpdateCart.Click();
            BrowserService.WaitForAjax();
        }

        public void ClickProceedToCheckout()
        {
            ProceedToCheckout.Click();
            BrowserService.WaitUntilPageLoadsCompletely();
        }
    }
}
