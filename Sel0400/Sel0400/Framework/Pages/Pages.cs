using OpenQA.Selenium;
using Sel0400.Framework.Pages.AdminPages;

namespace Sel0400.Framework.Pages
{
  class Pages
  {
    private static IWebDriver _driver;
    public static AdminPage AdminPages;

    public static void Init(IWebDriver webDriver)
    {
      _driver = webDriver;
      AdminPages = new AdminPage(_driver);
    }
  }

   
}
