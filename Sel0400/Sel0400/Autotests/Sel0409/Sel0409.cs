using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sel0400.Framework;
using Sel0400.Framework.Constants;

namespace Sel0400.Autotests.Sel0409
{
  class Sel0409
  {
    public static void Test01_VerifyDefaultSortCountry()
    {
      var driver = TestBase.Select_driver();
      driver.Navigate().GoToUrl(Urls.Admin);
      driver.FindElement(By.Name("username")).SendKeys("admin");
      driver.FindElement(By.Name("password")).SendKeys("admin");
      driver.FindElement(By.Name("login")).Click();
      IWebElement messageSuccessElement = driver.FindElement(By.ClassName("success"));
      Thread.Sleep(2000);
      if (!messageSuccessElement.Displayed)
      {
        driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
      }
      Thread.Sleep(2000);

      //next lvl-update FrameWork
      /*
      Pages.Init(TestBase.Select_driver());
      Pages.AdminPages.GoTo();
      Pages.AdminPages.SignInForm.SignIn("admin", "admin");
      */
      Console.WriteLine("Verify sort Counrties and GeoZone");
      Console.WriteLine("------Verify sort Counrties-------");
      //Open "Countries"
      for (int i = 0; i < driver.FindElements(By.XPath(".//*[@id='app-']/a/span[2]")).Count; i++)
      {
        if (driver.FindElements(By.XPath(".//*[@id='app-']/a/span[2]"))[i].Text == "Countries")

          driver.FindElements(By.XPath(".//*[@id='app-']/a/span[2]"))[i].Click();
      }

      //Get all Countries
      List<String> listCountry = new List<string>();
      var countryCount = driver.FindElements(By.ClassName("row")).Count;
      for (var count = 2; count < countryCount + 2; count++)
      {
        var xpathCountry = String.Format(".//*[@id='content']/form/table/tbody/tr[{0}]/td[5]/a", count);
        var xpathZone = String.Format(".//*[@id='content']/form/table/tbody/tr[{0}]/td[6]", count);

        listCountry.Add(driver.FindElement(By.XPath(xpathCountry)).Text);
        //Check Zone
        int zoneCountForCountry = 0;
        int.TryParse(driver.FindElement(By.XPath(xpathZone)).Text, out zoneCountForCountry);
        if (zoneCountForCountry != 0)
        {
          //Open country with Zone > 0
          Console.WriteLine("Country: {0}", driver.FindElement(By.XPath(xpathCountry)).Text);
          driver.FindElement(By.XPath(xpathCountry)).Click();
          List<String> listZone = new List<string>();
          for (var zoneCount = 2 ;zoneCount < zoneCountForCountry +2; zoneCount++)
          {
            var xpath = String.Format(".//*[@id='table-zones']/tbody/tr[{0}]/td[3]", zoneCount);
            listZone.Add(driver.FindElement(By.XPath(xpath)).Text);
          }
          var listZoneWithSort = listZone;
          listZoneWithSort.Sort();
          Console.WriteLine(listZone.Except(listZoneWithSort).ToList().Count > 0
            ? "\tZones: Sort is wrong"
            : "\tZones: Sort is correct");
          driver.Navigate().Back();
        }
        
      }
      var listCountryWithSort = listCountry;
      listCountryWithSort.Sort();
      var result = listCountry.Except(listCountryWithSort).ToList();
      if (result.Count != 0)
      {
        Console.WriteLine("Countries: Sort is wrong");
        foreach (var country in result)
        {
          Console.WriteLine(country);
        }
      }
      else
      {
        Console.WriteLine("Countries: Sort is correct");
      }

      Console.WriteLine("-----Verify sort GeoZone-----");
      //Open menu "Geo Zones"
      for (int i = 0; i < driver.FindElements(By.XPath(".//*[@id='app-']/a/span[2]")).Count; i++)
      {
        if (driver.FindElements(By.XPath(".//*[@id='app-']/a/span[2]"))[i].Text == "Geo Zones")
          driver.FindElements(By.XPath(".//*[@id='app-']/a/span[2]"))[i].Click();
      }

      //Get Name Country
      var countryZoneCount = driver.FindElements(By.ClassName("row")).Count;
      for (var count = 2; count < countryZoneCount + 2; count++)
      {
        var xpathCountry = String.Format(".//*[@id='content']/form/table/tbody/tr[{0}]/td[3]/a", count);
        var xpathZone = String.Format(".//*[@id='content']/form/table/tbody/tr[{0}]/td[4]", count);
        //Check Zone
        int zoneCountForCountry = 0;
        int.TryParse(driver.FindElement(By.XPath(xpathZone)).Text, out zoneCountForCountry);
        if (zoneCountForCountry != 0)
        {
          //Open country with Zone > 0
          Console.WriteLine("Country: {0}", driver.FindElement(By.XPath(xpathCountry)).Text);
          driver.FindElement(By.XPath(xpathCountry)).Click();
          List<String> listZone = new List<string>();
          for (var zoneCount = 2; zoneCount < zoneCountForCountry + 2; zoneCount++)
          {
            var xpath = String.Format(".//*[@id='table-zones']/tbody/tr[{0}]/td[3]/select", zoneCount);
            SelectElement selectedValue = new SelectElement(driver.FindElement(By.XPath(xpath)));
            listZone.Add(selectedValue.SelectedOption.Text);
          }
          var listZoneWithSort = listZone;
          listZoneWithSort.Sort();
          Console.WriteLine(listZone.Except(listZoneWithSort).ToList().Count > 0
            ? "\tZones: Sort is wrong"
            : "\tZones: Sort is correct");
          driver.Navigate().Back();
        }

      }



      Console.ReadKey();

      TestBase.CloseDriver();

      
    }
  }
}
