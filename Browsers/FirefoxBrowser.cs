using OpenQA.Selenium.Firefox;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers
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
