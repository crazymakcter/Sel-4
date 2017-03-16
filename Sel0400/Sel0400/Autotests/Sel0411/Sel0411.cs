using System;
using System.Security.Cryptography;
using System.Threading;
using OpenQA.Selenium;
using Sel0400.Framework;
using Sel0400.Framework.Constants;


namespace Sel0400.Autotests.Sel0411
{
  class Sel0411
  {
    public static void Test01_VerifiregistartionAndReloginNewUser()
    {
      UserData newUser = new UserData
      {
        LastName = UserData.GenerateText(10),
        FirstName = UserData.GenerateText(10),
        Adres = UserData.GenerateText(20),
        PosCode = UserData.GenerateNumber(5),
        Country = "United States",
        City = UserData.GenerateText(10),
        Email = UserData.GenerateText(8) + "@mail.ru",
        Mobile = UserData.GenerateNumber(8),
        Pass = "Qwerty123!"
      };

      var driver = TestBase.Select_driver();
      driver.Navigate().GoToUrl(Urls.HomePage);
      driver.FindElement(By.CssSelector(".content>form>table>tbody>tr>td>a")).Click();
      Thread.Sleep(1000);
      driver.FindElement(By.Name("firstname")).SendKeys(newUser.FirstName);
      driver.FindElement(By.Name("lastname")).SendKeys(newUser.LastName);
      driver.FindElement(By.Name("address1")).SendKeys(newUser.Adres);
      driver.FindElement(By.Name("postcode")).SendKeys(newUser.PosCode);
      driver.FindElement(By.Name("city")).SendKeys(newUser.City);
      driver.FindElement(By.ClassName("select2-selection__rendered")).Click();
      driver.FindElement(By.ClassName("select2-search__field")).SendKeys(newUser.Country + "\n");
      driver.FindElement(By.Name("email")).SendKeys(newUser.Email);
      driver.FindElement(By.Name("phone")).SendKeys("+380" + newUser.Mobile);
      driver.FindElement(By.Name("password")).SendKeys(newUser.Pass);
      driver.FindElement(By.Name("confirmed_password")).SendKeys(newUser.Pass);
      driver.FindElement(By.Name("create_account")).Click();

      //wait
      for (var time = 0; time < 60; time++)
      {
        try
        {
          if (driver.FindElement(By.CssSelector(".notice.success")).Displayed)
          {
            if (driver.FindElement(By.CssSelector(".notice.success")).Text ==
                "Your customer account has been created.")
            {
              Console.WriteLine("User is SignUp");
              break;
            }
            else
            {
              Console.WriteLine("Something went wrong, the message is not right!!!");
              break;
            }
          }
        }
        catch (Exception)
        {
          // ignored
        }
        Thread.Sleep(1000);
      }

      

      //driver.FindElement(By.CssSelector("#box-account > div > ul > li:nth-child(4) > a")).Click();
      driver.FindElement(By.LinkText("Logout")).Click();
      Thread.Sleep(1000);
      for (var time = 0; time < 60; time++)
      {
        try
        {
          if (driver.FindElement(By.CssSelector(".notice.success")).Displayed)
          {
            {
              if (driver.FindElement(By.CssSelector(".notice.success")).Text == "You are now logged out.")
              {
                Console.WriteLine("User is Logout");
                break;
              }
              else
              {
                Console.WriteLine("Something went wrong, the message is not right!!!");
                break;
              }
            }
          }
        }
        catch
          (Exception)
        {
          // ignored
        }
        Thread.Sleep(1000);
      }

      driver.FindElement(By.Name("email")).SendKeys(newUser.Email);
      driver.FindElement(By.Name("password")).SendKeys(newUser.Pass);
      driver.FindElement(By.Name("login")).Click();
      Thread.Sleep(1000);
       for (var time = 0; time < 60; time++)
      {
        try
        {
          if (driver.FindElement(By.CssSelector(".notice.success")).Displayed)
          {
            if (driver.FindElement(By.CssSelector(".notice.success")).Text ==
                String.Format("You are now logged in as {0} {1}.", newUser.FirstName, newUser.LastName))
            {
              Console.WriteLine("User is SignIn");
              break;
            }
            else
            {
              Console.WriteLine("Something went wrong, the message is not right!!!");
              break;
            }
          }
        }
        catch
          (Exception)
        {
          // ignored
        }
        Thread.Sleep(1000);
      }


      Console.ReadKey();
      driver.Quit();
    }
  }
}
