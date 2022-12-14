using CoreFramework.NUnitTestSetup;
using NUnit.Framework;


namespace Scenario_Team1_Auto.TestSetup
{
    public class NashNUnitAPITestSetup : NUnitTestSetup
    {
        
        [SetUp]
        public void SetUp()
        {
            driverBaseAction.GoToURL(Constant.BASE_HOST);
        }

        [TearDown]

        public void TearDown()
        {

        }
    }
}
