﻿using System;

namespace Sel401
{



  public class Sel_04_01
  {
    private FirefoxDriver DriverFF()
    {
      FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\web_config", "geckodriver.exe");
      service.FirefoxBinaryPath = @"C:\Program Files (x86)\Firefox Developer Edition\firefox.exe";
      return new FirefoxDriver(service);
    }

    private static ChromeDriver DriverChrome()
    {
      return new ChromeDriver(@"C:\web_config");
    }

    private InternetExplorerDriver DriverIE()
    {
      //Edge not work =(
      //RemoteWebDriver driver = null;
      //string serverPath = @"C:\web_config\";
      //EdgeOptions options = new EdgeOptions();
      //options.PageLoadStrategy = EdgePageLoadStrategy.Eager;
      //return new EdgeDriver(serverPath, options);
      return new InternetExplorerDriver(@"C:\web_config\");
    }

    public void Select_driver()
    {
      Console.WriteLine("Please selected type of Driver: \n\t1 - Chrome \n\t2 - FireFox\n\t3 - IE");
      var typeOfDriver = Console.ReadLine();
      IWebDriver driver;
      switch (typeOfDriver)
      {
        case "1":
          driver = DriverChrome();
          break;
        case "2":
          driver = DriverFF();
          break;
        case "3":
          driver = DriverIE();
          break;
        default:
          Console.WriteLine("Please selected other");
          driver = DriverChrome();
          break;


      }
      driver.Navigate().GoToUrl("http://localhost:8082/litecart/admin/");
      driver.FindElement(By.Name("username")).SendKeys("admin");
      driver.FindElement(By.Name("password")).SendKeys("admin");
      if (typeOfDriver == "3")
      {
        driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
      }
      else
      {
        driver.FindElement(By.Name("login")).Click();
      }
      Thread.Sleep(2000);
      var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
      wait.Until(d => d.FindElement(By.ClassName("success")));

      var textAboutLogin = driver.FindElement(By.XPath("//*[@id=\"notices\"]/div[3]")).Text;
      if (textAboutLogin == "You are now logged in as admin")
        Console.WriteLine(String.Format("Check text after login: {0}", textAboutLogin));
      Thread.Sleep(5000);
      driver.Quit();

    }
  }
}
