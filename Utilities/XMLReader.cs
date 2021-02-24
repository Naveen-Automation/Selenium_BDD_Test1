using System.Configuration;

namespace Selenium_BDD_Framework.Utilities
{
    public class XMLReader
    {
        public static string GetValue(string propName)
        {
            var url =  ConfigurationManager.AppSettings[propName];
            return url;
        }
    }
}
