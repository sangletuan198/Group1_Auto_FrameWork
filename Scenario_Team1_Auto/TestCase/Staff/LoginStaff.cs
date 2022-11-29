using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.TestSetup;
using CoreFramework.APICore;
using NUnit.Framework;
using RookiesTest.TestSetup;
using Scenario_Team1_Auto.DAO;


namespace Scenario_Team1_Auto.TestCase.Staff
{
    [TestFixture]
    public class LoginStaff : ProjectNUnitTestSetup
    {
        [Test]
        public void TestCase()
        {
            LoginPage loginPage = new LoginPage(_driver);

            loginPage.Login(Constant.Staff_UserName, Constant.Staff_Password);
        }

    }
}
