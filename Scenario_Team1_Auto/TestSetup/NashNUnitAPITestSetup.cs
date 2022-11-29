using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.Services;
using Scenario_Team1_Auto.TestSetup;

namespace Scenario_Team1_Auto.TestSetup
{
    public class NashNUnitAPITestSetup : NUnitTestSetup
    {
        public NashUserDAO user;
        public AssetService assetService;

        [SetUp]
        public void SetUp()
        {
            NashAuthorizationService nashAuthorizationService = new NashAuthorizationService();
            assetService = new AssetService();
            user = nashAuthorizationService.Login(Constant.NASH_USERNAME, Constant.NASH_PASSWORD);
        }
        [TearDown]
        public void TearDown()
        {
        }
    }
}
