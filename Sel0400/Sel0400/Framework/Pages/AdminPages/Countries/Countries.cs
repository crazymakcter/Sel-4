using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Sel0400.Framework.Controls;

namespace Sel0400.Framework.Pages.AdminPages.Countries
{
  class Countries
  {
    private readonly IWebDriver _driver;
    protected Button AddCountryButton;
    protected Link AboutProductCodeAlfa2ExternalLink;
    protected Link AboutProductCodeAlfa3ExternalLink;
    protected Link AboutProductTaxIdFormatLink;

    protected WebControl ProductsWithOutCategory;
    protected WebControl ExternalLinks;

    public Countries(IWebDriver driver)
    {
      _driver = driver;
      AddCountryButton = new Button(_driver, By.CssSelector(".button"));
      AboutProductCodeAlfa2ExternalLink = new Link(_driver, By.XPath(".//*[@id='content']/form/table[1]/tbody/tr[2]/td/a/i"));
      AboutProductCodeAlfa3ExternalLink = new Link(_driver, By.XPath(".//*[@id='content']/form/table[1]/tbody/tr[3]/td/a/i"));
      AboutProductTaxIdFormatLink = new Link(_driver, By.XPath(".//*[@id='content']/form/table[1]/tbody/tr[3]/td/a/i"));

      ExternalLinks = new WebControl(_driver, By.CssSelector(".fa.fa-external-link"));
    }

    public void ClickAddCountryButton()
    {
      AddCountryButton.WaitForElement();
      AddCountryButton.Click();
    }

    public bool ProductWithoutCategoryIsDisplayed(string productName)
    {
      ProductsWithOutCategory.WaitForElement();
      return ProductsWithOutCategory.GetElements().Any(element => element.Text == productName);
    }

    public void ClickAboutProductCodeAlfa2ExternalLink()
    {
      AboutProductCodeAlfa2ExternalLink.WaitForElement();
      AboutProductCodeAlfa2ExternalLink.Click();
    }

    public void ClickAboutProductCodeAlfa3ExternalLink()
    {
      AboutProductCodeAlfa2ExternalLink.WaitForElement();
      AboutProductCodeAlfa2ExternalLink.Click();
    }

    public IList<IWebElement> GetAllExternalLilnk()
    {
      return ExternalLinks.GetElements();
    }
  }
}
