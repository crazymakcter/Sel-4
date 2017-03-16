using OpenQA.Selenium;
using Sel0400.Framework.Controls;

namespace Sel0400.Framework.Pages.AdminPages.Catalog
{
  class Catalog
  {
    private readonly IWebDriver _driver;
    protected Button AddProductButton;

    public Catalog(IWebDriver driver)
    {
      AddProductButton = new Button(_driver, By.XPath(".//*[@id='content']/div[1]/a[2]"));
    }

    public void ClickAddNewProductButton()
    {
      AddProductButton.WaitForElement();
      AddProductButton.Click();
    }

  }

}
