/*
    Context injection is the feature of specflow from where we can fetch the details of the Feature, Scenario & Steps
    1.  Create Object of HTMLReporter class
    2. Create Object of Extent Report
    3. Attach the object of HTMLReporter Class to Extent Report (This will start the Extent Reporter enginee and it should happen before the test execution starts)
    4. Capture the test event and pass it to Extent Report
    5. Flush/Save all the events & generate HTML report
*/

using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Selenium_BDD_Framework.Architecture;
using System;
using TechTalk.SpecFlow;

namespace Selenium_BDD_Framework.Reporting
{
    [Binding]
    public class ExtentReportingHooks : ArchitectureBaseClass
    {
        #region Class Fields
        private static FeatureContext _featureContext;
        private static ScenarioContext _scenarioContext;
        private static ExtentHtmlReporter _extentHTMLReporter;
        private static ExtentReports _reporter;

        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private static ScenarioBlock _scenarioBlock;
        #endregion Class Fields

        #region Before Test Run
        [BeforeTestRun]
        public static void StartReportingEnginee()
        {

            //Need to take out the hard code
            if (ExecutionSource == "JENKINS")
            {
                _extentHTMLReporter = new ExtentHtmlReporter(UserProfileFolderPath + JenkinsLocalWorkspacePath + JenkinsPipeLineName  + TestReportRelativePath);
            }
            else if (ExecutionSource == "LOCAL")
            {
                //_projectFolderLocalPath.Replace()
                _extentHTMLReporter = new ExtentHtmlReporter(ProjectFolderPath + TestReportRelativePath);
            }
            //Need to see why AventStack.ExtentReports.Reporter is required before configurations when we already have using statement
           // _extentHTMLReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _reporter = new ExtentReports();
            _reporter.AttachReporter(_extentHTMLReporter);

            #region Additional Details
            _reporter.AddSystemInfo("Chrome Version" , string.Empty);
            #endregion  Additional Details
        }
        #endregion Before Test Run

        #region After Test Run
        [AfterTestRun]
        public static void GenerateHTMLReport()
        {
            //Saving & Generating HTML Report
            _reporter.Flush();
        }
        #endregion After Test Run

        #region Before Feature 
        /*
         * During runtime Specflow framework will create the instance of FeatureContext & pass it in the method via dependency injection.
            Then featureContext object will have the information about the feature like its description etc
        */
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (featureContext != null)
            {
                _featureContext = featureContext;
                _feature = _reporter.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }
        #endregion Before Feature 


        #region Before Scenario 
        /* 
            During runtime Specflow framework will create the instance of ScenarioContext & pass it in the method via dependency injection.
            Then ScenarioContext object will have the information about the scenario like its name etc
            We will use CreateNode method as we are following a hierarcical structure where Scenario is a child of Feature.
        */
        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext != null)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
        }
        #endregion Before Scenario 


        #region After Every Step 
        /* 
             We will use CreateNode method as we are following a hierarcical structure where 'Given', 'When', 'Then' & 'And' are the Steps i.e child nodes of Scenario node.
        */

        [AfterStep]
        public static void AfterEachStep()
        {
            _scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            switch (_scenarioBlock)
            {
                case ScenarioBlock.Given:
                    _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                    break;
                case ScenarioBlock.When:
                    _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                    break;
                case ScenarioBlock.Then:
                    _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                    break;
                default:
                    _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                    break;
            }
        }
        #endregion After Every Step 

    }
}



