using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using TechTalk.SpecFlow;

namespace BigSmallSiteAutomation
{
    [Binding]
    public class Hooks
    {
        
        public static ExtentReports reports;
        public static ExtentTest scenario;
        public static ExtentTest feature;

        public static IWebDriver driver;

        [BeforeFeature]
        public static void FeatureBrowser(FeatureContext featureContext)
        {
            feature = reports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void InitDriver(ScenarioContext scenarioContext)
        {
            scenario = reports.CreateTest<Scenario>(scenarioContext.ScenarioInfo.Title);
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [BeforeTestRun]
        public static void GenerateReport()
        {
            var htmlReport = new ExtentHtmlReporter(@"C:\Users\mindtreefeb86\source\repos\BigSmallSiteAutomation\BigSmallSiteAutomation\report.html");
            htmlReport.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            reports = new ExtentReports();
            reports.AttachReporter(htmlReport);
        }

        [AfterTestRun]
        public static void CloseExtentReport()
        {
            reports.Flush();
        }

        [AfterStep]
        public static void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError == null)
            {
                var steptype = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                if (steptype == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                if (steptype == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                if (steptype == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                if (steptype == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }

            if (scenarioContext.TestError != null)
            {
                var steptype = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                if (steptype == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                if (steptype == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                if (steptype == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                if (steptype == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
            }
        }

        [AfterScenario]
        public void QuitDriver()
        {
            driver.Quit();
        }

    }
}
