using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Drawing;
using OpenQA.Selenium;

namespace Selenium_BDD_Framework.Utilities
{

    public class ScreenCapture
    {
        public static IWebDriver driver;

        public static void TakeScreenShot()
        { 
            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            screenShot.SaveAsFile(@"C:\NAVEEN\AUTOMATION\GIT Repositories\Selenium_BDD_Test1\bin\TestResults\Sample.png" , ScreenshotImageFormat.Png);
        }
    }
}
