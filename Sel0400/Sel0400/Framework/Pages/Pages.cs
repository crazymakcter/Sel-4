using OpenQA.Selenium;
using Sel0400.Framework.Pages.AdminPages;
using Sel0400.Framework.Pages.MainPages;

namespace Sel0400.Framework.Pages
{
  class Pages
  {
    private static IWebDriver _driver;
    public static AdminPage AdminPages;
    public static HomePage HomePage;
    public static HeaderMenu HeaderMenu;
    public static Checkout Checkout;

    public static void Init(IWebDriver webDriver)
    {
      _driver = webDriver;
      AdminPages = new AdminPage(_driver);
      HomePage = new HomePage(_driver);
      HeaderMenu = new HeaderMenu(_driver);
      Checkout = new Checkout(_driver);
    }
  }

   
}
