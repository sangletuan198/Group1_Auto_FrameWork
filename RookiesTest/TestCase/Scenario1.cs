using NUnit.Framework;
using NUnit.Framework.Internal;
using RookiesTest.TestSetup;
using RookiesTest2.PageObject;

namespace RookiesTest.TestCase
{
    public class Scenario1 : ProjectNUnitTestSetup
    {
        [Test]
        public void VerifyInformation()
        {
            HomePage homePage = new HomePage(_driver);
            ElementsPage elementsPage = new ElementsPage(_driver);

            homePage.GetElementsPage();
            elementsPage.VerifyUrl();
            elementsPage.GetEWebTable();
            elementsPage.VerifyPagePresent();

            elementsPage.CreateTestSetData();
            elementsPage.EvaluateTableRowsWithTestSetData(4);
        }
    }
}

