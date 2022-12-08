using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject
{
    public class RequestReturningPage : WebDriverAction
    {
        public RequestReturningPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
