using OpenQA.Selenium;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using SeleniumExtras.PageObjects;
using System;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class Home : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public Home(BaseBrowser browser) : base(browser) { }

        #endregion



        #region WEBELEMENTS

        //TODO:  Loged In User can be passed as a variable instead of Hard coded Value
        [FindsBy(How = How.XPath, Using = "//span[text()='Veeranki Naveen Goud']")]
        public IWebElement LogedInUserLbl { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//a[@title='Log me out']")]
        public IWebElement SingnOutLnk { get; set; }

                                           //a[@title="Blouses"]//parent::li//preceding-sibling::li//a[@title="T-shirts"]
        [FindsBy(How = How.XPath, Using = "//a[@title='Blouses']//parent::li//preceding-sibling::li//a[@title='T-shirts']")]
        public IWebElement TShirtLnk { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[text()='My personal information']")]
        public IWebElement MyPersonalInfoLnk { get; set; }


        #endregion

        public override bool CheckPageLoaded()
        {
            bool isPageLoaded;
            isPageLoaded = SingnOutLnk.WaitUntillDisplayedAndEnabled(GlobalVariables.Browser.Driver);
            return isPageLoaded;
            
        }

        public override void FillPageForm(Table table)
        {
            throw new NotImplementedException();
        }

        public override void MoveToNextPage(string elementName)
        {

            elementName = StringManipulation.RemoveSpaceInBetweenTrimUpperCase(elementName);
            switch (elementName)
            {
                case "TSHIRTS":
                    //TShirtLnk.Click();
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.Driver;
                    executor.ExecuteScript("arguments[0].click();", TShirtLnk);
                    break;
                case "MYPERSONALINFORMATION":
                    MyPersonalInfoLnk.Click();
                    break;
            }
            
            
        }
    }
}
