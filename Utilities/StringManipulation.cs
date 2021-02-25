using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Drawing;
using OpenQA.Selenium;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities
{

    public class StringManipulation
    {
        public static string RemoveSpaceInBetweenTrimUpperCase(string text)
        {
            text = text.Replace(" ", string.Empty);
            return text.Trim().ToUpper();
        }
    }
}
