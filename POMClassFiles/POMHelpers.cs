using Selenium_BDD_Framework.Browsers;
using System;
using System.Reflection;

namespace Selenium_BDD_Framework.POMClassFiles
{
    public static class POMHelpers
    {
        
        public static BasePage GetCurrentPageInstance { get; set; }


        public static BasePage CreatePageObjectAtRunTime(string pageName, BaseBrowser browser)
        {
            pageName = pageName.Replace(" ", string.Empty);
            pageName = pageName.Trim();
            string assemblyName = Assembly.GetExecutingAssembly().FullName.Split(',')[0];
            try
            {
                string fullQualifiedPageClassName = $"{(assemblyName)}.POMClassFiles.{pageName},{assemblyName}";
                GetCurrentPageInstance = Activator.CreateInstance(Type.GetType(fullQualifiedPageClassName), browser) as BasePage;
                
                //Throw an exception if the class we are trying to create doesnot derive from BasePage
                if (!GetCurrentPageInstance.GetType().IsSubclassOf(typeof(BasePage)))
                {
                    throw new InvalidOperationException($"Error:  POMHelpers.CreatePageObjectAtRunTime  trying to create '{pageName}', which is not a BasePage deriver Class");
                }
                return GetCurrentPageInstance;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException)
                {
                    //TODO: Log that Page name passed from the feature file is incorrect
                    throw new ArgumentNullException($"Error: '{pageName}' page name is incorrect. Mismatch of page name passed from feature file and page class file");
                }
                else 
                {
                    //TODO: Logging pending for ex.Message
                    throw;
                }
            }
        }
    }
}
