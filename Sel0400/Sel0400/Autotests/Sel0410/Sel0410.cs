using System;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using Sel0400.Framework;
using Sel0400.Framework.Constants;

namespace Sel0400.Autotests.Sel0410
{
  class Sel0410
  {
    public static void Test01_VerifyProductAfterAddToCart()
    {
      var driver = TestBase.Select_driver();
      driver.Navigate().GoToUrl(Urls.HomePage);

      //Home page
      var product = driver.FindElement(By.XPath(".//*[@id='box-campaigns']/div/ul/li/a[1]"));
      var productRegPriceElement = product.FindElement(By.CssSelector(".regular-price"));
      var productCampaignPriceElement = product.FindElement(By.CssSelector(".campaign-price"));
      var duck = new Product
      {
        PoductName = product.FindElement(By.CssSelector(".name")).Text,
        RegPrice = productRegPriceElement.Text,
        CurrentPrice = productCampaignPriceElement.Text
      };

      Console.WriteLine("Product Name - {0}", duck.PoductName);
      Console.WriteLine("RegPrice: {0}", duck.RegPrice);
      Console.WriteLine("CampaignPrice: {0}", duck.CurrentPrice);

      var colorRegPrice = productRegPriceElement.GetCssValue("color");
      try
      {
        productRegPriceElement.FindElement(By.TagName("strong"));
      }
      catch
      {
        Console.WriteLine("RegPrice not have tag 'strong'");
      }
      string size = productRegPriceElement.GetCssValue("font-size").Split('p')[0];
      float sizeTextRegPrice = float.Parse(size, NumberStyles.Any, CultureInfo.InvariantCulture);
      //float sizeTextRegPrice = float.Parse(productRegPriceElement.GetCssValue("font-size").Split('p')[0]);
      Console.WriteLine("CssColor for RegPrice: " + colorRegPrice);




      var colorCampaignPrice = productCampaignPriceElement.GetCssValue("color");
      float sizeTextCampaignPrice = float.Parse(size, NumberStyles.Any, CultureInfo.InvariantCulture);
      //float sizeTextCampaignPrice = float.Parse(productCampaignPriceElement.GetCssValue("font-size").Split('p')[0]);
      Console.WriteLine("CssColor for CampaingPrice: " + colorCampaignPrice);
      if (sizeTextCampaignPrice >= sizeTextRegPrice)
      {
        Console.WriteLine();
      }

      if (sizeTextRegPrice >= sizeTextCampaignPrice)
      {
        Console.WriteLine("sizeTextRegPrice >= sizeTextCampaignPrice");
      }

      //Open Prodcut page
      product.Click();
      Thread.Sleep(3000);
      //driver.SwitchTo().Window(driver.WindowHandles[1]);
      var currentName = driver.FindElement(By.XPath(".//*[@id='box-product']/div[1]/h1")).Text;
      if (duck.PoductName != currentName)
      {
        Console.WriteLine("Not same name. \nFrom homepage {0}, \nFrom product page {1}", duck.PoductName, currentName);
      }

      productRegPriceElement = driver.FindElement(By.CssSelector(".regular-price"));
      productCampaignPriceElement = driver.FindElement(By.CssSelector(".campaign-price"));

      var currentRegPrice = productRegPriceElement.Text;
      if (duck.RegPrice != currentRegPrice)
      {
        Console.WriteLine("Not same regular price. \nFrom homepage {0}, \nFrom product page {1}", duck.RegPrice, currentRegPrice);
      }
      var colorRegPriceFromProductPage = productRegPriceElement.GetCssValue("color");
      if (colorRegPrice != colorRegPriceFromProductPage)
      {
        Console.WriteLine("RegularPrice - not same color. \nFrom homepage {0}, \nFrom product page {1}",
            colorRegPrice,
            colorRegPriceFromProductPage);
      }
      var currentPrice = productCampaignPriceElement.Text;
      if (duck.CurrentPrice != currentPrice)
      {
        Console.WriteLine("Not same current price. \nFrom homepage {0}, \nFrom product page {1}",
            duck.CurrentPrice,
            currentPrice);
      }
      var colorCampaignPriceFromProductPage = productCampaignPriceElement.GetCssValue("color");
      if (colorCampaignPrice != colorCampaignPriceFromProductPage)
      {
        Console.WriteLine("CampaignPrice - not same color. \nFrom homepage {0}, \nFrom product page {1}",
            colorCampaignPrice,
            colorCampaignPriceFromProductPage);
      }

      sizeTextRegPrice = float.Parse(productRegPriceElement.GetCssValue("font-size").Split('p')[0]);
      sizeTextCampaignPrice = float.Parse(productCampaignPriceElement.GetCssValue("font-size").Split('p')[0]);
      if (sizeTextRegPrice >= sizeTextCampaignPrice)
      {
        Console.WriteLine("sizeTextRegPrice >= sizeTextCampaignPrice");
      }



      Thread.Sleep(2000);
      Console.ReadKey();

      TestBase.CloseDriver();


    }
  }
}
