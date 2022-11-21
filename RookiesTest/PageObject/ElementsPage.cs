using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;
using Scenario.TestSetData;
using Scenario1.DAO;
using Scenario1.TestSetup;

namespace RookiesTest2.PageObject
{
    public class ElementsPage : WebDriverAction
    {
        public ElementsPage(IWebDriver driver) : base(driver)
        {
        }
        public readonly String baseUrl = Constant.baseUrl;
        public readonly String tfWebTables = "//*[@class='text'][text()='Web Tables']";
        public readonly String mainHeader = "//*[@class='main-header']";



        public readonly String addButton = "//*[@id='addNewRecordButton']";
        public readonly String submitButton = "//*[@id='submit']";
        public readonly String editButton = "//*[@class='rt-tr-group'][@role='rowgroup'][3]/div/div[7]/div/span";

        public readonly String tfFirstName = "//*[@id='firstName']";
        public readonly String tfLastName = "//*[@id='lastName']";
        public readonly String tfEmail = "//*[@id='userEmail']";
        public readonly String tfAge = "//*[@id='age']";
        public readonly String tfSalary = "//*[@id='salary']";
        public readonly String tfDepartment = "//*[@id='department']";

        public List<RecordRow> testRecords = new List<RecordRow>();
        public List<RecordRow> testRecords2 = new List<RecordRow>();
        public List<RecordRow> testRecords3 = new List<RecordRow>();



        public void GetEWebTable()
        {
            Clicks(tfWebTables);
        }


        public void VerifyUrl()
        {
            try
            {
                Assert.AreEqual(baseUrl + "elements", getUrl());
                TestContext.WriteLine("Url is correct");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Url is incorrect");
                throw ex;
            }
        }


        public Boolean VerifyPagePresent()
        {
            IsElementDisplay(mainHeader);
            return true;
        }

        public void ClickAddButton()
        {
            Clicks(addButton);
        }


        public void ClickEditButton()
        {
            Clicks(editButton);
        }



        /*-----------------------Table Helper-----------------------*/
        public RecordRow? GetUserInfo(int a)
        {
            IList<IWebElement> UserInfo = FindElementsByXpath("//*[@class='rt-tr-group'][@role='rowgroup'][" + a + "]/div/div[7]/preceding-sibling::div");
            if (UserInfo.Count == 0)
            {
                return null;
            }

            TestContext.WriteLine("FirstName is " + UserInfo[0].Text);
            TestContext.WriteLine("LastName is " + UserInfo[1].Text);
            TestContext.WriteLine("Age is " + UserInfo[2].Text);
            TestContext.WriteLine("Email is " + UserInfo[3].Text);
            TestContext.WriteLine("Salary is " + UserInfo[4].Text);
            TestContext.WriteLine("Department is " + UserInfo[5].Text);
            return new RecordRow(UserInfo[0].Text, UserInfo[1].Text, UserInfo[2].Text, UserInfo[3].Text, UserInfo[4].Text, UserInfo[5].Text);
        }

        public List<RecordRow> GetTableRowsFromWebPage(int a)
        {
            List<RecordRow> tableRows = new List<RecordRow>();
            int i = 1;
            while (i < a)
            {
                tableRows.Add(GetUserInfo(i));
                i++;
            }
            return tableRows;
        }
        public sealed class RecordRowComparator : Comparer<RecordRow>
        {
            public override int Compare(RecordRow? x, RecordRow? y)
            {
                var compareResult = String.Equals(x?.FirstName, y?.FirstName) &&
                    String.Equals(x?.LastName, y?.LastName) &&
                    String.Equals(x?.Age, y?.Age) &&
                    String.Equals(x?.Email, y?.Email) &&
                    String.Equals(x?.Salary, y?.Salary) &&
                    String.Equals(x?.Department, y?.Department);
                if (compareResult)
                {
                    return 0;
                }
                return 1;
            }
        }
        /*------------------------ Handle table 1----------------------*/


        public void CreateTestSetData()   //  tao ra 3 cai row de test
        {
            TestSetData1 testSetData1 = new TestSetData1();
            testSetData1.CreateTestRows();
            testRecords = testSetData1.testRows;
        }
        public void EvaluateTableRowsWithTestSetData(int a)
        {
            var tableRows = GetTableRowsFromWebPage(a);
            CollectionAssert.AreEqual(tableRows, testRecords, new RecordRowComparator());

        }
        /*---------------------- Handle table 3------------------------*/


        public void CreateTestSetData2()   //  tao ra 3 cai row de test
        {
            TestSetData2 testSetData2 = new TestSetData2();
            testSetData2.CreateTestRows();
            testRecords2 = testSetData2.testRows;
        }
        public void InputNewValidUserInfo()
        {
            var row = testRecords2.ElementAt(3);

            SendKeys_(tfFirstName, row.FirstName);
            SendKeys_(tfLastName, row.LastName);
            SendKeys_(tfEmail, row.Email);
            SendKeys_(tfAge, row.Age);
            SendKeys_(tfSalary, row.Salary);
            SendKeys_(tfDepartment, row.Department);
            Clicks(submitButton);
        }
        public void EvaluateTableRowsWithTestSetData2(int a)
        {
            var tableRows = GetTableRowsFromWebPage(a);
            CollectionAssert.AreEqual(tableRows, testRecords2, new RecordRowComparator());
        }
        /*----------------------- Handle table 3 -----------------------*/

        public void CreateTestSetData3()
        {
            TestSetData3 testSetData3 = new TestSetData3();
            testSetData3.CreateTestRows();
            testRecords3 = testSetData3.testRows;
        }
        public void EditUser()
        {
            var row = testRecords3.ElementAt(2);

            Replace(tfFirstName, row.FirstName);
            Replace(tfLastName, row.LastName);
            Replace(tfEmail, row.Email);
            Replace(tfAge, row.Age);
            Replace(tfSalary, row.Salary);
            Replace(tfDepartment, row.Department);
            Clicks(submitButton);
        }
        public void EvaluateTableRowsWithTestSetData3(int a)
        {
            var tableRows = GetTableRowsFromWebPage(a);
            CollectionAssert.AreEqual(tableRows, testRecords3, new RecordRowComparator());
        }
    }
}