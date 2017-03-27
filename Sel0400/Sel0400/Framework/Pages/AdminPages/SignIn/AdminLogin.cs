using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sel0400.Framework.Controls;

namespace Sel0400.Framework.Pages.AdminPages.SignIn
{
  public class AdminLogin
  {
    private readonly IWebDriver _driver;
    protected Button LoginButton;
    protected TextBox UsernameTextBox;
    protected TextBox PasswordTextBox;
    protected TextLabel MessageSuccessElement;

    public AdminLogin(IWebDriver driver)
    {
      _driver = driver;
      LoginButton = new Button(_driver, By.Name("login"));
      UsernameTextBox = new TextBox(_driver, By.Name("username"));
      PasswordTextBox = new TextBox(_driver, By.Name("password"));
      MessageSuccessElement = new TextLabel(_driver, By.ClassName("success"));
    }

    public void SignIn(string username, string password)
    {
      UsernameTextBox.SendKeys(username);
      PasswordTextBox.SendKeys(password);
      LoginButton.Click();
      var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
      wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("success")));
      if (!MessageSuccessElement.ElementDisplayed())
      {
        PasswordTextBox.SendKeys(Keys.Enter);
      }
      wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("success")));
    }

  }
}
