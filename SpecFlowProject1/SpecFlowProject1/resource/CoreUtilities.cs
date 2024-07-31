using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpecFlowProject1.Resource
{
    public class CoreUtilities : Constants
    {
        public string ConfigString(string KeyName)
        {
            return ConfigurationManager.AppSettings[KeyName];
        }
        public string NormalizedString(string variable, bool RemoveSpace = true, bool LowerCase = true, int TrimTextCount = 0, params string[] RemoveString)
        {
            if (RemoveSpace)
            {
                variable = variable.Replace(" ", "");
            }

            foreach (string item in RemoveString)
            {
                variable = variable.Replace(item, "");
            }
            if (!TrimTextCount.Equals(0) && TrimTextCount < variable.Length)
            {
                variable = variable.Remove(TrimTextCount, variable.Length - TrimTextCount);
            }
            return LowerCase ? variable.ToLower() : variable;
        }
        public string RemoveQuotesBeginAndEnd(string Locator)
        {
            string result = "";
            if (Regex.IsMatch(Locator, "\"(.*)\""))
            {
                result += Locator.Substring(1, Locator.Length - 2);
            }
            return result.Equals("") ? Locator : result;
        }
        public By LocatorType(string Locator)
        {
            By type;
            string Type = "";
            int position = 0;
            foreach (char letter in Locator)
            {
                if (letter.Equals(':') || letter.Equals('=') || letter.Equals('/'))
                {
                    break;
                }
                else
                {
                    Type += letter;
                    position++;
                }
            }
            Locator = Locator.Remove(0, position + (Locator[0].Equals('/') ? 0 : 1));
            Locator = RemoveQuotesBeginAndEnd(Locator);
            Type = NormalizedString(Type);
            switch (Type.Equals("") ? "xpath" : Type)
            {
                case "id":
                    type = By.Id(Locator);
                    break;
                case "xpath":
                    type = By.XPath(Locator);
                    break;
                case "classname":
                    type = By.ClassName(Locator);
                    break;
                case "css":
                    type = By.CssSelector(Locator);
                    break;
                case "cssselector":
                    type = By.CssSelector(Locator);
                    break;
                case "selector":
                    type = By.CssSelector(Locator);
                    break;
                case "linktext":
                    type = By.LinkText(Locator);
                    break;
                case "partiallinktext":
                    type = By.PartialLinkText(Locator);
                    break;
                case "tagname":
                    type = By.TagName(Locator);
                    break;
                case "tag":
                    type = By.TagName(Locator);
                    break;
                default:
                    type = By.XPath(Locator);
                    break;
            }
            if (LocatorDebugON)
            {
                Log("Locator Type is : [" + type + "] and Locator Value is :[" + Locator + "]");
            }
            return type;
        }
        public void ExceptionThrow(Exception e, bool StopOnFail = true)
        {
            if (ExceptionIsOn && StopOnFail)
            {
                throw new Exception("The Error is : [ " + e.ToString() + " ]\n");
            }
        }
        public void Log(string statement)
        {
            if (LogIsOn)
            {
                Console.WriteLine(statement);
            }
        }
        public void Wait(int Seconds)
        {
            Thread.Sleep(Seconds * 1000);
        }
        public string TakeLocator(string LocatorName)
        {
            string result = "";
            XElement root = XElement.Load(PageFactoryXMLPath);
            IEnumerable<XElement> ElementModule =
                from element in root.Elements("Module")
                where element.Attribute("key").Value.ToLower() == LocatorName.Split('_')[0].ToLower()
                select element;
            foreach (XElement elements in ElementModule)
            {
                foreach (XElement item in elements.Elements("element"))
                {
                    if (item.Attribute("key").Value.ToLower().Equals(LocatorName.ToLower()))
                    {
                        result = item.Attribute("value").Value;
                        break;
                    }
                }
            }

            return result;
        }
        public void LineBreakInString(IWebElement element, string Data)
        {
            int j = 0;
            bool skip = false;
            foreach (char item in Data)
            {
                if (Data[j].Equals('\\') && Data[j.Equals(Data.Length - 1) ? j : j + 1].Equals('n'))
                {
                    Page.PressKeys(element, (Keys.Shift + Keys.Enter), 0, true, false);
                    skip = true;
                }
                else if (skip)
                {
                    skip = false;
                }
                else
                {
                    Page.PressKeys(element, (item.ToString()), 0, true, false);
                }
                j += 1;
            }
        }
        public void ClearElement(IWebElement element)
        {
            Wait(1);
            for (int i = 0; i < 10; i++)
            {
                element.Clear();
                Page.PressKeys(element, Keys.Control + "A", 0, true, false);
                Page.PressKeys(element, Keys.Backspace, 0, true, false);
                Page.PressKeys(element, Keys.Control + "a", 0, true, false);
                Page.PressKeys(element, Keys.Backspace, 0, true, false);
            }
        }

        public bool IsValidStepParameterData(string stepsParameterData)
        {
            string pattern = "^[a-zA-Z0-9]+(?:_[a-zA-Z0-9]+)*$";
            bool isValid = Regex.IsMatch(stepsParameterData, pattern);
            isValid = isValid && !stepsParameterData.Contains(" ");

            return isValid;
        }
    }

}
