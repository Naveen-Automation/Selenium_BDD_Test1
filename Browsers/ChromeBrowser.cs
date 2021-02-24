using OpenQA.Selenium.Chrome;
using Selenium_BDD_Framework.EnvVariables;
using System;

namespace Selenium_BDD_Framework.Browsers
{
    public sealed class ChromeBrowser : BaseBrowser
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
            if (GlobalVariables.HeadlessBrowserFlag)
            {
                chromeOptions.AddArguments("headless");
            }

            //Launch chrome driver instance
            Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions, TimeSpan.FromSeconds(GlobalVariables.TimeOut) );
            //GlobalVariables.Driver = Driver;

            // Run chrome browser in headless mode, based on the flag passed from Config.json file
            if (GlobalVariables.MaximizeBrowser)
            {
                Driver.Manage().Window.Maximize();
            }
        }
    }
}
