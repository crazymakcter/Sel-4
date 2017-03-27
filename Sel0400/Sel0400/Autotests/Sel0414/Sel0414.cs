using System;
using Sel0400.Framework;
using Sel0400.Framework.Pages;

namespace Sel0400.Autotests.Sel0414
{
  class Sel0414
  {
    public static void Test01_VerifyOpenLinkInNewtab()
    {
      Pages.Init(TestBase.Select_driver());
      Pages.AdminPages.GoTo();
      Pages.AdminPages.SignInForm.SignIn("admin", "admin");
      Pages.AdminPages.GoToMenuCountries();
      Pages.AdminPages.Countries.ClickAddCountryButton();
      VerifyOpenExternalLinkInNewTab();
      Console.ReadKey();
      TestBase.CloseDriver();
    }

    public static void VerifyOpenExternalLinkInNewTab()
    {
      foreach (var element in Pages.AdminPages.Countries.GetAllExternalLilnk())
      {
        var countOpenTab = Pages.AdminPages.GetCountOpenTabsInBrowser();
        element.Click();
        var currentCountOpenTab = Pages.AdminPages.GetCountOpenTabsInBrowser();
        if (countOpenTab != currentCountOpenTab)
        {
          Pages.AdminPages.SwitchOnTab(currentCountOpenTab - 1);
          Console.WriteLine(Pages.AdminPages.GetCurrentUrl());
          Pages.AdminPages.Closetab();
          Pages.AdminPages.SwitchOnTab(currentCountOpenTab - 2);
        }

      }
    }
  }
}
