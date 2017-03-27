using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Sel0400.Framework
{
  class TestBase
  {
    public static string typeOfDriver;
    static IWebDriver driver;

    public static IWebDriver Select_driver()
    {
      Console.WriteLine("Please selected type of Driver: \n\t1 - Chrome \n\t2 - FireFox\n\t3 - IE");
      typeOfDriver = Console.ReadLine();
      
      switch (typeOfDriver)
      {
        case "1":
          driver = DriverChrome();
          break;
        case "2":
          driver = DriverFf();
          break;
        case "3":
          driver = DriverIe();
          break;
        default:
          Console.WriteLine("Please selected other");
          driver = DriverChrome();
          break;


      }
      return driver;
    }


    private static FirefoxDriver DriverFf()
    {
      FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\web_config", "geckodriver.exe");
      service.FirefoxBinaryPath = @"C:\Program Files (x86)\Firefox Developer Edition\firefox.exe";
      return new FirefoxDriver(service);
    }

    private static ChromeDriver DriverChrome()
    {
      ChromeOptions options = new ChromeOptions();
      options.SetLoggingPreference(LogType.Browser, LogLevel.All);
      return new ChromeDriver(@"C:\web_config", options);
    }

    private static InternetExplorerDriver DriverIe()
    {
      //Edge not work =(
      //RemoteWebDriver driver = null;
      //string serverPath = @"C:\web_config\";
      //EdgeOptions options = new EdgeOptions();
      //options.PageLoadStrategy = EdgePageLoadStrategy.Eager;
      //return new EdgeDriver(serverPath, options);
      return new InternetExplorerDriver(@"C:\web_config");
    }

    public static void CloseDriver()
    {
      driver.Quit();
      driver = null;
    }
  }
}
