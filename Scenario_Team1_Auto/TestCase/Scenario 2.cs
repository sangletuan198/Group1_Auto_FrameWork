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
    public class Scenario_2 : ProjectNUnitTestSetup
    {
        [Test]
        public void AdminManageAssignment_1() // admin view Aassignments Page, Assignments List and detail of Aassignments
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);

            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            //Admin manage assignment
            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);

            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.GetAssignmentList();                      //1. Admin view assignment list.
            manageAssignmentsPage.GetDetailOfRandomAssignment();
            manageAssignmentsPage.VerifyAssignmentPopupDisplay();
            manageAssignmentsPage.ClosePopUpDetailAssign();

            // Admin create new assignment
            manageAssignmentsPage.GetCreateNewAssignmentsPage();                // 1 asset
            manageAssignmentsPage.VerifyCreateNewAssignmentPageDisplay();
            manageAssignmentsPage.CreateNewAssignment();

            //Admin edit assignment information.
            manageAssignmentsPage.EditAssignment();
            manageAssignmentsPage.CancelEditAssignment();

            //Admin delete assignment.                       
            manageAssignmentsPage.DeleteAssignment();
            manageAssignmentsPage.GetCreateNewAssignmentsPage();                // 1 asset
            manageAssignmentsPage.VerifyCreateNewAssignmentPageDisplay();
            manageAssignmentsPage.CreateNewAssignment();                         // 3 asset

            homePage.Logout(userName);
        }

        [Test]
        public void MemberControlAssignment_2_3()
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);

            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);
            //Member accept/decline assign 
            string stafuserName = Constant.stafUsername;
            string stafpassword = Constant.staffPassword;

            loginPage.Login(stafuserName, stafpassword);

            homePage.StaffAcptAssignment();
            Thread.Sleep(2000);
            homePage.StaffDeclineAssignment();

            //Staff return assign
            homePage.StaffReturnAssignment();
            homePage.Logout(stafuserName);
        }

        [Test]  
        public void AdminManageRequestForReturn_4_5_6()
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            RequestForReturningPage returnRequestPage = new RequestForReturningPage(_driver);

            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            //Admin manage request for returning / 2.4
            loginPage.Login(userName, password);
            homePage.GetReqForReturnPage();
            returnRequestPage.VerifyReturnPageDisplay();

            returnRequestPage.ReturnPageSearchByStateWaiting();
            Thread.Sleep(1000);
            returnRequestPage.AdminConfirmReturn();

            ReportPage reportPage = new ReportPage(_driver);
            //2.5 2.6
            homePage.GetReportPage();
            reportPage.VerifyReportPageDisplay();
            reportPage.ExportReport();
            homePage.Logout(userName);
        }

        [Test]
        public void AdminCreateReturnRequest_2_2_2() // admin view Aassignments Page, Assignments List and detail of Aassignments
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);

            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            //Admin manage assignment
            string userName = Constant.adminUserName;
            string password = Constant.adminPassword;

            loginPage.Login(userName, password);

            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.GetAssignmentList();                      //1. Admin view assignment list.
            manageAssignmentsPage.GetDetailOfRandomAssignment();
            manageAssignmentsPage.VerifyAssignmentPopupDisplay();
            manageAssignmentsPage.ClosePopUpDetailAssign();

            // Admin create new assignment
            manageAssignmentsPage.GetCreateNewAssignmentsPage();                // 1 asset
            manageAssignmentsPage.VerifyCreateNewAssignmentPageDisplay();
            manageAssignmentsPage.CreateNewAssignment();

            homePage.Logout(userName);

            //Member accept assign
            string stafuserName = Constant.stafUsername;
            string stafpassword = Constant.staffPassword;

            loginPage.Login(stafuserName, stafpassword);

            homePage.StaffAcptAssignment();
            homePage.Logout(stafuserName);

            //admin create request for return assign
            RequestForReturningPage returnRequestPage = new RequestForReturningPage(_driver);

            loginPage.Login(userName, password);

            homePage.GetManageAssignmentsPage();
            manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
            manageAssignmentsPage.SortByStateAcpt();
            manageAssignmentsPage.AdminCreateReturnAssYes();

            homePage.GetReqForReturnPage();
            returnRequestPage.VerifyReturnPageDisplay();
            returnRequestPage.ReturnPageSearchByStateWaiting();
            returnRequestPage.AdminConfirmReturn();

            ReportPage reportPage = new ReportPage(_driver);

            homePage.GetReportPage();
            reportPage.VerifyReportPageDisplay();
            reportPage.ExportReport();
            homePage.Logout(userName);
        }
    }
}