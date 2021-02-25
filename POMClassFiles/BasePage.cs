using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public abstract class BasePage
    {
        protected BaseBrowser Browser { get; private set;}

        #region CONSTRUCTOR
        public BasePage(BaseBrowser browser)
        {
            if (browser.Driver != null)
            {
                PageFactory.InitElements(browser.Driver, this);
            }
            Browser = browser;
        }
        #endregion

        #region ABSTRACT METHODS

        public abstract bool CheckPageLoaded();


        public abstract void FillPageForm(Table table);


        public abstract void MoveToNextPage(string elementName);
        #endregion

    }
}
