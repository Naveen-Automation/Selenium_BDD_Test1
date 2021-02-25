using OpenQA.Selenium;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using SeleniumExtras.PageObjects;
using System;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class MyPersonalInformation : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public MyPersonalInformation(BaseBrowser browser) : base(browser) { }

        #endregion


        #region WEBELEMENTS

        [FindsBy(How = How.Id, Using = "firstname")]
        public IWebElement FirstNameTxt { get; set; }


        [FindsBy(How = How.Id, Using = "old_passwd")]
        public IWebElement CurrentPasswordTxt { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[@name='submitIdentity']")]  
        public IWebElement SaveBtn { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Your personal information has been successfully updated.')]")]
        public IWebElement SuccessMessageLbl { get; set; }

        #endregion


        #region METHODS
        public override bool CheckPageLoaded()
        {
            bool isPageLoaded;
            isPageLoaded = FirstNameTxt.WaitUntillDisplayedAndEnabled(Browser.Driver);
            return isPageLoaded;
        }


        public override void FillPageForm(Table table)
        {
            var testData = table.CreateInstance<YourPersonalInformationData>();
            FirstNameTxt.Clear();
            FirstNameTxt.SendKeys(testData.FirstName);
            CurrentPasswordTxt.SendKeys(GlobalVariables.Password);
        }

        public bool ValidateSucessMessage()
        {
            return SuccessMessageLbl.WaitUntillDisplayedAndEnabled(Browser.Driver);
        }

        public override void MoveToNextPage(string elementName)
        {
            elementName = StringManipulation.RemoveSpaceInBetweenTrimUpperCase(elementName);
            switch (elementName)
            {
                case "SAVE":
                    SaveBtn.Click();
                    break;
            }
        }
        #endregion METHODS
    }



    //Class to mapp test data passed from Specflow table to below properties
    public class YourPersonalInformationData
    {

        public string FirstName { get; set; }
    }
}
