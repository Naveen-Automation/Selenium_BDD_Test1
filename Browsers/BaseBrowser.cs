using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_BDD_Framework.EnvVariables;
using Selenium_BDD_Framework.Utilities;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Selenium_BDD_Framework.Browsers
{
    public abstract class BaseBrowser
    {

        #region GETTERS AND SETTERS
        public IWebDriver Driver { get; protected set; }

        #endregion

        #region ABSTRACT METHODS
        public abstract void LaunchBrowser();
        #endregion

        #region METHODS
        public void LaunchApplication()
        {
            //string url = JsonFileReader.ReadJsonFile("AppURL");

            Driver.Navigate().GoToUrl(GlobalVariables.AppURL);

            //Implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVariables.timeOut); 
        }

        public void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
        }

        public string GetTitle()
        {
            return Driver.Title;
            //Assert.AreEqual("Google", actualTitle);}
        }


        ///<summary>
        /// Method to take screen shot of the browser 
        ///</summary>
        ///<param name="fileName">File Path of the screen shot</param>
        public void TakeScreenShot(string fileName)
        {
            Screenshot screenShot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenShot.SaveAsFile(@"C:\NAVEEN\AUTOMATION\GIT Repositories\Selenium_BDD_Test1\bin\TestResults\Sample.png", ScreenshotImageFormat.Png);
        }


        ///<summary>
        /// Method to wait till page is loaded
        ///</summary>
        ///<param name="waitForPageLoad">Boolean value which decides wheather to wait for page load or not</param>

        public void WaitForPageToLoad(bool waitForPageLoad = true)
        {
            if (waitForPageLoad)
            {
                var javaScriptExecutor = Driver as IJavaScriptExecutor;
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(GlobalVariables.TimeOut));
                bool readyCondition(IWebDriver driver) => (bool)javaScriptExecutor.ExecuteScript("return (document.readyState == 'complete')");
                wait.Until(readyCondition);
                //TODO:  Exception Handeling needs to be done
            }
        }

        #endregion 
    }
}
