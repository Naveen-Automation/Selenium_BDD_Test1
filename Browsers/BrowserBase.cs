using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_BDD_Framework.EnvVariables;
using Selenium_BDD_Framework.Utilities;
using System;

namespace Selenium_BDD_Framework.Browsers
{
    public abstract class BrowserBase
    {
        public static IWebDriver driver { get; set; }
        
        public abstract void LaunchBrowser();

        public void LaunchApplication()
        {
            string url = JsonFileReader.ReadJsonFile("AppURL");
            driver.Navigate().GoToUrl(url);

            //Implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVariables.timeOut); 
        }

        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();
        }

        public string GetTitle()
        {
            return driver.Title;
            //Assert.AreEqual("Google", actualTitle);}
        }
    
            #region SCREEN SHOTS
            ///<summary>
            /// Method to take screen shot of the browser 
            ///</summary>
            ///<param name="fileName">File Path of the screen shot</param>
        public abstract void TakeScreenShot(string fileName);

        #endregion SCREEN SHOTS


        ///<summary>
        /// Method to wait till page is loaded
        ///</summary>
        ///<param name="waitForPageLoad">Boolean value which decides wheather to wait for page load or not</param>
        public void WaitForPageToLoad(bool waitForPageLoad = true)
        {
            if (waitForPageLoad)
            {
                var javaScriptExecutor = driver as IJavaScriptExecutor;
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalVariables.timeOut));
                bool readyCondition(IWebDriver driver) => (bool)javaScriptExecutor.ExecuteScript("return (document.readyState == 'complete')");
                wait.Until(readyCondition);
                //TODO:  Exception Handeling needs to be done
            }
        }

    }
}
