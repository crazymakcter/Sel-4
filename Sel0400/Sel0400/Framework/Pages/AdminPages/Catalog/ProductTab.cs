using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
    protected TextBox ProductImageTextBox;

    protected WebControl ProductManufacturerWebElement;

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
      ProductPurchasePriceTextBox = new TextBox(_driver, By.XPath(".//*[@id='tab-prices']/table[1]/tbody/tr/td/input"));
      ProductPriceUsdTextBox = new TextBox(_driver, By.XPath(".//*[@id='tab-prices']/table[3]/tbody/tr[2]/td[1]/span/input"));

      ProductImageTextBox = new TextBox(_driver, By.XPath(".//*[@id='tab-general']/table/tbody/tr[9]/td/table/tbody/tr[1]/td/input"));

      ProductManufacturerWebElement = new WebControl(_driver, By.XPath(".//*[@id='tab-information']/table/tbody/tr[1]/td/select"));

      GeneralTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[1]/a"));
      InformationTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[2]/a"));
      DataTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[3]/a"));
      PricesTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[4]/a"));
      OptionsTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[5]/a"));
      OptionsStockTabLink = new Link(_driver, By.XPath(".//*[@id='content']/form/div/ul/li[6]/a"));

      SaveButton = new Button(_driver, By.XPath(".//*[@id='content']/form/p/span/button[1]"));
    }

    public void AddProduct(Product product)
    {
      ProductNameTextBox.WaitForElement();
      ProductNameTextBox.SendKeys(product.Name);
      ProductCodeTextBox.SendKeys(product.Code);
      ProductImageTextBox.SendKeys(product.Image);
      ProductQuantityTextBox.SendKeys(product.Quantity.ToString());
      //change tab
      InformationTabLink.Click();
      SetProductManufacturer(product.Manufacturer);
      //change tab
      PricesTabLink.Click();
      ProductPurchasePriceTextBox.SendKeys(product.PurchasePrice.ToString());
      ProductPriceUsdTextBox.SendKeys(product.PriceUSD.ToString());
      SaveButton.Click();
    }

    public void SetProductManufacturer(string value)
    {
      ProductManufacturerWebElement.WaitForElement();
      SelectElement manufacturer = new SelectElement(ProductManufacturerWebElement.GetElement());
      manufacturer.SelectByText(value);
    }

  }
}
