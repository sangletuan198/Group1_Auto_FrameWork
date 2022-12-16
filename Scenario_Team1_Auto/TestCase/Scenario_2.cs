using NUnit.Framework;
using RookiesTest.TestSetup;
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
    public class Scenario_2 : NUnitWebTestSetup
    {
        [Test]
        public void Scenario2() // admin view Aassignments Page, Assignments List and detail of Aassignments
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);

            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            //Admin manage assignment
            string userName = Constant.ADMIN_USERNAME;
            string password = Constant.ADMIN_PASSWORD;

            loginPage.Login(userName, password);

            homePage.GetManageAassignmentsPage();
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
        
            //Member accept/decline assign 
            string stafuserName = Constant.STAFF_USERNAME1;
            string stafpassword = Constant.STAFF_PASSWORD1;

            loginPage.Login(stafuserName, stafpassword);

            homePage.StaffAcptAssignment();
            Thread.Sleep(1000);
            homePage.StaffDeclineAssignment();

            homePage.Logout(stafuserName);
        
            //Admin export report
            loginPage.Login(userName, password);

            ReportPage reportPage = new ReportPage(_driver);
            homePage.GetReportPage();
            reportPage.VerifyReportPageDisplay();
            reportPage.ExportReport();
            //homePage.Logout(userName);
        }

        //[Test]
        //public void AdminCreateReturnRequest_2_2_2() // admin view Aassignments Page, Assignments List and detail of Aassignments
        //{
        //    LoginPage loginPage = new LoginPage(_driver);
        //    HomePage homePage = new HomePage(_driver);

        //    ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

        //    //Admin manage assignment
        //    string userName = Constant.ADMIN_USERNAME;
        //    string password = Constant.ADMIN_PASSWORD;

        //    loginPage.Login(userName, password);

        //    homePage.GetManageAassignmentsPage();
        //    manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
        //    manageAssignmentsPage.GetAssignmentList();                      //1. Admin view assignment list.
        //    manageAssignmentsPage.GetDetailOfRandomAssignment();
        //    manageAssignmentsPage.VerifyAssignmentPopupDisplay();
        //    manageAssignmentsPage.ClosePopUpDetailAssign();

        //    // Admin create new assignment
        //    manageAssignmentsPage.GetCreateNewAssignmentsPage();                // 1 asset
        //    manageAssignmentsPage.VerifyCreateNewAssignmentPageDisplay();
        //    manageAssignmentsPage.CreateNewAssignment();

        //    homePage.Logout(userName);

        //    //Member accept assign
        //    string stafuserName = Constant.STAFF_USERNAME;
        //    string stafpassword = Constant.STAFF_PASSWORD;

        //    loginPage.Login(stafuserName, stafpassword);

        //    homePage.StaffAcptAssignment();
        //    homePage.Logout(stafuserName);

        //    //admin create request for return assign
        //    RequestForReturningPage returnRequestPage = new RequestForReturningPage(_driver);

        //    loginPage.Login(userName, password);

        //    homePage.GetManageAassignmentsPage();
        //    manageAssignmentsPage.VerifyManageAssignmentsPageDisplay();
        //    manageAssignmentsPage.SortByStateAcpt();
        //    manageAssignmentsPage.AdminCreateReturnAssYes();

        //    homePage.GetReqForReturnPage();
        //    returnRequestPage.VerifyReturnPageDisplay();
        //    returnRequestPage.ReturnPageSearchByStateWaiting();
        //    returnRequestPage.AdminConfirmReturn();

        //    ReportPage reportPage = new ReportPage(_driver);

        //    homePage.GetReportPage();
        //    reportPage.VerifyReportPageDisplay();
        //    reportPage.ExportReport();
        //    //homePage.Logout(userName);
        //}
    }
}