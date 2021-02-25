using System.Configuration;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities
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
