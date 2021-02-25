using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using System;
using System.Reflection;
using OpenQA.Selenium.Interactions;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses
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


        public static void MouseOver (this IWebElement element, IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }


        public static void MouseOverAndClick(this IWebElement elementToHover, IWebElement elementToClick, IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(elementToHover).Click(elementToClick).Build().Perform();
        }



        public static void JScriptMouseOver(this IWebElement element, IWebDriver driver)
        {
            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                    "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                    "arguments[0].dispatchEvent(evObj);";

            IJavaScriptExecutor executor = GlobalVariables.Browser.Driver as IJavaScriptExecutor;
            executor.ExecuteScript(javaScript, element);
        }
    }
}
