using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using AventStack.ExtentReports.Model;

namespace SpecFlowProject1.Resource
{
    public class Report : CoreUtilities
    {
        public string ExtentReportInit()
        {
            string ReportPath = "";
            if (ExtentReportOn)
            {
                ReportPath = ExtentReportPath + DateTime.Now.ToString("[ dd - MMM - yyyy ] [ HH - mm - ss ]");
                if (!Directory.Exists(ReportPath))
                {
                    Directory.CreateDirectory(ReportPath);
                }
                HtmlReporter = new ExtentSparkReporter(ReportPath + "\\index.html");
                if (ExtentReportDarkTheme)
                {
                    HtmlReporter.Config.Theme = Theme.Dark;
                }

               
                ExtentReport = new ExtentReports();
                ExtentReport.AttachReporter(HtmlReporter);
                AutoOpenExtentReportPath = ReportPath + "\\index.html";
            }
            return ReportPath;
        }
        public void ExtentReportFeatureAttached(string FeatureTitle)
        {
            if (ExtentReportOn)
            {
                FeatureName = ExtentReport.CreateTest<Feature>(FeatureTitle);
            }
        }
        public void ExtentReportScenarioAttached(string ScenarioTitle)
        {
            if (ExtentReportOn)
            {
                Scenario = FeatureName.CreateNode<Scenario>(ScenarioTitle);
            }
        }
        public void ExtentReportFlush()
        {
            if (ExtentReportOn)
            {
                ExtentReport.Flush();
            }
        }
        public void ExtentStepPassed(string StepType, string StepInfoText, string StepDescription, string imagePath = "")
        {
            if (ExtentReportOn)
            {
                if (StepType == "Given")
                {
                    if (!imagePath.Equals(""))
                    {
                        Scenario.CreateNode<Given>(StepInfoText).Pass(StepDescription + "<img data-featherlight=\""+ imagePath + "\" src=\""+ imagePath + "\">");
                    }
                    else
                    {
                        Scenario.CreateNode<Given>(StepInfoText).Pass(StepDescription);
                    }
                }
                else if (StepType == "When")
                {
                    if (!imagePath.Equals(""))
                    {
                        Scenario.CreateNode<When>(StepInfoText).Pass(StepDescription + "<img data-featherlight=\"" + imagePath + "\" src=\"" + imagePath + "\">");
                    }
                    else
                    {
                        Scenario.CreateNode<When>(StepInfoText).Pass(StepDescription);
                    }
                }
                else if (StepType == "Then")
                {
                    if (!imagePath.Equals(""))
                    {
                        Scenario.CreateNode<Then>(StepInfoText).Pass(StepDescription + "<img data-featherlight=\"" + imagePath + "\" src=\"" + imagePath + "\">");
                    }
                    else
                    {
                        Scenario.CreateNode<Then>(StepInfoText).Pass(StepDescription);
                    }
                }
                else if (StepType == "And")
                {
                    if (!imagePath.Equals(""))
                    {
                        Scenario.CreateNode<And>(StepInfoText).Pass(StepDescription + "<img data-featherlight=\"" + imagePath + "\" src=\"" + imagePath + "\">");
                    }
                    else
                    {
                        Scenario.CreateNode<And>(StepInfoText).Pass(StepDescription);
                    }
                }
            }
        }
        public void ExtentStepFailed(string StepType, string StepInfoText, string StepDescription, string TestErrorMessage, string imagePath = "")
        {
            if (ExtentReportOn)
            {
                if (StepType == "Given")
                {
                    if (!imagePath.Equals(""))
                    {
                        Scenario.CreateNode<Given>(StepInfoText).Fail(StepDescription + "<br>" + "<textarea readonly=\"\" class=\"code-block maxxed\" style=\"height: 91.6px;\">"+ TestErrorMessage + "</textarea>" + "<img data-featherlight=\"" + imagePath + "\" src=\"" + imagePath + "\">");
                    }
                    else
                    {
                        Scenario.CreateNode<Given>(StepInfoText).Fail(StepDescription + "<br>" + "<textarea readonly=\"\" class=\"code-block maxxed\" style=\"height: 91.6px;\">" + TestErrorMessage + "</textarea>" );
                    }
                }
                else if (StepType == "When")
                {
                    if (!imagePath.Equals(""))
                    {
                        Scenario.CreateNode<When>(StepInfoText).Fail(StepDescription + "<br>" + "<textarea readonly=\"\" class=\"code-block maxxed\" style=\"height: 91.6px;\">" + TestErrorMessage + "</textarea>" + "<img data-featherlight=\"" + imagePath + "\" src=\"" + imagePath + "\">");
                    }
                    else
                    {
                        Scenario.CreateNode<When>(StepInfoText).Fail(StepDescription + "<br>" + "<textarea readonly=\"\" class=\"code-block maxxed\" style=\"height: 91.6px;\">" + TestErrorMessage + "</textarea>");
                    }
                }
                else if (StepType == "Then")
                {
                    if (!imagePath.Equals(""))
                    {
                        Scenario.CreateNode<Then>(StepInfoText).Fail(StepDescription + "<br>" + "<textarea readonly=\"\" class=\"code-block maxxed\" style=\"height: 91.6px;\">" + TestErrorMessage + "</textarea>" + "<img data-featherlight=\"" + imagePath + "\" src=\"" + imagePath + "\">");
                    }
                    else
                    {
                        Scenario.CreateNode<Then>(StepInfoText).Fail(StepDescription + "<br>" + "<textarea readonly=\"\" class=\"code-block maxxed\" style=\"height: 91.6px;\">" + TestErrorMessage + "</textarea>");
                    }
                }
                else if (StepType == "And")
                {
                    if (!imagePath.Equals(""))
                    {
                        Scenario.CreateNode<And>(StepInfoText).Fail(StepDescription + "<br>" + "<textarea readonly=\"\" class=\"code-block maxxed\" style=\"height: 91.6px;\">" + TestErrorMessage + "</textarea>" + "<img data-featherlight=\"" + imagePath + "\" src=\"" + imagePath + "\">");
                    }
                    else
                    {
                        Scenario.CreateNode<And>(StepInfoText).Fail(StepDescription + "<br>" + "<textarea readonly=\"\" class=\"code-block maxxed\" style=\"height: 91.6px;\">" + TestErrorMessage + "</textarea>");
                    }
                }
            }
        }
        public void AutoOpenExtentReportAction()
        {
            if (AutoOpenExtentReport)
            {
                Process.Start(@"" + AutoOpenExtentReportPath);
            }
        }
    }

}
