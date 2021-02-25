using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using System;
using System.IO;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities
{
    public class FileSystem
    {
        public static void CreateDirectory(string prefix)
        {
            if (prefix.Equals("REPORT"))
            {
                string dirName = string.Format("{0}_On_{1:ddd MM.dd.yyyy_'AT'_HH_mm_ss_tt}", prefix, DateTime.Now);
                string dirPath = GlobalVariables.ProjectFolderPath + GlobalVariables.TestResultsRelativePath + dirName;
                GlobalVariables.HTMLReportsPath = dirPath;
                Directory.CreateDirectory(dirPath);
            }
            else if(prefix.Equals("SCREEN_SHOTS"))
            {
                string dirPath = GlobalVariables.HTMLReportsPath + "\\" + prefix;
                GlobalVariables.ScreenShotsPath = dirPath;
                Directory.CreateDirectory(dirPath);
            }



        }
    }
}
