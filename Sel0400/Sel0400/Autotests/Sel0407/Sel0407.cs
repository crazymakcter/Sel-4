using System;
using System.Threading;
using OpenQA.Selenium;
using Sel0400.Framework;
using Sel0400.Framework.Constants;

namespace Sel0400.Autotests.Sel0407
{
  class Sel0407
  {
    public static void Test01_Admin_OpenAllMenuAndsubmenu()
    {
      var driver = TestBase.Select_driver();
      driver.Navigate().GoToUrl(Urls.Admin);
      driver.FindElement(By.Name("username")).SendKeys("admin");
      driver.FindElement(By.Name("password")).SendKeys("admin");
      driver.FindElement(By.Name("login")).Click();
      IWebElement messageSuccessElement = driver.FindElement(By.ClassName("success"));
      Thread.Sleep(2000);
      if (!messageSuccessElement.Displayed)
      {
        driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
      }
      Thread.Sleep(2000);
      //ReadOnlyCollection<IWebElement> listMenu = driver.FindElements(By.XPath(".//*[@id='app-']/a/span[2]"));
      //ReadOnlyCollection<IWebElement> listSubMenu = driver.FindElements(By.XPath(".//*[@id='app-']/ul/li"));
      for (int i = 0; i < driver.FindElements(By.XPath(".//*[@id='app-']/a/span[2]")).Count; i++)
      {
        driver.FindElements(By.XPath(".//*[@id='app-']/a/span[2]"))[i].Click();
        Console.WriteLine("Menu {0}:", driver.FindElements(By.XPath(".//*[@id='app-']/a/span[2]"))[i]);
        for (int j = 0; j < driver.FindElements(By.XPath(".//*[@id='app-']/ul/li")).Count; j++)
        {
          driver.FindElements(By.XPath(".//*[@id='app-']/ul/li"))[j].Click();
          Console.WriteLine("Sub-menu: {0}", driver.FindElements(By.XPath(".//*[@id='app-']/ul/li"))[j].Text);
          if (driver.FindElement(By.TagName("h1")).Displayed)
          {
            Console.WriteLine("h1 tag found, text:{0}", driver.FindElement(By.TagName("h1")).Text);
          }
          else
          {
            Console.WriteLine("h1 tag not found");
          }
        }
      }
      Thread.Sleep(5000);

      TestBase.CloseDriver();
    }
  }
}
