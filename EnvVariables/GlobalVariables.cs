using Selenium_BDD_Framework.Browsers;
using System;

namespace Selenium_BDD_Framework.EnvVariables
{
    public class GlobalVariables
    {
        public static string executionSource { get; set; } = "JENKINS";
        public static string jenkinsPipeLineName { get; set; } = "DeclarativeSanityJob";
        public static string jenkinsLocalWorkspacePath { get; set; } = @"\.jenkins\workspace\";
        public static string testResultsRelativePath { get; set; } = @"\bin\TestResults\HTMLReports\Result.html";

        public static string testResultsFolderRelativePath { get; set; } = @"bin\TestResults\";
        public static string appSettingsJsonRelativePath { get; set; } = @"Configurations\AppSettings.json";
        public static string userProfileFolderPath { get;} = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static int timeOut { get; set; } = 120;
        public static bool headlessFlag { get;} = false;
        public static bool maximizeBrowser { get;} = true;
        public static string browserType { get; } = "Chrome";
        public static string jsonRootAttribute { get; } = "AppSettings";
        public static BrowserBase browser { get; set; }

        public static string projectFolderPath
        {
            get
            {
                string path = Environment.CurrentDirectory;
                path = path.Substring(0, path.IndexOf("bin"));
                return path;
            }
        }

        public static string AppURL { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string ScreenShotsFlag { get; set; }
        public static string TestResultsRelativePath { get; set; }
        public static string HeadlessBrowserFlag { get; set; }
        public static string TimeOut { get; set; }
    }
}
