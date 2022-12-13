using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using Scenario_Team1_Auto.TestSetup;

namespace RookiesTest.TestSetup
{
    public class NUnitWebTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            driverBaseAction.GoToURL(Constant.BASE_URL);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
