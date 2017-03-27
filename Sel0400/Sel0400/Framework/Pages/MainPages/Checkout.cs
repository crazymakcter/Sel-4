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
  public class Checkout
  {
      private readonly IWebDriver _driver;
      private readonly WebControl ProductsInTable;

      private readonly Button RemoveProductButton;

    //private readonly WebControl MostPopularProducts;

    public Checkout(IWebDriver driver)
    {
      _driver = driver;
      //MostPopularProducts = new WebControl(_driver, By.XPath(".//*[@id='box-most-popular']/div/ul/li"));
      ProductsInTable = new WebControl(_driver, By.CssSelector("td.item"));
      RemoveProductButton = new Button(_driver, By.CssSelector(".item>form>div>p>button"));
    }

     public int GetCountProductInCheckout()
    {
       return ProductsInTable.GetElements().Count();
    }

      public void RemoveProductFromCheckout()
     {
         RemoveProductButton.Click();
     }

      public void WaitAddProductToCheckout(int currentQuantityProduct)
      {
          WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
          //wait.Until(ExpectedConditions.(ProductsInTable.GetElement(), "ii"));
      }
  }
}
