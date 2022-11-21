using NUnit.Framework;
using NUnit.Framework.Internal;
using RookiesTest.TestSetup;
using RookiesTest2.PageObject;

namespace RookiesTest.TestCase
{
    public class Scenario3 : ProjectNUnitTestSetup
    {
        [Test]
        public void UpdateAndDeleteEmployee()
        {
            HomePage homePage = new HomePage(_driver);
            ElementsPage elementsPage = new ElementsPage(_driver);

            homePage.GetElementsPage();
            elementsPage.VerifyUrl();
            elementsPage.GetEWebTable();
            elementsPage.VerifyPagePresent();
            elementsPage.ClickEditButton();
            elementsPage.CreateTestSetData3();
            elementsPage.EditUser();
            elementsPage.EvaluateTableRowsWithTestSetData3(4);
        }
    }
}

