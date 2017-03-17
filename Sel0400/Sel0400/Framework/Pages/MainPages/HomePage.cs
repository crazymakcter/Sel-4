using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Sel0400.Framework.Constants;

namespace Sel0400.Framework.Pages.MainPages
{
  public class HomePage
  {
    private readonly IWebDriver _driver;
    public Checkout CheckoutPage;
    public Products ProductPage;
    public SignIn SignIn;
    public SignUp SignUp;

    public HomePage(IWebDriver driver)
    {
      _driver = driver;
      CheckoutPage = new Checkout();
      ProductPage = new Products(_driver);

    }

    public void GoTo()
    {
      _driver.Navigate().GoToUrl(Urls.HomePage);
    }
  }
}
