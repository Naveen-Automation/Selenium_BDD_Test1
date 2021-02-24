using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_BDD_Framework.EnvVariables;
using System;

namespace Selenium_BDD_Framework.Browsers
{
    public class ChromeBrowser : BrowserBase
    {
        public override void LaunchBrowser()
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            //Option to disable 'Chrome is being controlled by automated test software' info bar
            chromeOptions.AddExcludedArgument("enable-automation");

            //Option to disable 'Saved Passwords' dialog
            chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled" , false);
          
            // Run chrome browser in headless mode, based on the flag passed from Config.json file
            if (GlobalVariables.headlessFlag)
            {
                chromeOptions.AddArguments("headless");
            }

            //Launch chrome driver instance
            driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions, TimeSpan.FromSeconds(GlobalVariables.timeOut) );

            // Run chrome browser in headless mode, based on the flag passed from Config.json file
            if (GlobalVariables.maximizeBrowser)
            {
                driver.Manage().Window.Maximize();
            }

        }

        public override void TakeScreenShot(string fileName)
        {
            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();

            screenShot.SaveAsFile(@"C:\NAVEEN\AUTOMATION\GIT Repositories\Selenium_BDD_Test1\bin\TestResults\Sample.png", ScreenshotImageFormat.Png);

        }
    }
}
