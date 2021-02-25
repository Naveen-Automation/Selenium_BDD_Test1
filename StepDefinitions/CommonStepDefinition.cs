using NUnit.Framework;
using OpenQA.Selenium;              //IWebdriver definition present here
using TechTalk.SpecFlow;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles;

namespace Selenium_BDD_Framework
{
    [Binding]
    public class CommonStepDefinition
    {
        public IWebDriver driver;
        public GlobalVariables globalVariables;


        #region CONSTRUCTOR
        public CommonStepDefinition()
        {
            globalVariables = StartUp.Services.GetService<GlobalVariables>();
        }
        #endregion CONSTRUCTOR


        #region STEPS
        [When(@"I launch the browser and navigate to ""(.*)"" application")]
        public void WhenILaunchBrowserAndNavigateToApplication(string applicationName)
        {
            GlobalVariables.Browser = BrowserFactory.Launch(GlobalVariables.BrowserType);
            GlobalVariables.Browser.LaunchApplication(applicationName);
        }

        [When(@"I enter sign in details in ""(.*)"" page and click on ""(.*)"" button")]
        public void WhenIEnterSignInDetailsAndClickOnButton(string pageName, string elementName)
        {
            Login login = new Login(GlobalVariables.Browser);
            login.EnterSignInDetials();
            login.MoveToNextPage(elementName);
        }

        
        [Then(@"I should see a success message on ""(.*)"" screen")]
        public void ThenIShouldSeeMessage(string pageName)
        {
            MyPersonalInformation yourPersonalInfo = new MyPersonalInformation(GlobalVariables.Browser);
            Assert.IsTrue(yourPersonalInfo.ValidateSucessMessage());
            GlobalVariables.Browser.TakeScreenShot(pageName);

        }


        [When(@"I key the below details in ""(.*)"" screen and I click on ""(.*)"" button")]
        [When(@"I key the below details in ""(.*)"" screen and I click on ""(.*)"" Link")]
        public void WhenIKeyTheBelowDetailsInScreenAndIClickOnButton(string pageName, string elementName, Table table)
        {
            BasePage pageObject = POMHelpers.CreatePageObjectAtRunTime(pageName, GlobalVariables.Browser);
            pageObject.FillPageForm(table);
            GlobalVariables.Browser.TakeScreenShot(pageName);
            pageObject.MoveToNextPage(elementName);
        }


        [When(@"I click on ""(.*)"" link on ""(.*)"" page")]
        [When(@"I click on ""(.*)"" button on ""(.*)"" page")]
        public void WhenIClickOnButtonOnPage(string elementName, string pageName)
        {
            BasePage pageObject = POMHelpers.CreatePageObjectAtRunTime(pageName, GlobalVariables.Browser);
            pageObject.MoveToNextPage(elementName);
        }


        [Then(@"I should see ""(.*)"" page")]
        public void ThenIShouldSeeRequestedPage(string pageName)
        {
            BasePage pageObject = POMHelpers.CreatePageObjectAtRunTime(pageName, GlobalVariables.Browser);
            Assert.IsTrue(pageObject.CheckPageLoaded());
            GlobalVariables.Browser.TakeScreenShot(pageName);
        }
        #endregion STEPS
    }
}
