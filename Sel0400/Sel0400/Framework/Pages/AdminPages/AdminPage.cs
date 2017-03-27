using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Sel0400.Framework.Constants;
using Sel0400.Framework.Controls;
using Sel0400.Framework.Pages.AdminPages.SignIn;
using Sel0400.Framework.Pages.AdminPages.Catalog;

namespace Sel0400.Framework.Pages.AdminPages
{
  class AdminPage
  {
    private readonly IWebDriver _driver;
    public AdminLogin SignInForm;
    public Catalog.Catalog Catalog;
    public Countries.Countries Countries;
    public ProductTab ProductTab;

    private readonly WebControl MenuElements;
    private WebControl SubMenuElements;

    public AdminPage(IWebDriver driver)
    {
      _driver = driver;
      SignInForm = new AdminLogin(_driver);
      Catalog = new Catalog.Catalog(_driver);
      Countries = new Countries.Countries(_driver);
      ProductTab = new ProductTab(_driver);
      MenuElements = new WebControl(_driver, By.XPath(".//*[@id='app-']/a/span[2]"));
      SubMenuElements = new WebControl(_driver, By.XPath(".//*[@id='app-']/ul/li"));

    }

    public void GoTo()
    {
      _driver.Navigate().GoToUrl(Urls.Admin);
    }

    public void GoToMenuCatalog()
    {
      GetMenuItem(GetAllMenuElements(), MenuAndSubMenu.MenuCatalog).Click();
    }

    public void GoToMenuCountries()
    {
      GetMenuItem(GetAllMenuElements(), MenuAndSubMenu.MenuCountries).Click();
    }

    public void GoToSubCatalog()
    {
      GetMenuItem(GetAllSubMenuElements(), MenuAndSubMenu.SubMenuCatalog).Click();
    }

    public IList<IWebElement> GetAllMenuElements()
    {
      MenuElements.WaitForElement();
      return MenuElements.GetElements();
    }

    public IList<IWebElement> GetAllSubMenuElements()
    {
      SubMenuElements.WaitForElement();
      return SubMenuElements.GetElements();
    }

    public IWebElement GetMenuItem(IList<IWebElement> listMenuItemElemets, string nameMenuItem)
    {
      return listMenuItemElemets.FirstOrDefault(t => t.Text == nameMenuItem);
    }

    public int GetCountOpenTabsInBrowser()
    {
      return _driver.WindowHandles.Count;
    }

    public void SwitchOnTab(int tabIndex)
    {
      _driver.SwitchTo().Window(_driver.WindowHandles[tabIndex]);
    }

    public void SwitchOnTab(string windowsName)
    {
      _driver.SwitchTo().Window(windowsName);
    }

    public string GetCurrentUrl()
    {
      return _driver.Url;
    }

    public void Closetab()
    {
      _driver.Close();
    }

    public void ManageBack()
    {
      _driver.Navigate().Back();
    }

    public void PrintLog()
    {
      var entries = _driver.Manage().Logs.GetLog(LogType.Browser);
      if (entries.Count > 0)
      {
        foreach (var entry in entries)
        {
          Console.WriteLine("\t{0}", entry);
        }
      }
    }
  }
  }
