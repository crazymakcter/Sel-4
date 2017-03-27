using System;
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
      Console.WriteLine(Pages.HeaderMenu.GetQuantityProductsInCheckout() == 1
        ? "Add Product to checkout"
        : "Cann't add product to checkout");
      Pages.HomePage.GoTo();
      Pages.HomePage.ProductPage.OpenFirstMostPopularProduct();
      Pages.HomePage.ProductPage.AddProductToCheckout();
      Pages.HeaderMenu.WaitAddProductToCheckout(2);
      Console.WriteLine(Pages.HeaderMenu.GetQuantityProductsInCheckout() == 2
        ? "Add Product to checkout"
        : "Cann't add product to checkout");
      Pages.HomePage.GoTo();
      Pages.HomePage.ProductPage.OpenFirstMostPopularProduct();
      Pages.HomePage.ProductPage.AddProductToCheckout();
      Pages.HeaderMenu.WaitAddProductToCheckout(3);
      Console.WriteLine(Pages.HeaderMenu.GetQuantityProductsInCheckout() == 3
        ? "Add Product to checkout"
        : "Cann't add product to checkout");

      Pages.HeaderMenu.OpenCheckoutPage();

      Console.WriteLine(Pages.Checkout.GetCountProductInCheckout());

      for (var i = Pages.Checkout.GetCountProductInCheckout(); i > 0; i--)
      {
        var currentProductForremove = Pages.Checkout.GetNameProductForRemove();
        Pages.Checkout.RemoveProductFromCheckout();
        Pages.Checkout.WaitAddProductToCheckout(currentProductForremove);
      }

      Console.WriteLine(Pages.Checkout.GetTextAboutEmptyCheckout() == "There are no items in your cart."
        ? "Checkout is empty"
        : "Checkout isn't empty");

      Console.ReadKey();
      TestBase.CloseDriver();
    }
  }
}
