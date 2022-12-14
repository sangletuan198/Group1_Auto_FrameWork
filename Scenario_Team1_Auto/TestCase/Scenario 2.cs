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
            manageAssignmentsPage.ClosePopUpDetailAssign();

            manageAssignmentsPage.GetCreateNewAssignmentsPage();
            manageAssignmentsPage.VerifyCreateNewAssignmentPageDisplay();
            manageAssignmentsPage.CreateNewAssignment();

            manageAssignmentsPage.EditAssignment();
            manageAssignmentsPage.CancelEditAssignment();

            manageAssignmentsPage.CancelDeleteAssignment();

            homePage.Logout(userName);

            string stafuserName = Constant.stafUsername;
            string stafpassword = Constant.staffPassword;

            loginPage.Login(stafuserName, stafpassword);

            homePage.StaffAcptAssignment();
            homePage.Logout(stafuserName);

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
        }
    }
}