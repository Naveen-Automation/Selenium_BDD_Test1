using OpenQA.Selenium.Firefox;
using Selenium_BDD_Framework.Utilities;

namespace Selenium_BDD_Framework.Browsers
{
    public class FirefoxBrowser : BrowserBase
    {
        public override void LaunchBrowser()
        {
            //TODO:  Implementation pending
            driver = new FirefoxDriver();
        }

        public override void TakeScreenShot(string fileName)
        {
            //TODO:  Implementation Pending
            ScreenCapture.TakeScreenShot();
        }
    }
}
