using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sel0400.Framework;
using Sel0400.Framework.Constants;
using Sel0400.Framework.Pages;

namespace Sel0400.Autotests.Sel0412
{
  class Sel0412
  {
    public static void Test01_Admin_VerifyNewProduct()
    {
      ///var driver = TestBase.Select_driver();
      //driver.Navigate().GoToUrl(Urls.Admin);
      
      Product newProduct = new Product();
      newProduct = Product.GenerateProduct();
      Console.WriteLine(newProduct.Image);
      var nameProducCategory = "Catalog";

      Pages.Init(TestBase.Select_driver());
      Pages.AdminPages.GoTo();
      Pages.AdminPages.SignInForm.SignIn("admin", "admin");

      /*
      MyWebDriver.Admin_OpenAndLogin(driver, "admin", "admin");
      MyWebDriver.Admin_OpenCategory(driver, nameProducCategory);
      MyWebDriver.AddNewProduct(driver, newProduct);
      if (MyWebDriver.Admin_CheckProductInCatalog(driver, newProduct.Name))
      {
        Console.WriteLine("Product was added");
      }
      */


      Console.ReadKey();
      TestBase.CloseDriver();
    }
  }
}
