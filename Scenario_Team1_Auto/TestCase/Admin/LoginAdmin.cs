using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.TestSetup;
using CoreFramework.APICore;
using NUnit.Framework;
using RookiesTest.TestSetup;
using Scenario_Team1_Auto.DAO;


namespace Scenario_Team1_Auto.TestCase.Admin
{
    [TestFixture]
    public class LoginAdmin : ProjectNUnitTestSetup
    {
        [Test]
        public void TestCase()
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);

            string userName = Constant.Admin_UserName;
            string password = Constant.Admin_Password;
            string newPassword = Constant.Admin_New_Password;

            // Login with default password
            loginPage.Login(userName, password);

            // Verify authority of admin
            homePage.VerifyAccessAuthority();

            // Change password
            homePage.ChangePassword(password,newPassword);

            // Login with newpassword 
            loginPage.Login(userName, newPassword);


            // Logout and reset password
            homePage.ChangePassword(newPassword, password);
            loginPage.Login(userName, password);
            homePage.Logout();
        }
    }
}
