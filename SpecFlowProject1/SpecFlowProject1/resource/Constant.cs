using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using LivingDoc.Dtos;
using OpenQA.Selenium;
using SpecFlowProject1.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Resource
{
    public class Constants
    {
        public static CoreUtilities CoreUtilities
        {
            get
            {
                if (core_utilities == null)
                {
                    core_utilities = new CoreUtilities();
                }

                return core_utilities;
            }
            set
            {
                core_utilities = value;
            }
        }
        private static CoreUtilities core_utilities;
        public static Core Page
        {
            get
            {
                if (core == null)
                {
                    core = new Core();
                }

                return core;
            }
            set
            {
                core = value;
            }
        }
        private static Core core;
        public static POM POM
        {
            get
            {
                if (pom == null)
                {
                    pom = new POM();
                }

                return pom;
            }
            set
            {
                pom = value;
            }
        }

        private static POM pom;


        public static Report Report
        {
            get
            {
                if (report == null)
                {
                    report = new Report();
                }

                return report;
            }
            set
            {
                report = value;
            }
        }
        private static Report report;


        public static ExtentSparkReporter HtmlReporter { get; set; }
        public static ExtentReports ExtentReport { get; set; }
        public static ExtentTest FeatureName { get; set; }
        public static ExtentTest Scenario { get; set; }

        public static IWebDriver driver { get; set; }
        public static string ChromeDriverPath { get; set; }
        public static string FireFoxDriverPath { get; set; }
        public static string EdgeDriverPath { get; set; }
        public static string PageFactoryXMLPath { get; set; }
        public static string ExtentReportPath { get; set; }
        public static string ExecutionBrowser { get; set; }
        public static string LocatorName { get; set; }
        public static bool CommandCleanUp { get; set; }
        public static bool CleanUp { get; set; }
        public static bool ExceptionIsOn { get; set; }
        public static bool LogIsOn { get; set; }
        public static bool LocatorDebugON { get; set; }
        public static int RetryAttempt { get; set; }
        public static int DefaultCounter { get; set; }
        public static string ActualMsg { get; set; }
        public static bool ExtentReportOn { get; set; }
        public static bool ExtentReportDarkTheme { get; set; }
        public static bool AutoOpenExtentReport { get; set; }
        public static bool ScreenShotCheck { get; set; }
        public static bool PassScrennShot { get; set; }
        public static bool FailScrennShot { get; set; }
        public static bool driverSet { get; set; }
        public static string AutoOpenExtentReportPath { get; set; }
        public static string LocatorValueTransformation { get; set; }
        public static string ReportPathGlobal { get; set; }
        public static string BaseURL { get; set; }



    }

}
