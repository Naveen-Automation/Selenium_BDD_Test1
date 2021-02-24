using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_BDD_Framework.EnvVariables;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace Selenium_BDD_Framework.WrapperClasses
{
    public static class WebElementExtensionMethods
    {
        public static bool WaitUntillDisplayedAndEnabled(this IWebElement element, IWebDriver driver, bool shouldBeEnabled = true)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalVariables.TimeOut));
            return wait.Until<bool>(d =>
            {
                try
                {
                    return shouldBeEnabled ? element.Displayed && element.Enabled : element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    //TODO: Logging Error pending
                    return false;
                }
                catch (TargetInvocationException)
                {
                    //TODO: Logging Error pending
                    try
                    {
                        return shouldBeEnabled ? element.Displayed && element.Enabled : element.Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        //TODO: Logging Error pending
                        return false;
                    }
                    finally
                    {
                        //TODO: Logging the exit of the method
                    }
                }
            });
        }
    }
}
