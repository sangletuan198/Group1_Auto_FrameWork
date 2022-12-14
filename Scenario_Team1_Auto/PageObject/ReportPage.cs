using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject
{
    public class ReportPage : WebDriverAction
    {
        public ReportPage(IWebDriver driver) : base(driver)
        {
        }    
        public string pageTitle = "//div[text()='Report']";
        public string btnExportReport = "//span[text() ='Export']";

        public void VerifyReportPageDisplay()
        {
            IsElementDisplay(pageTitle);
        }

        public void ExportReport()
        {
            Clicks(btnExportReport);
        }
    }
}
