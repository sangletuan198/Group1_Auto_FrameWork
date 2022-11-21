using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using Scenario1.TestSetup;

namespace RookiesTest.TestSetup
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

