using OpenQA.Selenium;
using Selenium_BDD_Framework.Browsers;
using SeleniumExtras.PageObjects;
using System;
using Selenium_BDD_Framework.WrapperClasses;
using Selenium_BDD_Framework.EnvVariables;

namespace Selenium_BDD_Framework.POMClassFiles
{
    class Login : ParentPOMClasses
    {


        #region CONSTRUCTOR

        public Login(BaseBrowser browser) : base(browser) { }

        #endregion


        #region WEBELEMENTS

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement FullNameTxt { get; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordTxt { get; }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement LoginBtn { get; }

        #endregion


        public override bool CheckPageLoaded()
        {
            //WebElementExtensionMethods.WaitUntillDisplayedAndEnabled(GoogleSearchTxt,GlobalVariables.Browser.Driver)
            //GoogleSearchTxt.WaitUntillDisplayedAndEnabled(Browser.Driver);
            return FullNameTxt.WaitUntillDisplayedAndEnabled(GlobalVariables.Browser.Driver);
        }


        public override void FillPageForm()
        {
            FullNameTxt.SendKeys("Veeranki Naveen");
            PasswordTxt.SendKeys(GlobalVariables.Password);
            LoginBtn.Click();
        }


        public override void MoveToNextPage()
        {
            throw new NotImplementedException();
        }
    }
}
