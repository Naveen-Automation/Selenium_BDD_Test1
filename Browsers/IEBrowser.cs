using OpenQA.Selenium.IE;
using Selenium_BDD_Framework.Utilities;

namespace Selenium_BDD_Framework.Browsers
{
    public class IEBrowser : BrowserBase
    {
        public override void LaunchBrowser()
        {
            driver = new InternetExplorerDriver();
        }

        public override void TakeScreenShot(string fileName)
        {
            ScreenCapture.TakeScreenShot();
        }
    }
}
