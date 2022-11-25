using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.Services;
using Scenario_Team1_Auto.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.TestCase
{
    public class AssetTest : NashNUnitAPITestSetup
    {
        [Test]
        public void ListAssetTest()
        {
            AssetsDAO expectedAssets = assetService.GetAssets(user.accessToken);
            TestContext.WriteLine(expectedAssets.assets[0].assetId);
        }
    }
}
