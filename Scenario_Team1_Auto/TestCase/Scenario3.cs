using NUnit.Framework;
using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.TestSetup;


namespace Scenario_Team1_Auto.TestCase
{
    [TestFixture]
    public class Scenario3 : NashNUnitAPITestSetup
    {
        [Test]
        public void StaffReturnsAsset()
        {
            LoginPage loginPage = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);  

            loginPage.Login(Constant.STAFF_USERNAME, Constant.STAFF_PASSWORD);

            homePage.VerifyStaffAccessAuthority();

            
            homePage.VerifyTickIconEnable();
            homePage.VerifyXIconEnable();
            homePage.VerifyReturnIconDisable();

            homePage.StaffAcceptAssignment();

            homePage.VerifyReturnIconEnable();
            homePage.VefiryTickIconDisable();

            homePage.StaffDeclineAssignment();

            homePage.StaffReturnAssignent();

            homePage.Logout(Constant.STAFF_USERNAME);
        }
    }
}
