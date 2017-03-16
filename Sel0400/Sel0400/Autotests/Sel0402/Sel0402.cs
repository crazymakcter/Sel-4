using System;
using System.Threading;
using OpenQA.Selenium;
using Sel0400.Framework;
using Sel0400.Framework.Constants;

namespace Sel0400.Autotests.Sel0402
{
  class Sel0402
  {
    public static void Test01_Admin_LoginAndVerify()
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
      var textAboutLogin = messageSuccessElement.Text;
      if (textAboutLogin == "You are now logged in as admin")
        Console.WriteLine("Check text after login: {0}", textAboutLogin);
      /*
      Pages.Init(TestBase.Select_driver());
      Pages.AdminPages.GoTo();
      Pages.AdminPages.SignInForm.SignIn("admin", "admin");
      
      * */
      Thread.Sleep(5000);

      TestBase.CloseDriver();
    }
  }
}
