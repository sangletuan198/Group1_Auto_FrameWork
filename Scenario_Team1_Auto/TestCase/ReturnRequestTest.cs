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
    public class RequestForReturning : ProjectNUnitTestSetup
    {
        [Test]
        public void AdminAcceptReturnRequest() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            RequestForReturningPage returnRequestPage = new RequestForReturningPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetReqForReturnPage();
            returnRequestPage.VerifyReturnPageDisplay();
            returnRequestPage.AdminConfirmReturn();

        }

        [Test]
        public void AdminCancelAcceptReturnRequest() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            RequestForReturningPage returnRequestPage = new RequestForReturningPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetReqForReturnPage();
            returnRequestPage.VerifyReturnPageDisplay();
            returnRequestPage.AdminCancelConfirmReturn();

        }

        [Test]
        public void AdminCancelReturnRequest() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            RequestForReturningPage returnRequestPage = new RequestForReturningPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetReqForReturnPage();
            returnRequestPage.VerifyReturnPageDisplay();
            returnRequestPage.AdminConfirmCancelReturn();

        }

        [Test]
        public void AdminCancelCancelReturnRequest() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            RequestForReturningPage returnRequestPage = new RequestForReturningPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetReqForReturnPage();
            returnRequestPage.VerifyReturnPageDisplay();
            returnRequestPage.AdminCancelConfirmCancelReturn();

        }
    }
}
