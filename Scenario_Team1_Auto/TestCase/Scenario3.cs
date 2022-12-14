using NUnit.Framework;
using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

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
        }
    }
}
