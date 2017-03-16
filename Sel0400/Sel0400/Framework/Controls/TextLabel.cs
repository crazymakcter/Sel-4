using OpenQA.Selenium;

namespace Sel0400.Framework.Controls
{
  public class TextLabel : WebControl
  {

    public TextLabel(IWebDriver driver, By selector)
      : base(driver, selector)
    {
    }
  }
}

