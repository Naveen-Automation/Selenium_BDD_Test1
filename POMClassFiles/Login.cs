using OpenQA.Selenium;
using Selenium_BDD_Framework.Browsers;
using SeleniumExtras.PageObjects;
using System;

namespace Selenium_BDD_Framework.POMClassFiles
{
    class Login : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public Login(BaseBrowser browser) : base(browser) { }

        #endregion


        #region WEBELEMENTS
        [FindsBy(How = How.Id, Using = "q")]
        public IWebElement GoogleSearchTxt { get; }


        #endregion


        public override bool CheckPageLoaded()
        {

            return true;
            //return; 

        }

        public override void FillPageForm()
        {
            throw new NotImplementedException();
        }

        public override void MoveToNextPage()
        {
            throw new NotImplementedException();
        }
    }
}
