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
                Thread.Sleep(500);
                TestContext.WriteLine("click into element" + e.ToString() + "passed");
                HtmlReport.Pass("click into element" + e.ToString() + "passed");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("click into element" + e.ToString() + "failed");
                HtmlReport.Fail("click into element" + e.ToString() + "failed", TakeScreenShot());
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
                Thread.Sleep(500);
                TestContext.WriteLine("click into element" + locator.ToString() + "passed");
                HtmlReport.Pass("click into element" + locator.ToString() + "passed");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("click into element" + locator.ToString() + "failed");
                HtmlReport.Fail("click into element" + locator.ToString() + "failed", TakeScreenShot());
                throw ex;
            }

        }


        public void SendKey(String locator, string key)
        {
            try
            {
                WaitForElementExists(driver, locator);
                FindElementByXpath(locator).SendKeys(key);
                TestContext.WriteLine("SendKey into element " + locator.ToString() + "passed");
                HtmlReport.Pass("senkey into element" + locator.ToString() + "passed");
                
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("SendKey into element " + locator.ToString() + "failed");
                HtmlReport.Fail("senkey into element" + locator.ToString() + "failed", TakeScreenShot());
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
      
        public IWebElement WaitForElementToBeClickable(IWebDriver driver, IWebElement e, float timeOut = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(e));
        }

        public IWebElement WaitForElementExists(IWebDriver driver, string locator, float timeOut = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locator)));
        }

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        public bool IsElementDisplay(string locator)
        {
            try
            {
                FindElementByXpath(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsElementNotDisplay(string locator)
        {
            try
            {
                IsElementDisplay(locator);
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public bool IsElementEnable(string locator)
        {
            IWebElement e = FindElementByXpath(locator);
            if (e.Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsElementDisable(string locator)
        {
            IWebElement e = FindElementByXpath(locator);
            if (e.Enabled)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string GetText(string locator)
        {
            return FindElementByXpath(locator).Text;
        }
    }
}
