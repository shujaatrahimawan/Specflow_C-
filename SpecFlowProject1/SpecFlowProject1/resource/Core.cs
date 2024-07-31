using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using RestSharp;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Reflection;

namespace SpecFlowProject1.Resource
{
    public class Core : CoreUtilities
    {
        public void TakingAllSetting()
        {
            string ProjectPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ChromeDriverPath = ProjectPath+"\\../../../Drivers\\";
            FireFoxDriverPath = "";
            EdgeDriverPath = "";
            ExecutionBrowser = "chrome";
            PageFactoryXMLPath = ProjectPath + "\\../../../StepDefinitions\\PageFactory.xml";
            ExtentReportPath = ProjectPath + "\\../../../Reports\\";
            BaseURL = "";
            ExtentReportOn = true;
            ExtentReportDarkTheme = true;
            AutoOpenExtentReport = true;
            CommandCleanUp = true;
            CleanUp = true;
            ExceptionIsOn = true;
            LogIsOn = true;
            LocatorDebugON = false;
            ScreenShotCheck = true;
            PassScrennShot = true;
            FailScrennShot = true;
            RetryAttempt = 0;
            Log("ChromeDriverPath:" + ChromeDriverPath);
            Log("FireFoxDriverPath:" + FireFoxDriverPath);
            Log("EdgeDriverPath:" + EdgeDriverPath);
            Log("ExecutionBrowser:" + ExecutionBrowser);
            Log("PageFactoryXMLPath:" + PageFactoryXMLPath);
            Log("ExtentReportPath:" + ExtentReportPath);
            Log("BaseURL:" + BaseURL);
            Log("ExtentReportOn:" + ExtentReportOn);
            Log("ExtentReportDarkTheme:"+ ExtentReportDarkTheme);
            Log("AutoOpenExtentReport:" + AutoOpenExtentReport);
            Log("CommandCleanUp:" + CommandCleanUp);
            Log("CleanUp:" + CleanUp);
            Log("ExceptionIsOn:" + ExceptionIsOn);
            Log("LogIsOn:" + LogIsOn);
            Log("LocatorDebugON:" + LocatorDebugON);
            Log("ScreenShotCheck:" + ScreenShotCheck);
            Log("PassScrennShot:" + PassScrennShot);
            Log("FailScrennShot:" + FailScrennShot);
            Log("RetryAttempt:" + RetryAttempt);
            //ChromeDriverPath = CoreUtilities.ConfigString("ChromeDriverPath");
            //FireFoxDriverPath = CoreUtilities.ConfigString("FireFoxDriverPath");
            //EdgeDriverPath = CoreUtilities.ConfigString("EdgeDriverPath");
            //ExecutionBrowser = CoreUtilities.ConfigString("ExecutionBrowser");
            //PageFactoryXMLPath = CoreUtilities.ConfigString("PageFactoryXMLPath");
            //ExtentReportPath = CoreUtilities.ConfigString("ExtentReportPath");
            //BaseURL = CoreUtilities.ConfigString("BaseURL");
            //ExtentReportOn = Convert.ToBoolean(CoreUtilities.ConfigString("ExtentReportOn"));
            //ExtentReportDarkTheme = Convert.ToBoolean(CoreUtilities.ConfigString("ExtentReportDarkTheme"));
            //AutoOpenExtentReport = Convert.ToBoolean(CoreUtilities.ConfigString("AutoOpenExtentReport"));
            //CommandCleanUp = Convert.ToBoolean(CoreUtilities.ConfigString("CommandCleanUp"));
            //CleanUp = Convert.ToBoolean(CoreUtilities.ConfigString("CleanUp"));
            //ExceptionIsOn = Convert.ToBoolean(CoreUtilities.ConfigString("ExceptionIsOn"));
            //LogIsOn = Convert.ToBoolean(CoreUtilities.ConfigString("LogIsOn"));
            //LocatorDebugON = Convert.ToBoolean(CoreUtilities.ConfigString("LocatorDebugON"));
            //ScreenShotCheck = Convert.ToBoolean(CoreUtilities.ConfigString("ScreenShotCheck"));
            //PassScrennShot = Convert.ToBoolean(CoreUtilities.ConfigString("PassScrennShot"));
            //FailScrennShot = Convert.ToBoolean(CoreUtilities.ConfigString("FailScrennShot"));
            //RetryAttempt = Convert.ToInt32(CoreUtilities.ConfigString("RetryAttempt"));
            DefaultCounter = 0;
        }
        public void TestRunCleanUp()
        {

            if (CleanUp)
            {
                driver.Quit();
                driver.Dispose();
                driverSet = false;
            }
            if (CommandCleanUp)
            {
                switch (CoreUtilities.NormalizedString(ExecutionBrowser))
                {
                    case "chrome":
                        System.Diagnostics.Process.Start("CMD.exe", "/C taskkill /im chromedriver.exe /f");
                        break;
                    case "firefox":
                        System.Diagnostics.Process.Start("CMD.exe", "/C taskkill /im geckodriver.exe /f");
                        break;
                    case "edge":
                        System.Diagnostics.Process.Start("CMD.exe", "/C taskkill /im msedgedriver.exe /f");
                        break;
                    default:
                        break;
                }

            }
        }
        public void BrowserClose()
        {
            driver.Close();
            driverSet = false;
        }
        public IWebDriver Init_Driver(string BrowserName = "")
        {
            string workingDirectory = Environment.CurrentDirectory;
            Console.WriteLine("The is directory : "+workingDirectory+"..\\..\\");
            switch (BrowserName.Equals("") ? CoreUtilities.NormalizedString(ExecutionBrowser) : BrowserName)
            {
                case "chrome":
                    ChromeOptions option = new ChromeOptions();
                    option.AddExcludedArgument("enable-automation");
                    option.AddAdditionalChromeOption("useAutomationExtension", false);
                    option.AddArguments("---start-maximized", "--no-sandbox");

                    driver = new ChromeDriver(ChromeDriverPath, option);
                    driverSet = true;
                    break;
                case "firefox":
                    driver = new FirefoxDriver(FireFoxDriverPath);
                    driverSet = true;
                    break;
                case "edge":
                    driver = new EdgeDriver(EdgeDriverPath);
                    driverSet = true;
                    break;
                default:
                    break;
            }

            return driver;
        }
        public Actions ActionWebElement()
        {
            Actions actions = new Actions(driver);
            return actions;
        }
        public WebDriverWait WebElement(string Locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.Until(ExpectedConditions.ElementExists(LocatorType(Locator)));
            return wait;
        }
        public IList<IWebElement> WebElements(string Locator)
        {
            return driver.FindElements(LocatorType(Locator));
        }
        public void OpenUrl(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }
        public void Maximize()
        {
            driver.Manage().Window.Maximize();
        }
        public void Click(string Locator, int counter = 0, bool StopOnFail = true)
        {
            try
            {
                IWebElement element = WebElement(Locator).Until(ExpectedConditions.ElementToBeClickable(LocatorType(Locator)));
                if (element.Enabled && element.Displayed)
                {
                    element.Click();
                    Log("This is Click Action Passed Locator is [" + Locator + "]");
                }
                else
                {
                    Log("This is Click Action Failed because element is not enabled or displayed Locator is [" + Locator + "]");
                }

            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Click Action Failed Locator is [" + Locator + "]");
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    Click(Locator, counter, StopOnFail);
                }
            }
        }
        public void Select(string Locator,string ListItem,string SelectType="by_value", int counter = 0, bool StopOnFail = true)
        {
            try
            {
                IWebElement element = WebElement(Locator).Until(ExpectedConditions.ElementToBeClickable(LocatorType(Locator)));
                if (element.Enabled && element.Displayed)
                {
                    element.Click();
                    Log("This is Select Action Passed Locator is [" + Locator + "] and Value [" + ListItem + "]");
                }
                else
                {
                    Log("This is Select Action Failed because element is not enabled or displayed Locator is [" + Locator + "] and Value [" + ListItem + "]");
                }
                SelectElement selectElement = new SelectElement(element);
                if (SelectType.Equals("by_value"))
                {
                    selectElement.SelectByValue(ListItem);
                }
                else if (SelectType.Equals("by_text"))
                {
                    selectElement.SelectByText(ListItem);
                }
                else if (SelectType.Equals("by_index"))
                {
                    selectElement.SelectByIndex(Convert.ToInt32(ListItem));
                }

            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Select Action Failed Locator is [" + Locator + "] and Value ["+ListItem+"]");
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    Select(Locator, ListItem, SelectType, counter, StopOnFail);
                }
            }
        }
        public void Type(string Data, string Locator, bool clear = true, bool LineBreaksCheck = false, int counter = 0, bool StopOnFail = true)
        {
            try
            {
                IWebElement element = WebElement(Locator).Until(ExpectedConditions.ElementIsVisible(LocatorType(Locator)));
                if (element.Enabled)
                {
                    if (clear)
                    {
                        ClearElement(element);
                    }
                    if (LineBreaksCheck)
                    {
                        LineBreakInString(element, Data);
                    }
                    else
                    {
                        element.SendKeys(Data);
                    }
                    Log("This is Type Action Passed Locator is [" + Locator + "] with Data : [" + Data + "]");
                }
                else
                {
                    Log("This is Type Action Failed because element is not enabled Locator is [" + Locator + "] with Data : [" + Data + "]");
                }

            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Type Action Failed Locator is [" + Locator + "] with Data : [" + Data + "]");
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    Type(Data, Locator, clear, LineBreaksCheck, counter, StopOnFail);
                }
            }
        }
        public void Asserts(string Locator, string ExpectedText, int counter = 0, bool StopOnFail = true)
        {
            try
            {
                IWebElement element = WebElement(Locator).Until(ExpectedConditions.ElementIsVisible(LocatorType(Locator)));
                string ActualText = element.Text;
                ActualMsg += (ActualText.Equals("") ? "" : "--Message NO : " + counter + " = [" + ActualText + "]--");
                if (!ActualText.Equals(ExpectedText) && StopOnFail)
                {
                    throw new Exception("\nValues Are Not Equal Expected Text is : [" + ExpectedText + "] and Actual Text is : [" + ActualMsg + "]");
                }
                Log("This is Compare Action Passed Locator is [" + Locator + "] and Expected Text : [" + ExpectedText + "] while Actual Text is [" + ActualMsg + "]");
            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Compare Action Failed Locator is [" + Locator + "] and Expected Text : [" + ExpectedText + "] while Actual Text is [" + ActualMsg + "]");
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    Asserts(Locator, ExpectedText, counter, StopOnFail);
                }
            }
        }
        public bool Exists(string Locator, int counter = 0, bool StopOnFail = false)
        {
            bool result = false;
            try
            {
                IWebElement element = WebElement(Locator).Until(ExpectedConditions.ElementIsVisible(LocatorType(Locator)));

                if (element.Enabled || element.Displayed)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                Log("This is Exists Action Passed Locator is [" + Locator + "] and Visible And Enable : [" + result.ToString() + "]");
                return result;
            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Exists Action Failed Locator is [" + Locator + "] and Visible And Enable : [" + result.ToString() + "]");
                    ExceptionThrow(e, StopOnFail);

                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    Exists(Locator, counter, StopOnFail);
                }
                return result;
            }
        }
        public void DoubleClick(string Locator, int counter = 0, bool StopOnFail = true)
        {
            try
            {
                IWebElement element = WebElement(Locator).Until(ExpectedConditions.ElementToBeClickable(LocatorType(Locator)));
                if (element.Enabled && element.Displayed)
                {
                    ActionWebElement().DoubleClick(element).Perform();
                    Log("This is Double Click Passed Action Locator is [" + Locator + "]");

                }
                else
                {
                    Log("This is Double Click Failed because element is not enabled or displayed Action Locator is [" + Locator + "]");
                }
            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Double Click Failed Action Locator is [" + Locator + "]");
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    DoubleClick(Locator, counter, StopOnFail);
                }
            }
        }
        public void RightClick(string Locator, int counter = 0, bool StopOnFail = true)
        {
            try
            {
                IWebElement element = WebElement(Locator).Until(ExpectedConditions.ElementToBeClickable(LocatorType(Locator)));
                if (element.Enabled && element.Displayed)
                {
                    ActionWebElement().ContextClick(element).Perform();
                    Log("This is Right Click Passed Action Locator is [" + Locator + "]");

                }
                else
                {
                    Log("This is Right Click Failed is not enabled or displayed Action Locator is [" + Locator + "]");
                }
            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Right Click Action Failed Locator is [" + Locator + "]");
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    RightClick(Locator, counter, StopOnFail);
                }
            }
        }
        public void DragAndDrop(string SourceElement, string TargetElement, int counter = 0, bool StopOnFail = true)
        {
            try
            {
                IWebElement Source_element = WebElement(SourceElement).Until(ExpectedConditions.ElementToBeClickable(LocatorType(SourceElement)));
                IWebElement Target_element = WebElement(TargetElement).Until(ExpectedConditions.ElementToBeClickable(LocatorType(TargetElement)));
                if (Source_element.Enabled && Source_element.Displayed && Target_element.Enabled && Target_element.Displayed)
                {
                    ActionWebElement().DragAndDrop(Source_element, Target_element).Perform();
                    Log("This is Drag and Drop Action Passed Source Locator is [" + SourceElement + "] and Target Locator is : [" + TargetElement + "]");
                }
                else
                {
                    Log("This is Drag and Drop Action Failed because sorce or target element is not enabled or displayed Source Locator is [" + SourceElement + "] and Target Locator is : [" + TargetElement + "]");
                }
            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Drag and Drop Action Failed Source Locator is [" + SourceElement + "] and Target Locator is : [" + TargetElement + "]");
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    DragAndDrop(SourceElement, TargetElement, counter, StopOnFail);
                }
            }
        }
        public void DragAndDropByAxis(string SourceElement, int X_Axis, int Y_Axis, int counter = 0, bool StopOnFail = true)
        {
            try
            {
                IWebElement Source_element = WebElement(SourceElement).Until(ExpectedConditions.ElementToBeClickable(LocatorType(SourceElement)));
                if (Source_element.Enabled && Source_element.Displayed)
                {
                    ActionWebElement().DragAndDropToOffset(Source_element, X_Axis, Y_Axis).Perform();
                    Log("This is Drag and Drop Action Passed Source Locator is [" + SourceElement + "] and X Axis is : [" + X_Axis + "] , Y Axis is : [" + Y_Axis + "]");

                }
                else{
                    Log("This is Drag and Drop Action Failed because its may not enabled or displayed Source Locator is [" + SourceElement + "] and X Axis is : [" + X_Axis + "] , Y Axis is : [" + Y_Axis + "]");
                }
            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Drag and Drop Action Failed Source Locator is [" + SourceElement + "] and X Axis is : [" + X_Axis + "] , Y Axis is : [" + Y_Axis + "]");
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    DragAndDropByAxis(SourceElement, X_Axis, Y_Axis, counter, StopOnFail);
                }
            }
        }
        public void PressKeys(string Locator, string KeyboardKeys, int counter = 0, bool StopOnFail = true)
        {
            try
            {
                IWebElement element = WebElement(Locator).Until(ExpectedConditions.ElementIsVisible(LocatorType(Locator)));
                if(element.Enabled)
                {
                    element.SendKeys(KeyboardKeys);
                    Log("This is Press Keys Action Passed Locator is [" + KeyboardKeys + "]");
                }
                else
                {
                    Log("Fail to preform Press Keys Action because element is not enable state Locator is [" + KeyboardKeys + "]");
                }
            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Press Keys Action Failed Locator is [" + KeyboardKeys + "]");
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    PressKeys(Locator, KeyboardKeys, counter, StopOnFail);
                }
            }
        }
        public void PressKeys(IWebElement element, string KeyboardKeys, int counter = 0, bool StopOnFail = true, bool offLog = true)
        {
            try
            {
                if (element.Enabled)
                {
                    element.SendKeys(KeyboardKeys);
                }
                if (offLog)
                {
                    Log("This is Press Keys Action Passed Locator is [" + KeyboardKeys + "]");
                }
            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    if (offLog)
                    {
                        Log("This is PressKeys Action Failed Locator is [" + KeyboardKeys + "]");

                    }
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    PressKeys(element, KeyboardKeys, counter, StopOnFail);
                }
            }
        }
        public void ClickAndHold(string Locator, int counter = 0, bool StopOnFail = true)
        {
            try
            {
                IWebElement element = WebElement(Locator).Until(ExpectedConditions.ElementToBeClickable(LocatorType(Locator)));
                if (element.Enabled && element.Displayed)
                {
                    ActionWebElement().ClickAndHold(element);
                    Log("This is Click And Hold Action Passed Locator is [" + Locator + "]");
                }
                else
                {
                    Log("This is Click And Hold Action Failed because element is not enabled or displayed Locator is [" + Locator + "]");
                }

            }
            catch (Exception e)
            {
                if (DefaultCounter >= (!counter.Equals(0) ? counter : RetryAttempt))
                {
                    Log("This is Click And Hold Action Failed Locator is [" + Locator + "]");
                    ExceptionThrow(e, StopOnFail);
                }
                else
                {
                    Wait(1);
                    DefaultCounter += 1;
                    ClickAndHold(Locator, counter, StopOnFail);
                }
            }
        }
        public bool ScreenShot(string path, string fileName)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (driverSet)
                {
                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                    ss.SaveAsFile(@"" + path + fileName + ".jpeg");
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail to take Screen Shot\n The Error is :[{0}]", e.ToString());
                return false;
            }

        }

        #region API Actions

        public RestResponse CallAPI(string url, Method method, string baseURL = "")
        {
            return new RestClient(baseURL.Equals("") ? BaseURL : baseURL).Execute(new RestRequest(url, method)); ;
        }
        #endregion

    }

}
