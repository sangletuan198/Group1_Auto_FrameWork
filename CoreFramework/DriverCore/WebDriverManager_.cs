﻿using OpenQA.Selenium;

namespace CoreFramework.DriverCore
{
    public class WebDriverManager_
    {
        private static AsyncLocal<IWebDriver> driver = new AsyncLocal<IWebDriver>();

        public static void InitDriver(string Browser, int Width, int Height)
        {
            IWebDriver newDriver = null;

            newDriver = WebDriverCreator.CreateLocalDriver(Browser, Width, Height);

            if (newDriver == null)
                throw new Exception($"{Browser} browser is not supported)");
            driver.Value = newDriver;
        }

        public static IWebDriver GetCurrentDriver()
        {
            return driver.Value;
        }

        public static void CloseDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
            }
        }
    }
}
