using OpenQA.Selenium;

namespace Sel0400.Framework.Controls
{
  public class Button : WebControl
  {
    public Button(IWebDriver driver, By selector)
      : base(driver, selector)
    {
    }
  }
}
