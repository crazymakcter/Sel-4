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
      //int QuantityProductsInCheckout = Pages.HeaderMenu.GetQuantityProductsInCheckout();
      Pages.HomePage.ProductPage.AddProductToCheckout();
      Pages.HeaderMenu.WaitAddProductToCheckout(1);
      if (Pages.HeaderMenu.GetQuantityProductsInCheckout() == 1) Console.WriteLine("Add Product to checkout");
        else Console.WriteLine("Cann't add product to checkout");
      Pages.HomePage.GoTo();
      Pages.HomePage.ProductPage.OpenFirstMostPopularProduct();
      Pages.HomePage.ProductPage.AddProductToCheckout();
      Pages.HeaderMenu.WaitAddProductToCheckout(2);
        if (Pages.HeaderMenu.GetQuantityProductsInCheckout() == 2) Console.WriteLine("Add Product to checkout");
        else Console.WriteLine("Cann't add product to checkout");
      Pages.HomePage.GoTo();
      Pages.HomePage.ProductPage.OpenFirstMostPopularProduct();
      Pages.HomePage.ProductPage.AddProductToCheckout();
      Pages.HeaderMenu.WaitAddProductToCheckout(3);
      if (Pages.HeaderMenu.GetQuantityProductsInCheckout() == 3) Console.WriteLine("Add Product to checkout");
      else Console.WriteLine("Cann't add product to checkout");

      Pages.HeaderMenu.OpenCheckoutPage();

      Console.WriteLine(Pages.Checkout.GetCountProductInCheckout());

      Console.ReadKey();
      TestBase.CloseDriver();
    }
  }
}
