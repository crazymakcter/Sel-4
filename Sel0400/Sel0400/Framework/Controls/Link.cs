using OpenQA.Selenium;

namespace Sel0400.Framework.Controls
{
  public class Link : WebControl
  {
    public Link(IWebDriver driver, By selector)
      : base(driver, selector)
    {
    }
  }
}
