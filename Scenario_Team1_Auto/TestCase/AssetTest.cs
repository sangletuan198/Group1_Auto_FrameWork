using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.TestSetup;

namespace Scenario_Team1_Auto.TestCase
{
    [TestFixture]
    public class AssetTest : NashNUnitAPITestSetup
    {
        [Test]
        public void ListAssetTest()
        {
            AssetsDAO expectedAssets = assetService.GetAssets(user.accessToken);
            TestContext.WriteLine(expectedAssets.content[1].state);
            
        }
    }
}
