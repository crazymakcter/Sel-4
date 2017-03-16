using OpenQA.Selenium;
using Sel0400.Framework.Controls;
using Sel0400.Framework.Data.Catalog;

namespace Sel0400.Framework.Pages.AdminPages.Catalog
{
  public class ProductTab
  {
    private readonly IWebDriver _driver;
    protected TextBox ProductNameTextBox;
    protected TextBox ProductCodeTextBox;
    protected TextBox ProductQuantityTextBox;
    protected TextBox ProductPurchasePriceTextBox;
    protected TextBox ProductPriceUsdTextBox;

    protected WebControl ProductmanufacturerWebElement;

    protected Link GeneralTabLink;
    protected Link InformationTabLink;
    protected Link DataTabLink;
    protected Link PricesTabLink;
    protected Link OptionsTabLink;
    protected Link OptionsStockTabLink;

    protected Button SaveButton;


    public ProductTab(IWebDriver driver)
    {
      _driver = driver;
      ProductNameTextBox = new TextBox(_driver, By.CssSelector(".input-wrapper>input"));
      ProductCodeTextBox = new TextBox(_driver, By.CssSelector("#tab-general>table>tbody>tr>td>input"));
      ProductQuantityTextBox = new TextBox(_driver, By.XPath(".//*[@id='tab-general']/table/tbody/tr[8]/td/table/tbody/tr/td[1]/input"));
      ProductPurchasePriceTextBox = new TextBox(_driver, By.CssSelector(".input-wrapper>input"));
      ProductPriceUsdTextBox = new TextBox(_driver, By.CssSelector(".input-wrapper>input"));

      ProductmanufacturerWebElement = new WebControl(_driver, By.XPath(".//*[@id='tab-information']/table/tbody/tr[1]/td/select"));

      GeneralTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[1]/a"));
      InformationTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[2]/a"));
      DataTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[2]/a"));
      PricesTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[2]/a"));
      OptionsTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[2]/a"));
      OptionsStockTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[2]/a"));

      SaveButton = new Button(_driver, By.XPath(".//*[@id='content']/form/p/span/button[1]"));
    }
    /*
    public void AddProduct(Product product)
    {
      
    }
    */

  }
}
