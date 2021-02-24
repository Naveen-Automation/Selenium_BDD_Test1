using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using Selenium_BDD_Framework.Browsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_BDD_Framework.POMClassFiles
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
        }
        #endregion

        #region ABSTRACT METHODS

        public abstract bool CheckPageLoaded();


        public abstract void FillPageForm();


        public abstract void MoveToNextPage();
        #endregion
    }
}
