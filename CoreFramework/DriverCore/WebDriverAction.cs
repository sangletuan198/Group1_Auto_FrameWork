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

        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public string getTitle()
        {
            return driver.Title;
        }

        public string getUrl()
        {
            return driver.Url;
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
            catch(Exception ex)
            {
                return true;
            }
        }

        public IWebElement IsElementEnable(string locator)
        {
            IWebElement e =  FindElementByXpath(locator);
            if (e.Enabled)
            {
                TestContext.WriteLine("Element is enable");
            }
            else
            {
                TestContext.WriteLine("Element is disable");
            }
            return e;
         
        }

        public bool IsElementDisable(string locator)
        {
            IWebElement e = FindElementByXpath(locator);
            if (e.Enabled)
            {
                return false;
                TestContext.WriteLine("Element is enable");
            }
            else
            {
                TestContext.WriteLine("Element is disable");
                return true;
            }
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
        public By ByID(string locator)
        {
            return By.Id(locator);
        }
        public IWebElement FindElementByID(string locator)
        {
            IWebElement e = driver.FindElement(ByID(locator));
            highlightElement(e);
            return e;
        }
        public void Click(string locator)
        {
            try
            {
                
                WaitForElementExists(driver, locator);
                WaitForElementToBeClickable(driver, locator);
                FindElementByXpath(locator).Click();
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
        public void ClickByID(String locator)
        {
            try
            {
                FindElementByID(locator).Click();
                TestContext.WriteLine("Click into element " + locator + " successfuly");
                HtmlReport.Pass("Click into element " + locator + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into element " + locator + " failed");
                HtmlReport.Fail("Click into element " + locator + " failed", TakeScreenShot());
                throw ex;
            }
        }
        public void SendKeysByID(string locator, string key)
        {
            try
            {
                FindElementByID(locator).SendKeys(key)
;
                TestContext.WriteLine("Sendkey into element " + locator + " successfuly");
                HtmlReport.Pass("Sendkey into element " + locator + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Sendkey into element " + locator + " failed");
                HtmlReport.Fail("Sendkey into element " + locator + " failed", TakeScreenShot());
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

        public void Back()
        {
            driver.Navigate().Back();
        }

        public String GetText(string locator)
        {
            string e = FindElementByXpath(locator).Text;
            return e;
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

        public string TakeScreenShot()
        {
            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }

        public IWebElement WaitForElementToBeClickable(IWebDriver driver, string locator, float timeOut = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
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
        public bool WaitForElementSelectable(IWebDriver driver, string locator, float timeOut = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(By.XPath(locator)));
        }

        public void GoToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
            HtmlReport.Pass("Go to URL: " + url);
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
            jse.ExecuteScript("arguments[0].removeAttribute('readonly')", WaitForElementToBeClickable(driver,locator,5));
            //driver.execute_script("arguments[0].removeAttribute('readonly')", WebDriverWait(driver, 20).until(EC.element_to_be_clickable((By.XPATH, "//input[@class='ivu-input' and @placeholder='Select Date and Time']"))))
            SendKey(locator, key);
            SendKey(locator, Keys.Enter);
        }
    }
}
