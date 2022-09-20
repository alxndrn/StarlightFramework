using Starlight.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.SystemTests.Pages.MainPage
{
    public partial class MainPage
    {
        public Anchor AddToCartFalcon9Button => ElementCreateService.CreateByCss<Anchor>("[data-product_id='28']");

        public Button ViewCartButton => ElementCreateService.CreateByLinkText<Button>("View cart");
        public Button AddToCartButton => ElementCreateService.CreateByClass<Button>("single_add_to_cart_button button alt");

        public Anchor GetProductBoxByName(string name)
        {
            return ElementCreateService.CreateByXPath<Anchor>($"//h2[text()='{name}']/parent::a[1]");
        }
    }
}
