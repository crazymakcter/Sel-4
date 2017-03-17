using System;
using System.Collections.Generic;
using System.Linq;
using Sel0400.Framework;
using Sel0400.Framework.Pages;

namespace Sel0400.Autotests.Sel0413
{
  class Sel0413
  {
    public static void Test01_VerifyAddProductToCheckout()
    {
      Pages.Init(TestBase.Select_driver());
      Pages.HomePage.GoTo();
      Pages.HomePage.ProductPage.OpenFirstMostPopularProduct();


      Console.ReadKey();
      TestBase.CloseDriver();
    }
  }
}
