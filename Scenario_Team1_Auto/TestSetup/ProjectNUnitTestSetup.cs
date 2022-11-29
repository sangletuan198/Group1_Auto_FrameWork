using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace Scenario_Team1_Auto.TestSetup
{
    public class ProjectNUnitTestSetup : NUnitTestSetup
    {

        [SetUp]
        public void SetUp()
        {
            _driver.Url = Constant.baseUrl;
        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}

