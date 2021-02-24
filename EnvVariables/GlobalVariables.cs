using OpenQA.Selenium;
using Selenium_BDD_Framework.Browsers;
using Selenium_BDD_Framework.Utilities;
using System;

namespace Selenium_BDD_Framework.EnvVariables
{
    public class GlobalVariables
    {
        public static string ExecutionSource { get; set; } = "JENKINS";
        public static string JenkinsPipeLineName { get; set; } = "DeclarativeSanityJob";
        public static string JenkinsLocalWorkspacePath { get; set; } = @"\.jenkins\workspace\";
        public static string TestReportRelativePath { get; set; } = @"\bin\TestResults\HTMLReports\Result.html";


        public static string TestResultsFolderRelativePath { get; set; } = @"bin\TestResults\";
        public static string AppSettingsJsonRelativePath { get; set; } = @"Configurations\AppSettings.json";
        public static string UserProfileFolderPath { get;} = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string ProjectFolderPath { get; } = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"));

        public static int TimeOut { get; set; } = 120;
        public static bool HeadlessFlag { get;} = false;
        public static bool MaximizeBrowser { get;} = true;
        public static string BrowserType { get; } = "Chrome";
        public static string JsonRootAttribute { get; } = "AppSettings";
        public static BaseBrowser Browser { get; set; }
        public static IWebDriver Driver { get; } = null;
        

        #region PROPERTIES MAPPED WITH APPSETTINGS JSON  //To be used with dependency injection
        public static string AppURL { get; set; } = JsonFileReader.ReadJsonFile("AppURL");
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string TestResultsRelativePath { get; set; }
        #endregion
    }
}
