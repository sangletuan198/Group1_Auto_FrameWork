using NUnit.Framework;
using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.TestCase.Admin
{

    [TestFixture]
    public class ManageAassignments : ProjectNUnitTestSetup
    {
        [Test]
        public void ViewAllAassignment()
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageAssignmentsPage manageAssignmentsPage = new ManageAssignmentsPage(_driver);

            string userName = Constant.Admin_UserName;
            string password = Constant.Admin_Password;


            loginPage.Login(userName, password);
            homePage.GetManageAassignmentsPage();
            manageAssignmentsPage.isManageAssignmentsPageDisplay();
            manageAssignmentsPage.getAssignmentPopup();
        }
    }
}
