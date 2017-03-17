using System.Linq;
using OpenQA.Selenium;
using Sel0400.Framework.Controls;
using Sel0400.Framework.Data.Catalog;

namespace Sel0400.Framework.Pages.AdminPages.Catalog
{
  class Catalog
  {
    private readonly IWebDriver _driver;
    protected Button AddProductButton;

    protected WebControl ProductsWithOutCategory;

    public Catalog(IWebDriver driver)
    {
      _driver = driver;
      AddProductButton = new Button(_driver, By.XPath(".//*[@id='content']/div[1]/a[2]"));

      ProductsWithOutCategory = new WebControl(_driver, By.CssSelector(".row.semi-transparent>td>a"));
    }

    public void ClickAddNewProductButton()
    {
      AddProductButton.WaitForElement();
      AddProductButton.Click();
    }

    public bool ProductWithoutCategoryIsDisplayed(string productName)
    {
      ProductsWithOutCategory.WaitForElement();
      return ProductsWithOutCategory.GetElements().Any(element => element.Text == productName);
    }
  }

}
