using NUnit.Framework;
using NUnit.Framework.Internal;
using RookiesTest.TestSetup;
using RookiesTest2.PageObject;

namespace RookiesTest.TestCase
{
    public class Scenario2 : ProjectNUnitTestSetup
    {
        [Test]
        public void CreateNewEmployee()
        {
            HomePage homePage = new HomePage(_driver);
            ElementsPage elementsPage = new ElementsPage(_driver);

            homePage.GetElementsPage();
            elementsPage.VerifyUrl();
            elementsPage.GetEWebTable();
            elementsPage.VerifyPagePresent();
            elementsPage.ClickAddButton();
            elementsPage.CreateTestSetData2();
            elementsPage.InputNewValidUserInfo();
            elementsPage.EvaluateTableRowsWithTestSetData2(5);
        }
    }
}

