using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers
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
        public void LaunchApplication(string applicationName)
        {
            applicationName = applicationName.Replace(" ", string.Empty);
            applicationName = applicationName.Trim().ToUpper();
            switch (applicationName)
            {
                case "MYSTORE":
                    Driver.Navigate().GoToUrl(GlobalVariables.MyStoreURL);
                    break;
                case "ANYOTHERSTORE":
                    Driver.Navigate().GoToUrl(GlobalVariables.AnyOtherStore);
                    break;
            }
            

            //Implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVariables.timeOut); 
        }


        public void ImplicitWait()
        {
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
            GlobalVariables.ScreenShotCounter = GlobalVariables.ScreenShotCounter + 1;
            Screenshot screenShot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenShot.SaveAsFile($"{GlobalVariables.ScreenShotsPath}\\{fileName}{GlobalVariables.ScreenShotCounter}.png", ScreenshotImageFormat.Png);
                   
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
