using OpenQA.Selenium.IE;
using Selenium_BDD_Framework.Utilities;

namespace Selenium_BDD_Framework.Browsers
{
    public class IEBrowser : BaseBrowser
    {
        public override void LaunchBrowser()
        {
            Driver = new InternetExplorerDriver();
        }
    }
}
