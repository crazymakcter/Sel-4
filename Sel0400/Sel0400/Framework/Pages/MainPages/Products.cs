using System.Collections.Generic;
using OpenQA.Selenium;
using Sel0400.Framework.Controls;
using OpenQA.Selenium.Support.UI;

namespace Sel0400.Framework.Pages.MainPages
{
  public class Products
  {
    private readonly IWebDriver _driver;

    private readonly WebControl MostPopularProducts;
    private readonly WebControl ProductSizeSelectbox;
    private readonly Button AddProductButton;

    public Products(IWebDriver driver)
    {
      _driver = driver;
      MostPopularProducts = new WebControl(_driver, By.XPath(".//*[@id='box-most-popular']/div/ul/li"));
      ProductSizeSelectbox = new WebControl(_driver, By.CssSelector(".options>select"));
      AddProductButton = new Button(_driver, By.CssSelector(".quantity>button"));
    }

    public void OpenProductPage()
    {
      
    }

    public void OpenFirstMostPopularProduct()
    {
      MostPopularProducts.WaitForElement();
      MostPopularProducts.GetElement().Click();
    }

    public void AddProductToCheckout()
    {
        if (ProductSizeSelectbox.ElementDisplayed())
        {
            SelectProductSize("Small");
        }
        
        AddProductButton.Click();
    }

    public void SelectProductSize(string value)
    {
        ProductSizeSelectbox.WaitForElement();
        SelectElement size = new SelectElement(ProductSizeSelectbox.GetElement());
        size.SelectByText(value);
    }
  }
}
