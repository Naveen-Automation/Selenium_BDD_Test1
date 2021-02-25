using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class Login : ParentPOMClasses
    {

        #region CONSTRUCTOR

        public Login(BaseBrowser browser) : base(browser) { }

        #endregion


        #region WEBELEMENTS

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement SignInBtn { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailTxt { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement PasswordTxt { get; set; }

        #endregion


        public override bool CheckPageLoaded()
        {
            bool isPageLoaded;
            isPageLoaded = SignInBtn.WaitUntillDisplayedAndEnabled(GlobalVariables.Browser.Driver);
            return isPageLoaded;
        }


        public override void FillPageForm(Table table)
        {
            throw new NotImplementedException();
        }

        public void EnterSignInDetials()
        {
            EmailTxt.SendKeys(GlobalVariables.UserEmail);
            PasswordTxt.SendKeys(GlobalVariables.Password);
        }


        public override void MoveToNextPage(string elementName)
        {
            elementName = StringManipulation.RemoveSpaceInBetweenTrimUpperCase(elementName);
            switch (elementName)
            {
                case "SIGNIN":
                    SignInBtn.Click();
                    break;
            }

        }
    }
}
