using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_BDD_Framework.Browsers
{
    class BrowserFactory
    {
        public static IWebDriver driver { get; set; }
        public static BrowserBase browser { get; set; }

        public static BrowserBase Launch(string browserType)
        {
            switch (browserType.ToUpper())
            {
                case "CHROME":
                     browser = new ChromeBrowser();
                     break;
                case "FIREFOX":
                     browser = new FirefoxBrowser();
                    break;
                case "IE":
                     browser = new IEBrowser();
                    break;
            }
            browser.LaunchBrowser(); 
            return browser;
        }

    }
}
