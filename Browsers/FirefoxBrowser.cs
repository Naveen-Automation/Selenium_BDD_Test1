using OpenQA.Selenium.Firefox;
using Selenium_BDD_Framework.Utilities;

namespace Selenium_BDD_Framework.Browsers
{
    public class FirefoxBrowser : BaseBrowser
    {
        public override void LaunchBrowser()
        {
            //TODO:  Implementation pending
            Driver = new FirefoxDriver();
        }
    }
}
