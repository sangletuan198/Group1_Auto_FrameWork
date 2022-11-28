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


            loginPage.Login(Constant.Admin_UserName, Constant.Admin_Password);
            homePage.VerifyAccessAuthority();
            homePage.ChangePassword("12345678");

        }

    }
}
