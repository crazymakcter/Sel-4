using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Sel0400.Framework.Controls;

namespace Sel0400.Framework.Pages.AdminPages.Catalog
{
  class Catalog
  {
    private readonly IWebDriver _driver;
    protected Button AddProductButton;
    protected Link RubberDuckCategory;
    protected Link SubCategory;

    protected WebControl ProductsWithOutCategory;
    protected Link ProductEditLink;

    public Catalog(IWebDriver driver)
    {
      _driver = driver;
      AddProductButton = new Button(_driver, By.XPath(".//*[@id='content']/div[1]/a[2]"));

      RubberDuckCategory = new Link(_driver, By.XPath(".//*[@id='content']/form/table/tbody/tr[3]/td[3]/a"));
      SubCategory = new Link(_driver, By.XPath(".//*[@id='content']/form/table/tbody/tr[4]/td[3]/a"));

      ProductsWithOutCategory = new WebControl(_driver, By.CssSelector(".row.semi-transparent>td>a"));
      ProductEditLink = new Link(_driver, By.CssSelector(".fa.fa-pencil"));
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

    public void OpenRubberDuckCategory()
    {
      RubberDuckCategory.WaitForElement();
      RubberDuckCategory.Click();
    }

    public void OpenSubCategory()
    {
      SubCategory.WaitForElement();
      SubCategory.Click();
    }

    public IList<IWebElement> GetAllProductEditLinks()
    {
      return ProductEditLink.GetElements();
    }
  }
}
