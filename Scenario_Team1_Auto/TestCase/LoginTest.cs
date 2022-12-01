using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.TestSetup;
using NUnit.Framework;

namespace Scenario_Team1_Auto.TestCase
{
    [TestFixture]
    public class LoginTest : ProjectNUnitTestSetup
    {
        [Test]
        public void TestCase() // admin login, verify authority of admin, change password, login with newpassword, reset password, logout, staff login, verify authority of staff, logout 
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);

            string adminUserName = Constant.adminUserName;
            string adminPassword = Constant.adminPassword;
            string newPassword = Constant.newPassword;

            string staffUserName = Constant.staffUserName;
            string staffPassword = Constant.staffPassword;

            loginPage.Login(adminUserName, adminPassword);
            homePage.VerifyAdminAccessAuthority();

            homePage.ChangePassword(adminPassword, newPassword);
            loginPage.Login(adminUserName, newPassword);
       
            homePage.ChangePassword(newPassword, adminPassword);
            loginPage.Login(adminUserName, adminPassword);
            homePage.Logout();

            loginPage.Login(staffUserName, staffPassword);
            homePage.VerifyStaffAccessAuthority();
            homePage.Logout();
        }
    }
}
