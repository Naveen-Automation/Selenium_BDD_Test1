using OpenQA.Selenium;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using SeleniumExtras.PageObjects;
using System;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class Landing : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public Landing(BaseBrowser browser) : base(browser) { }

        #endregion


        #region WEBELEMENTS

        [FindsBy(How = How.XPath, Using = "//a[@title='Log in to your customer account']")]
        public IWebElement SignInLnk { get; set; }

        #endregion


        #region METHODS
        public override bool CheckPageLoaded()
        {
            bool isPageLoaded;
            isPageLoaded = SignInLnk.WaitUntillDisplayedAndEnabled(Browser.Driver);
            return isPageLoaded;
        }


        public override void FillPageForm(Table table)
        {
            throw new NotImplementedException();
        }


        public override void MoveToNextPage(string elementName)
        {
            SignInLnk.Click();
        }
        #endregion METHODS
    }
}
