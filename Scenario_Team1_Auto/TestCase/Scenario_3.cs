using NUnit.Framework;
using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.TestSetup;

namespace Scenario_Team1_Auto.TestCase
{
    [TestFixture]
    public class Scenario_3 : NashNUnitAPITestSetup
    {
        [Test]
        public void Scenario3()
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ReturnPage returnPage = new ReturnPage(_driver);

            loginPage.Login(Constant.STAFF_USERNAME2, Constant.STAFF_PASSWORD2);
           
            homePage.VerifyTickIconEnable();

            homePage.VerifyXIconEnable();

            homePage.VerifyReturnIconDisable();

            homePage.StaffAcceptAssignment();

            homePage.VerifyReturnIconEnable();

            homePage.VefiryTickIconDisable();

            homePage.StaffDeclineAssignment();

            homePage.GetAssetCodeAndAcceptReturningRequest();

            homePage.Logout(Constant.ADMIN_USERNAME);
        }
    }
}
