using OpenQA.Selenium.IE;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers
{
    public class IEBrowser : BaseBrowser
    {
        public override void LaunchBrowser()
        {
            Driver = new InternetExplorerDriver();
        }
    }
}
