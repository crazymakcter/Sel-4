using System;
using Sel0400.Framework;
using Sel0400.Framework.Pages;

namespace Sel0400.Autotests.Sel0417
{
  class Sel0417
  {
    public static void Test01_VerifyOpenLinkInNewtab()
    {
      Pages.Init(TestBase.Select_driver());
      Pages.AdminPages.GoTo();
      Pages.AdminPages.SignInForm.SignIn("admin", "admin");
      Pages.AdminPages.GoToMenuCatalog();

      VerifyAllproductPageOnErrorInLog();

      Console.ReadKey();
      TestBase.CloseDriver();
    }

    public static void VerifyAllproductPageOnErrorInLog()
    {
      Pages.AdminPages.Catalog.OpenRubberDuckCategory();
      Pages.AdminPages.Catalog.OpenSubCategory();
      for(var i = 2; i < Pages.AdminPages.Catalog.GetAllProductEditLinks().Count; i++)
      {
        Console.WriteLine(Pages.AdminPages.GetCurrentUrl());
        Pages.AdminPages.Catalog.GetAllProductEditLinks()[i].Click();
        Pages.AdminPages.PrintLog();
        Pages.AdminPages.ManageBack();
      }
    }
  }
}
