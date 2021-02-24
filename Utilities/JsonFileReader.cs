using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Selenium_BDD_Framework.EnvVariables;
using System.IO;

namespace Selenium_BDD_Framework.Utilities
{
    class JsonFileReader
    {
        public static string ReadJsonFile(string keyName)
        {
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText($"{GlobalVariables.ProjectFolderPath}{GlobalVariables.AppSettingsJsonRelativePath}"));
            //Console.WriteLine(jsonFile[GlobalVariables.jsonRootAttribute][keyName]);
            JToken appURL = jsonFile.SelectToken($"{GlobalVariables.JsonRootAttribute}.{keyName}");
            return (string)appURL;
        }
    }
}
