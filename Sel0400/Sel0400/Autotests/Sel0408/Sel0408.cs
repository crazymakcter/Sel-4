using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using Sel0400.Framework;
using Sel0400.Framework.Constants;

namespace Sel0400.Autotests.Sel0408
{
  class Sel0408
  {
    public static void Test01_HomePage_VerifyLabelOnProduc()
    {
      var driver = TestBase.Select_driver();
      driver.Navigate().GoToUrl(Urls.HomePage);
      IList<IWebElement> listProducts = driver.FindElements(By.CssSelector(".product.column.shadow.hover-light"));
      for (int i = 0; i < listProducts.Count; i++)
      {

        try
        {
          if (listProducts[i].FindElement(By.CssSelector(".sticker")).Displayed)
          {
            if (listProducts[i].FindElements(By.CssSelector(".sticker")).Count > 1)
            {
              Console.WriteLine("{0} - have more than 1 sticker",
                  listProducts[i].Text);
            }
            else
            {
              Console.WriteLine("{0} - have sticker {1}",
                  listProducts[i].Text,
                  listProducts[i].FindElement(By.CssSelector(".sticker")).Text);
            }
          }
        }
        catch
        {
          Console.WriteLine("{0} - not have sticker",
              listProducts[i].Text);
        }
      }

      Console.ReadKey();
      driver.Quit();
    }
  }
}
