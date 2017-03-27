using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sel0400.Framework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel0400.Framework.Pages.MainPages
{
    class HeaderMenu
    {
    private readonly IWebDriver _driver;

    private readonly TextLabel QuantityProductsInCheckoutTextLabel;
    private readonly TextLabel TotalCostProductsTextLabel;

    private readonly Link CheckoutLink;

    public HeaderMenu(IWebDriver driver)
    {
      _driver = driver;
      QuantityProductsInCheckoutTextLabel = new TextLabel(_driver, By.CssSelector(".quantity"));
      TotalCostProductsTextLabel = new TextLabel(_driver, By.CssSelector(".formatted_value"));
      CheckoutLink = new Link(_driver, By.XPath(".//*[@id='cart']/a[3]"));
    }

    public int GetQuantityProductsInCheckout()
    {
        QuantityProductsInCheckoutTextLabel.WaitForElement();
        return int.Parse(QuantityProductsInCheckoutTextLabel.GetText());
    }

    public string GetTotalCostProducts()
    {
        TotalCostProductsTextLabel.WaitForElement();
        return TotalCostProductsTextLabel.GetText();
    }

    public void WaitAddProductToCheckout(int currentQuantityProduct)
    {
        WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
        wait.Until(ExpectedConditions.TextToBePresentInElement(QuantityProductsInCheckoutTextLabel.GetElement(), currentQuantityProduct.ToString()));
    }

    public void OpenCheckoutPage()
    {
        CheckoutLink.Click();
    }

    }
}
