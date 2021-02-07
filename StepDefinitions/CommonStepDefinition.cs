using OpenQA.Selenium;              //IWebdriver definition present here
using OpenQA.Selenium.Chrome;       // ChromeDriver class presence
using OpenQA.Selenium.Firefox;      // Firefox class presence
using System;
using TechTalk.SpecFlow;

namespace Selenium_BDD_Framework
{
    [Binding]
    public class CommonStepDefinition
    {
        public IWebDriver driver;

        [Given(@"I launch browser ""(.*)"" browser")]
        public void GivenILaunchBrowserBrowser(string browserType)
        {
            switch (browserType)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
            }
            driver.Navigate().GoToUrl("http://www.facebook.com");

          
        }

        [When(@"I search text ""(.*)""")]
        public void WhenISearchText()
        {
           
        }



        [Then(@"I should see selenium results")]
        public void ThenIShouldSeeSeleniumResults()
        {
            
        }

    }
}
