using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Sel0400.Framework.Controls
{
  public class WebControl
  {
    protected readonly IWebDriver _driver;
    protected readonly By _selector;
    protected Lazy<IList<IWebElement>> WebElements;
    protected Lazy<IWebElement> WebElement;

    public WebControl(IWebDriver driver, By selector)
    {
      _driver = driver;
      _selector = selector;
      UpdateWebElement();
    }

    public void UpdateWebElement()
    {
      WebElement = new Lazy<IWebElement>(() => _driver.FindElement(_selector));
      WebElements = new Lazy<IList<IWebElement>>(() => _driver.FindElements(_selector));
    }

    public By GetSelector()
    {
      return _selector;
    }

    public IWebElement GetElement()
    {
      UpdateWebElement();
      return WebElement.Value;
    }

    public IList<IWebElement> GetElements()
    {
      UpdateWebElement();
      return WebElements.Value;
    }

    public void Click()
    {
      UpdateWebElement();
      WebElement.Value.Click();
      Thread.Sleep(500);
    }

    public string GetText()
    {
      UpdateWebElement();
      return WebElement.Value.Text;
    }

    public void SendKeys(string text, bool clearInputBefore = true)
    {
      if (WebElement.IsValueCreated) UpdateWebElement();
      if (clearInputBefore)
        WebElement.Value.Clear();
      Thread.Sleep(100);
      WebElement.Value.SendKeys(text);
      Thread.Sleep(100);
    }

    public void PressEnter()
    {
      UpdateWebElement();
      Thread.Sleep(200);
      WebElement.Value.SendKeys("\n");
    }

    public void WaitForElement(int time = 10)
    {
      UpdateWebElement();
      var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, time));
      wait.Until(drv => WebElement);
      Thread.Sleep(500);
    }

    public bool ElementDisplayed()
    {
      try
      {
        UpdateWebElement();
        return WebElement.Value.Displayed;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public string GetAttribute(string attributeName)
    {
      UpdateWebElement();
      return WebElement.Value.GetAttribute(attributeName);
    }

    public void Clear()
    {
      UpdateWebElement();
      WebElement.Value.Clear();
    }
  }
}
