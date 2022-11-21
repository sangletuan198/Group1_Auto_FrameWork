using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookiesTest2.PageObject
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        private readonly String tfElements = "//*[text()='Elements']";
        public void GetElementsPage()
        {
            Clicks(tfElements);
        }
    }
}