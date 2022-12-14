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
    public class ManageAssignments : ProjectNUnitTestSetup
    {
        [Test]
        public void AdminViewAllAassignment() // admin view Aassignments Page, Assignments List and detail of Aassignments
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.GetAssignmentList();
            manageAssignmentsPage.GetDetailOfRandomAssignment();
            manageAssignmentsPage.VerifyAssignmentPopupDisplay();
        }

        [Test]
        public void AdminCreateNewAssignment() 
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            Thread.Sleep(2000);
            manageAssignmentsPage.GetCreateNewAssignmentsPage();
            manageAssignmentsPage.VerifyCreateNewAssignmentPageDisplay();
            Thread.Sleep(2000);
            manageAssignmentsPage.CreateNewAssignment();
        }

        [Test]
        public void AdminEditAssignment() 
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            Thread.Sleep(2000);
            manageAssignmentsPage.EditAssignment();


        }

        public void AdminEditAssignmentCancel()
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            Thread.Sleep(2000);
            manageAssignmentsPage.CancelEditAssignment();


        }

        [Test]
        public void AdminDeleteAssignmentYes() 
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            Thread.Sleep(2000);
            manageAssignmentsPage.DeleteAssignment();


        }

        [Test]
        public void AdminDeleteAssignmentNo() 
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            Thread.Sleep(2000);
            manageAssignmentsPage.CancelDeleteAssignment();


        }

        [Test]
        public void AdminCreateReturnAssignmentYes()
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.AdminCreateReturnAssYes();

        }

        [Test]
        public void AdminCreateReturnAssignmentNo()
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.AdminCreateReturnAssNo();

        }

        [Test]
        public void AdminSortAssignmentByStateAll() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.SortByStateAll();
        }

        [Test]
        public void AdminSortAssignmentByStateAccept() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.SortByStateAcpt();
        }

        [Test]
        public void AdminSortAssignmentByStateWaiting() // admin view create new Assignment page
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.SortByStateWait();
        }

        [Test]
        public void AdminFilterSearchAssignment()
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.SearchFilter();
        }

        [Test]
        public void StaffAcceptAssignment() 
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.stafUsername;
            string password = Constant.staffPassword;

            loginPage.Login(userName, password);
            Thread.Sleep(2000);
            homePage.StaffAcptAssignment();
        }


    }
}
