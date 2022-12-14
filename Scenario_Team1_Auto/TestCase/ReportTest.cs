using NUnit.Framework;
using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.TestCase
{
    [TestFixture]
    public class Report : ProjectNUnitTestSetup
    {

        [Test]
        public void AdminViewReportPage() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ReportPage reportPage = new ReportPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetReportPage();
            reportPage.VerifyReportPageDisplay();

        }

        [Test]
        public void AdminExportReportPage() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ReportPage reportPage = new ReportPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetReportPage();
            reportPage.VerifyReportPageDisplay();
            reportPage.ExportReport();

        }

    }
}
