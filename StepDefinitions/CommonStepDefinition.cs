using NUnit.Framework;
using OpenQA.Selenium;              //IWebdriver definition present here
using TechTalk.SpecFlow;
using Selenium_BDD_Framework.Browsers;
using Selenium_BDD_Framework.EnvVariables;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Selenium_BDD_Framework
{
    [Binding]
    public class CommonStepDefinition
    {
        public IWebDriver driver;
        public GlobalVariables globalVariables;
       // public BaseBrowser browser;

        #region ----------------------------------CONSTRUCTOR------------------------------------------
        public CommonStepDefinition()
        {
            globalVariables = StartUp.Services.GetService<GlobalVariables>();
        }
        #endregion CONSTRUCTOR


        [Given(@"I launch browser and navigate to ""(.*)"")) application")]
        public void GivenILaunchBrowserBrowser(string applicationName)
        {
            //browser = BrowserFactory.Launch(GlobalVariables.browserType);
            GlobalVariables.Browser = BrowserFactory.Launch(GlobalVariables.BrowserType);
            GlobalVariables.Browser.LaunchApplication(applicationName);

        }

        [When(@"I search text ""(.*)""")]
        public void WhenISearchText(string searchString)
        {
           
        }



        [Then(@"I should see selenium results")]
        public void ThenIShouldSeeSeleniumResults()
        {
            
        }

    }
}
