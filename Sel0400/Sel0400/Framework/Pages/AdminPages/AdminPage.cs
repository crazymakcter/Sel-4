using OpenQA.Selenium;
using Sel0400.Framework.Constants;
using Sel0400.Framework.Pages.AdminPages.SignIn;

namespace Sel0400.Framework.Pages.AdminPages
{
  class AdminPage
  {
    private readonly IWebDriver _driver;
    public AdminLogin SignInForm;

    public AdminPage(IWebDriver driver)
    {
      _driver = driver;
      SignInForm = new AdminLogin(_driver);
    }

    public void GoTo()
    {
      _driver.Navigate().GoToUrl(Urls.Admin);
    }
  }
}
