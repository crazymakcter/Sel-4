using System.Collections.Generic;
using OpenQA.Selenium;
using Sel0400.Framework.Controls;

namespace Sel0400.Framework.Pages.MainPages
{
  public class Products
  {
    private readonly IWebDriver _driver;

    private readonly WebControl MostPopularProducts;

    public Products(IWebDriver driver)
    {
      _driver = driver;
      MostPopularProducts = new WebControl(_driver, By.XPath(".//*[@id='box-most-popular']/div/ul/li"));
    }

    public void OpenProductPage()
    {
      
    }

    public void OpenFirstMostPopularProduct()
    {
      MostPopularProducts.WaitForElement();
      MostPopularProducts.GetElement().Click();
    }
  }
}
