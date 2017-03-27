using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Sel0400.Framework.Constants;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Sel0400.Framework.Pages.MainPages
{
  public class HomePage
  {
    private readonly IWebDriver _driver;
      private readonly string TitleHomePage = "Online Store | My Store";
    public Checkout CheckoutPage;
    public Products ProductPage;
    public SignIn SignIn;
    public SignUp SignUp;

    public HomePage(IWebDriver driver)
    {
      _driver = driver;
      CheckoutPage = new Checkout(_driver);
      ProductPage = new Products(_driver);

    }

    public void GoTo()
    {
      _driver.Navigate().GoToUrl(Urls.HomePage);
      WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
      wait.Until(ExpectedConditions.TitleContains(TitleHomePage));
    }
  }
}
