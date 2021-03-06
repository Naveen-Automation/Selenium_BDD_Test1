﻿using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using OpenQA.Selenium;
using System;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables
{
    public class GlobalVariables
    {
        #region PROPERTIES FOR JENKINS
        public static string ExecutionSource { get; set; } = "JENKINS";
        public static string JenkinsPipeLineName { get; set; } = "DeclarativeSanityJob";
        public static string JenkinsLocalWorkspacePath { get; set; } = @"\.jenkins\workspace\";
        #endregion


        #region PROPERTIES WITH DEFAULT VALUES

        public static BaseBrowser Browser { get; set; } = null;
        public static IWebDriver Driver { get; set; } 
        public static string AppSettingsJsonRelativePath { get; set; } = @"Configurations\AppSettings.json";
        public static string JsonRootAttribute { get; } = "AppSettings";
        public static string UserProfileFolderPath { get; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string ProjectFolderPath { get; } = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"));
        public static int ScreenShotCounter { get; set; } = 0;
        public static string HTMLReportsPath { get; set; } = "";
        public static string ScreenShotsPath { get; set; } = "";
        
        #endregion


        #region PROPERTIES MAPPED WITH APPSETTINGS JSON 

        public static string MyStoreURL { get; set; } = JsonFileReader.ReadJsonFile("MyStoreURL");
        public static string AnyOtherStore { get; set; } = JsonFileReader.ReadJsonFile("AnyOtherStore");
        public static string BrowserType { get; } = JsonFileReader.ReadJsonFile("BrowserType");
        public static string UserName { get; set; } = JsonFileReader.ReadJsonFile("UserName");
        public static string UserEmail { get; set; } = JsonFileReader.ReadJsonFile("UserEmail");
        public static string Password { get; set; } = JsonFileReader.ReadJsonFile("Password");
        public static bool ScreenShotsFlag { get; set; } = Convert.ToBoolean(JsonFileReader.ReadJsonFile("ScreenShotsFlag"));
        public static string TestResultsRelativePath { get; set; } = JsonFileReader.ReadJsonFile("TestResultsRelativePath");
        public static string TestReportRelativePath { get; set; } = JsonFileReader.ReadJsonFile("TestReportRelativePath");
        public static bool HeadlessBrowserFlag { get; } = Convert.ToBoolean(JsonFileReader.ReadJsonFile("HeadlessBrowserFlag"));
        public static bool MaximizeBrowser { get; } = Convert.ToBoolean(JsonFileReader.ReadJsonFile("MaximizeBrowser"));
        public static int TimeOut { get; set; } = Convert.ToInt32(JsonFileReader.ReadJsonFile("TimeOut"));
        #endregion



        //public static string TestResultsFolderRelativePath { get; set; } = @"bin\TestResults\";
        //public static string TestReportRelativePath { get; set; } = @"\bin\TestResults\HTMLReports\Result.html";
    }
}
