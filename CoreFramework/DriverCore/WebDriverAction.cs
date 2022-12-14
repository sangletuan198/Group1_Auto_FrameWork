using OpenQA.Selenium;
using NUnit.Framework;
using CoreFramework.Reporter;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void GoToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
            HtmlReport.Pass("Go to URL: " + url);
        }
        public void RefreshPage()
        {
            driver.Navigate().Refresh();   
        }
        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public IWebElement FindElementByXpath(string locator)
        {
            try
            {
                WaitForElementExists(driver, locator);  
                IWebElement e = driver.FindElement(ByXpath(locator));
                
                TestContext.WriteLine("Find element" + locator.ToString() + "passed");
                highlightElement(e);
                HtmlReport.Pass("Find element" + locator.ToString() + "passed");
                return e;
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot find element" + locator.ToString());
                HtmlReport.Fail("Cannot find element" + locator.ToString(), TakeScreenShot());
                throw ex;
            }
        }

        public IList<IWebElement> FindElementsByXpath(string locator)
        {
            return driver.FindElements(ByXpath(locator));
        }

        public IWebElement highlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border='2px solid red'", element);
            return element;
        }

        public void Click(IWebElement e)
        {
            try
            {
                WaitForElementToBeClickable(driver, e);
                highlightElement(e);
                e.Click();
                TestContext.WriteLine("Click into element " + e.ToString() + " passed");
                HtmlReport.Pass("Click into element " + e.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into element " + e.ToString() + " failed");
                HtmlReport.Fail("Click into element " + e.ToString() + " failed", TakeScreenShot());
                throw ex;
            }
        }
   
        public void Click(string locator)
        {
            try
            {
                WaitForElementExists(driver, locator);
                IWebElement e = FindElementByXpath(locator);
                WaitForElementToBeClickable(driver, e);
                FindElementByXpath(locator).Click();
                TestContext.WriteLine("Click into element " + locator.ToString() + " passed");
                HtmlReport.Pass("Click into element " + locator.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into element " + locator.ToString() + " failed");
                HtmlReport.Fail("Click into element " + locator.ToString() + " failed", TakeScreenShot());
                throw ex;
            }

        }


        public void SendKey(String locator, string key)
        {
            try
            {
                WaitForElementExists(driver, locator);
                FindElementByXpath(locator).SendKeys(key);
                TestContext.WriteLine("SendKey " + key.ToString() + " into element " + locator.ToString() + " passed");
                HtmlReport.Pass("Senkey " + key.ToString() + " into element " + locator.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("SendKey " + key.ToString() + " into element " + locator.ToString() + "failed");
                HtmlReport.Fail("SendKey " + key.ToString() + " into element " + locator.ToString() + "failed", TakeScreenShot());
                throw ex;
            }
        }

        public string TakeScreenShot()
        {
            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
      
        public IWebElement WaitForElementToBeClickable(IWebDriver driver, IWebElement e, float timeOut = 3)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(e));
        }

        public IWebElement WaitForElementExists(IWebDriver driver, string locator, float timeOut = 3)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locator)));
        }
       

        
        public bool IsElementDisplay(string locator)
        {
            try
            {
                driver.FindElement(ByXpath(locator));
                TestContext.WriteLine("Element " + locator + " is display");
                HtmlReport.Pass("Element " + locator + " is display");
                return true;
            }
            catch (NoSuchElementException)
            {
                TestContext.WriteLine("Element " + locator + " is not display");
                HtmlReport.Fail("Element " + locator + " is not display", TakeScreenShot());
                return false;
            }
        }
        public bool IsElementNotDisplay(string locator)
        {
            try
            {
                
                driver.FindElement(ByXpath(locator));
                TestContext.WriteLine("Element " + locator + " is display");
                HtmlReport.Fail("Element " + locator + " is display", TakeScreenShot());
                return false;
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Element " + locator + " is not display");
                HtmlReport.Pass("Element " + locator + " is not display");
                return true;
            }
        }

        public bool IsElementEnable(string locator)
        {
            IWebElement e = driver.FindElement(ByXpath(locator));
            if (e.Enabled)
            {
                TestContext.WriteLine("Element " + locator + " enable");
                HtmlReport.Pass("Element " + locator + " enable");
                return true;
            }
            else
            {
                TestContext.WriteLine("Element " + locator + " disable");
                HtmlReport.Fail("Element " + locator + " disnable",TakeScreenShot());
                return false;
            }
        }

        public bool IsElementDisable(string locator)
        {
            IWebElement e = driver.FindElement(ByXpath(locator));
            if (e.Enabled)
            {
                TestContext.WriteLine("Element " + locator + " enable");
                HtmlReport.Fail("Element " + locator + " enable", TakeScreenShot());
                return false;
            }
            else
            {
                TestContext.WriteLine("Element " + locator + " disable");
                HtmlReport.Pass("Element " + locator + " disable");
                return true;
            }
        }
    }
}
