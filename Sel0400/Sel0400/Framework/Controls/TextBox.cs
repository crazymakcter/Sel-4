using OpenQA.Selenium;

namespace Sel0400.Framework.Controls
{
  public class TextBox : WebControl
  {
    public TextBox(IWebDriver driver, By selector)
      : base(driver, selector)
    {
    }
  }
}
