using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Logs
{
    public class LogHelper
    {
        public static log4net.ILog GetLogger([CallerFilePath] string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
