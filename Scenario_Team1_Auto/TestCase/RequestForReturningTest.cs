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
    public class RequestForReturningTest : NashNUnitAPITestSetup
    {
        [Test]
        public void AccessRequest4Returning() 
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            RequestReturningPage requestPage = new RequestReturningPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);

            homePage.GetReqForReturn();

            requestPage.ViewPage();
        }
        [Test]
        public void SearchByState()
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            RequestReturningPage requestPage = new RequestReturningPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);

            homePage.GetReqForReturn();

            requestPage.SearchByStateComplete();
        }
        [Test]
        public void SearchByText()
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            RequestReturningPage requestPage = new RequestReturningPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);

            homePage.GetReqForReturn();

            requestPage.SearchByText();
        }
        [Test]
        public void CompleteRequest()
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            RequestReturningPage requestPage = new RequestReturningPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);

            homePage.GetReqForReturn();

            requestPage.CompleteRequest();
        }
    }
}