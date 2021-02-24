using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Selenium_BDD_Framework.EnvVariables;
using Selenium_BDD_Framework.Browsers;
using Selenium_BDD_Framework.Logs;

//Snippet to compiler to go and check for app.config file for log4net section
[assembly: log4net.Config.XmlConfigurator(Watch =true)]


namespace Selenium_BDD_Framework
{
    [Binding]
    public class StartUp
    {
        public static IServiceProvider Services { get; set; }
        private static readonly log4net.ILog log = LogHelper.GetLogger();//log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [BeforeTestRun]
        public static void Initialise()
        {
            // log4net.Config.XmlConfigurator.Configure();
            var services = new ServiceCollection();
            var globalVariables = Configure(services);
            Services = services.BuildServiceProvider();
        }

        private static GlobalVariables Configure(IServiceCollection services)
        {
            //Static Variables
            GlobalVariables globalVariables;

            var configBuilder = new ConfigurationBuilder().SetBasePath(GlobalVariables.ProjectFolderPath).AddJsonFile(GlobalVariables.AppSettingsJsonRelativePath).Build();
            globalVariables = new GlobalVariables();
            configBuilder.Bind("AppSettings", globalVariables);
            services.AddSingleton(globalVariables);
            return globalVariables;
        }

        [AfterTestRun]
        public static void Terminate()
        {

        }


        [AfterScenario]
        public static void CleanUp()
        {
            
            GlobalVariables.Browser.CloseBrowser();
        }



    }
}
