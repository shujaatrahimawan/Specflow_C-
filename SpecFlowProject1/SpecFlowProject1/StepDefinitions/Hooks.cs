using System;
using TechTalk.SpecFlow;
using SpecFlowProject1.Resource;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System.IO;

namespace SpecflowProject.StepDefinitions
{
    [Binding]
    public sealed class Hooks : Core
    {
        private static string featureName { get; set; }
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        #region Step Argument Transformation
        [StepArgumentTransformation]
        public string StepTransform(string StepsParameterData)
        {
            string result = StepsParameterData;
            LocatorValueTransformation += (LocatorValueTransformation.Contains("Argument") ? "<br>" : "") + "<b>Argument :</b> [" + StepsParameterData + "]";
            
            //if (StepsParameterData.Contains("_") && !StepsParameterData.Contains(" "))
            //{
            //if (IsValidStepParameterData(StepsParameterData))
            //{
            //    result = TakeLocator(StepsParameterData);
            //    if (result.Equals(""))
            //    {
            //        result = StepsParameterData;
            //        Console.WriteLine("Locator Not Found in Page Factory Passing Same String : [{0}]", StepsParameterData);
            //    }
            //    else
            //    {
            //        LocatorName = StepsParameterData;
            //        LocatorValueTransformation += " is a <b>Locator, Value is :</b> [" + result + "] with <b>Type :</b> [" + LocatorType(result) + "]<br>";
            //    }
            //}
            return result;
        }

        #endregion


        #region Test Hooks
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun");
            driverSet = true;
            Page.TakingAllSetting();
            DefaultCounter = 0;
            LocatorValueTransformation = "";
            ReportPathGlobal = Report.ExtentReportInit();
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("AfterTestRun");
            Page.TestRunCleanUp();
            Report.ExtentReportFlush();
            Report.AutoOpenExtentReportAction();
        }
        #endregion


        #region Feature Hooks




        [BeforeFeature()]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("BeforeFeature");
            featureName = featureContext.FeatureInfo.Title;
            Report.ExtentReportFeatureAttached(featureContext.FeatureInfo.Title);
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            Console.WriteLine("AfterFeature");
        }
        #endregion


        #region Senario Hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario");
            Report.ExtentReportScenarioAttached(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("AfterScenario");
        }

        #endregion


        #region Steps Hooks

        [BeforeStep]
        public void BeforeStep()
        {
            Console.WriteLine("BeforeStep");
        }
        [AfterStep]
        public void AfterStep()
        {
            Console.WriteLine("AfterStep");
            LocatorName = "";
            DefaultCounter = 0;
            string stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            string stepInfoText = ScenarioStepContext.Current.StepInfo.Text;
            string stepDescription = LocatorValueTransformation;
            string[] specialCharacter = { "#", "<", ">", "$", "+", "%", "!", "`", "&", "*", "'", "|", "{", "?", "\"", "=", "}", "/", ":", "\\", "@" };
            string featureNam = NormalizedString(featureName, false, false, 250, specialCharacter);
            string scenarioNam = NormalizedString(_scenarioContext.ScenarioInfo.Title, false, false, 250, specialCharacter);
            string stepDetail = NormalizedString("After Step" + ScenarioStepContext.Current.StepInfo.Text, false, false, 10, specialCharacter) + new Random().Next(10000);
            string imagePath = ReportPathGlobal + "\\" + featureNam + "\\" + scenarioNam +"\\";
            if (_scenarioContext.TestError == null)
            {
                if (ScreenShotCheck && PassScrennShot)
                {
                    Page.ScreenShot(imagePath, stepDetail);
                }
                Report.ExtentStepPassed(stepType, stepInfoText, stepDescription, imagePath + stepDetail + ".jpeg");
            }
            else if (_scenarioContext.TestError != null)
            {
                if (ScreenShotCheck && FailScrennShot)
                {
                    Page.ScreenShot(imagePath, stepDetail);
                }
                Report.ExtentStepFailed(stepType, stepInfoText, stepDescription, _scenarioContext.TestError.Message, imagePath + stepDetail + ".jpeg");
            }
            LocatorValueTransformation = "";
        }
        #endregion

    }
}