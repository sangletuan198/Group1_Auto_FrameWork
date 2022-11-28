using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.TestSetup;
using CoreFramework.APICore;
using NUnit.Framework;
using RookiesTest.TestSetup;
using Scenario_Team1_Auto.DAO;


namespace RookiesTest.APITest
{
    [TestFixture]
    public class Login : ProjectNUnitTestSetup
    {
        [Test]
        public void TestCase()
        {
            LoginPage loginPage = new LoginPage(_driver);

            loginPage.SendKeyLogin();
        }

    }
}
