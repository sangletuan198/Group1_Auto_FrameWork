using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
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
    public class ManageAassignments : ProjectNUnitTestSetup
    {
        [Test]
        public void ViewAllAassignment() // admin view Aassignments Page, Assignments List and detail of Aassignments
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            homePage.GetManageAassignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.GetAssignmentList();
            manageAssignmentsPage.GetDetailOfRandomAssignment();
            manageAssignmentsPage.VerifyAssignmentPopupDisplay();
        }

        [Test]
        public void CreateNewAssignment() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAassignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            Thread.Sleep(2000);
            manageAssignmentsPage.GetCreateNewAssignmentsPage();
            manageAssignmentsPage.VerifyCreateNewAssignmentPageDisplay();
            Thread.Sleep(2000);
            manageAssignmentsPage.CreateNewAssignment();
        }

        [Test]
        public void EditAssignment() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAassignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            Thread.Sleep(2000);
            manageAssignmentsPage.EditAssignment();


        }

        [Test]
        public void DeleteAssignment() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAassignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            Thread.Sleep(2000);
            manageAssignmentsPage.DeleteAssignment();


        }
    }
}
