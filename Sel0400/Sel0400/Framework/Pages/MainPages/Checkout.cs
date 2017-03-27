using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sel0400.Framework.Controls;
using System;

namespace Sel0400.Framework.Pages.MainPages
{
  public class Checkout
  {
      private readonly IWebDriver _driver;
      private readonly WebControl ProductsInTable;

      private readonly Button RemoveProductButton;

    private readonly TextLabel NameProductInSlader;
    private readonly TextBox TextAboutEmptyCheckout;

    //private readonly WebControl MostPopularProducts;

    public Checkout(IWebDriver driver)
    {
      _driver = driver;
      //MostPopularProducts = new WebControl(_driver, By.XPath(".//*[@id='box-most-popular']/div/ul/li"));
      ProductsInTable = new WebControl(_driver, By.CssSelector("td.item"));
      RemoveProductButton = new Button(_driver, By.XPath(".//*[@id='box-checkout-cart']/div/ul/li[1]/form/div/p[4]/button"));
      NameProductInSlader = new TextLabel(_driver, By.CssSelector(".item>form>div>p>a>strong"));
      TextAboutEmptyCheckout = new TextBox(_driver, By.CssSelector("#checkout-cart-wrapper>p>em"));
    }

     public int GetCountProductInCheckout()
    {
       return ProductsInTable.GetElements().Count;
    }

    public string GetNameProductForRemove()
    {
      return NameProductInSlader.GetText();
    }


      public void RemoveProductFromCheckout()
     {
        RemoveProductButton.WaitForElement();
        RemoveProductButton.Click();
     }

      public void WaitAddProductToCheckout(string nameRemoveProduct)
      {
          var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
          wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.CssSelector("td.item"), nameRemoveProduct));
      }

    public string GetTextAboutEmptyCheckout()
    {
      return TextAboutEmptyCheckout.GetText();
    }
  }
}
