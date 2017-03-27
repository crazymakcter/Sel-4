using System;
using Sel0400.Framework;
using Sel0400.Framework.Data.Catalog;
using Sel0400.Framework.Pages;

namespace Sel0400.Autotests.Sel0412
{
  class Sel0412
  {
    public static void Test01_Admin_VerifyNewProduct()
    {

      var newProduct = Product.GenerateProduct();
      Console.WriteLine(newProduct.Image);

      Pages.Init(TestBase.Select_driver());
      Pages.AdminPages.GoTo();
      Pages.AdminPages.SignInForm.SignIn("admin", "admin");
      Pages.AdminPages.GoToMenuCatalog();
      Pages.AdminPages.GoToSubCatalog();
      Pages.AdminPages.Catalog.ClickAddNewProductButton();
      Pages.AdminPages.ProductTab.AddProduct(newProduct);

      Console.WriteLine(
        Pages.AdminPages.Catalog.ProductWithoutCategoryIsDisplayed(newProduct.Name)
          ? "Product {0} was added"
          : "Something went wrong, the Product {0} is not right!!!", newProduct.Name);

      Console.ReadKey();
      TestBase.CloseDriver();
    }
    
    
  }
}
