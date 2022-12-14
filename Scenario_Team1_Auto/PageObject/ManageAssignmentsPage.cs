using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;
using Scenario_Team1_Auto.TestData;

namespace Scenario_Team1_Auto.PageObject
{
    public class ManageAssignmentsPage : WebDriverAction
    {
        public ManageAssignmentsPage(IWebDriver driver) : base(driver)
        {
        }

        public string pageTitle = "//div[contains(text(),'Manage Assignment')]";
        public string btnState = "//input[@id='rc_select_12']";
        public string btnSelectDate = "//input[@id='datepicker']";
        public string tfSearchButton = "//input[@placeholder=\'Search\']";
        public string listAssignment = "//tr[@class='ant-table-row ant-table-row-level-0']";
        public string popupDetailAssignment = "//div[@class='ant-modal-header']";
        public string editAssign = "//button[span[@class='anticon anticon-edit']]";
        public string deleteAssign = "(//div[@class = 'ant-space-item'])[6]";
        public string confirmDeleteAssign = "//button[@class='ant-btn ant-btn-danger button-modal']";
        public string cancelDeleteAssign = "//button[@class='ant-btn button-modal']";
        public string closePopUpDetail = "//span[@class='anticon anticon-close ant-modal-close-icon']";

        public string btnCreateNewAssign = "//span[contains(text(),'Create new assignment')]";
        public string createNewAssignPageTitle = "//div[contains(text(),'Manage Assignment > Create New Assignment')]";
        public string btnSelectAssignmentUser = "//label[@title='User']/parent::div/following-sibling::div/div/div/div/div/span/input";
        public string btnEditAssignmentUser = "//label[@title='User']/parent::div/following-sibling::div/div/div/div/div/span/input";
        public string btnSelectAssignmentAsset = "//input[@id='create-new-assignment_assetId']";
        public string btnEditAssignmentAsset = "//input[@id='create-new-assignment_assetId']";
        public string btnCreateAssignDate = "//div[@class='ant-picker-input']";
        public string assignDate = "//td[@title='2022-12-20']";
        public string editAssignDate = "//td[@title='2022-12-23']";
        public string btnSaveNewAssignment = "//button[@type='submit']";
        public string btnCancelEditAssignment = "//button[@type='button']";
        public string dropdownUser = "//label[@title='User']/parent::div/following-sibling::div/div/div/div/div/span[2]";
        public string noteAssign = "//textarea[@id='create-new-assignment_assignNote']";

        public string stateFilter = "(//span[input])[1]";
        public string stateAll = "(//div[@title])[1]]";
        public string stateAcpt = "(//div[@title])[2]";
        public string stateWaiting = "(//div[@title])[3]";

        public string filterDate = "//div[@class='ant-picker-input']";
        public string searchFilter = "(//span[input])[2]";
        public string btnSearch = "//button[@class='ant-btn ant-btn-default ant-btn-icon-only ant-input-search-button']";

        public string btnAdminCreateReturnAss = "//button[@class='ant-btn ant-btn-default test' and not(@disabled)]";
        public string btnAdminConfirmReturnAss = "//span[text () ='Yes']";
        public string btnAdminCancelReturnAss = "//span[text () ='No']";

        public void VerifyManageAssignmentsPageDisplay()
        {
            IsElementDisplay(pageTitle);
        }


        public IList<IWebElement> GetAssignmentList()
        {
            IList<IWebElement> randomAssignment = FindElementsByXpath(listAssignment);
            return randomAssignment;
        }

        public void ClosePopUpDetailAssign()
        {
            Clicks(closePopUpDetail);
        }    

        public void GetDetailOfRandomAssignment()
        {
            IList<IWebElement> randomAssignment = GetAssignmentList();
            foreach (var assignment in randomAssignment)
            {
                Console.WriteLine(assignment.Text);
            }
            var random = new Random();
            int index = random.Next(randomAssignment.Count);
            Clicks(randomAssignment[index]);
            TestContext.WriteLine(randomAssignment[index].Text);
        }
        public void VerifyAssignmentPopupDisplay()
        {
            IsElementDisplay(popupDetailAssignment);
        }

        public void VerifyCreateNewAssignmentPageDisplay()
        {
            IsElementDisplay(createNewAssignPageTitle);
        }
        public void GetCreateNewAssignmentsPage()
        {
            Clicks(btnCreateNewAssign);

        }

        public void CreateNewAssignment()
        {
            SendKey(btnSelectAssignmentUser, "Tuan Do Van");
            SendKey(btnSelectAssignmentUser, Keys.Enter);
            Thread.Sleep(2000);
            SendKey(btnSelectAssignmentAsset, "Macbook Air M1 New");
            SendKey(btnSelectAssignmentAsset, Keys.Enter);
            Clicks(btnCreateAssignDate);
            Clicks(assignDate);
            Thread.Sleep(2000);
            SendKey(noteAssign, "test add assign");
            SendKey(noteAssign, Keys.Enter);
            Thread.Sleep(2000);
            Clicks(btnSaveNewAssignment);
            Thread.Sleep(2000);

        }

        public void EditAssignment()
        {
            Clicks(editAssign);
            Thread.Sleep(2000);
            SendKey(noteAssign, "test add assign edit");
            SendKey(noteAssign, Keys.Enter);
            Clicks(btnCreateAssignDate);
            Clicks(editAssignDate);
            Thread.Sleep(2000);
            Clicks(btnSaveNewAssignment);
            Thread.Sleep(2000);

        }

        public void CancelEditAssignment()
        {
            Clicks(editAssign);
            Thread.Sleep(2000);
            Clicks(btnCancelEditAssignment);
            Thread.Sleep(2000);

        }

        public void DeleteAssignment()
        {
            Clicks(deleteAssign);
            Thread.Sleep(2000);
            Clicks(confirmDeleteAssign);
            Thread.Sleep(2000);

        }

        public void CancelDeleteAssignment()
        {
            Clicks(deleteAssign);
            Thread.Sleep(2000);
            Clicks(cancelDeleteAssign);
            Thread.Sleep(2000);

        }

        public void SortByStateAll()
        {
            Clicks(stateFilter);
            Clicks(stateAll);
            Thread.Sleep(2000);
        }

        public void SortByStateAcpt()
        {
            Clicks(stateFilter);
            Clicks(stateAcpt);
            Thread.Sleep(2000);
        }

        public void SortByStateWait()
        {
            Clicks(stateFilter);
            Clicks(stateWaiting);
            Thread.Sleep(2000);
        }

        public void DateFilter()
        {
            Clicks(filterDate);
        }

        public void SearchFilter()
        {
            WaitForElementToBeClickable(driver, searchFilter, 30);
            SendKey(searchFilter, Assignment.txtAssignSearchName);
            Clicks(btnSearch);
            Thread.Sleep(2000);
        }

        public void AdminCreateReturnAssYes()
        {
            Clicks(btnAdminCreateReturnAss);
            Clicks(btnAdminConfirmReturnAss);
        }

        public void AdminCreateReturnAssNo()
        {
            Clicks(btnAdminCreateReturnAss);
            Clicks(btnAdminCancelReturnAss);
        }
    }
}
