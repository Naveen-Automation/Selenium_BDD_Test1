using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_BDD_Framework.GlobalVariables
{
    public class EnvironmentVariables
    {
        public static string _executionSource = "JENKINS";
        public static string _jenkinsPipeLineName = "DeclarativeSanityJob";
        public static string _jenkinsLocalWorkspacePath = @"\.jenkins\workspace\";
        public static string _testResultsRelativePath =  @"\bin\TestResults\HTMLReports\Result.html";
        public static string _userProfileFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string _projectFolderLocalPath = Environment.CurrentDirectory;

    }
}
