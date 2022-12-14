using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.Common
{
    public class Commons : WebDriverAction
    {
        public Commons(IWebDriver driver) : base(driver)
        {
        }
        public void Replace(String locator, string key)
        {
            try
            {
                FindElementByXpath(locator).Clear();
                FindElementByXpath(locator).SendKeys(key);
                TestContext.WriteLine("Replace" + locator.ToString() + "to" + key.ToString() + "passed");
                HtmlReport.Pass("Replace" + locator.ToString() + "to" + key.ToString() + "passed");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("SendKey into element " + locator + "failed");
                HtmlReport.Fail("Replace" + locator.ToString() + "to" + key.ToString() + "failed", TakeScreenShot());
                throw ex;
            }
        }
        public void Replace2(String locator, string key)
        {
            try
            {
                IWebElement e = FindElementByXpath(locator);
                e.SendKeys(Keys.Control + "a");
                e.SendKeys(Keys.Control + "x");
                e.SendKeys(key);
                TestContext.WriteLine("Replace" + locator.ToString() + "to" + key.ToString() + "passed");
                HtmlReport.Pass("Replace" + locator.ToString() + "to" + key.ToString() + "passed");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("SendKey into element " + locator + "failed");
                HtmlReport.Fail("Replace" + locator.ToString() + "to" + key.ToString() + "failed", TakeScreenShot());
                throw ex;
            }
        }
        public void ClickAndSelect(string locator, string optionLocator)
        {
            Click(FindElementByXpath(locator));
            Click(FindElementByXpath(optionLocator));
            TestContext.WriteLine("Select element " + locator + " successfuly with " + optionLocator);
            HtmlReport.Pass("Select element " + locator + " successfuly with " + optionLocator);
        }
        public void RemoveReadonlyAndSendKeys(string locator, string key)
        {
            Click(locator);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].removeAttribute('readonly')", WaitForElementExists(driver, locator, 5));

            Replace(locator, key);
            SendKey(locator, Keys.Enter);
        }
        public void SelectOption(String locator, String key)
        {
            try
            {
                IWebElement mySelectOption = FindElementByXpath(locator);
                SelectElement dropdown = new SelectElement(mySelectOption);
                dropdown.SelectByText(key);
                TestContext.WriteLine("Select element " + locator + " successfuly with " + key);
                HtmlReport.Pass("Select" + key.ToString() + "from" + locator.ToString() + "passed");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Select element " + locator + " failed with " + key);
                HtmlReport.Fail("Select" + key.ToString() + "from" + locator.ToString() + "failed", TakeScreenShot());
            }
        }
    }
}
