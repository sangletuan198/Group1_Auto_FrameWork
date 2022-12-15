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
            Click(closePopUpDetail);
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
            Click(randomAssignment[index]);
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
            Click(btnCreateNewAssign);

        }

        public void CreateNewAssignment()
        {
            SendKey(btnSelectAssignmentUser, "Tuan Do Van");
            SendKey(btnSelectAssignmentUser, Keys.Enter);
            SendKey(btnSelectAssignmentAsset, "Macbook Air M1 New");
            SendKey(btnSelectAssignmentAsset, Keys.Enter);
            Click(btnCreateAssignDate);
            Click(assignDate);
            SendKey(noteAssign, "test add assign");
            SendKey(noteAssign, Keys.Enter);
            Click(btnSaveNewAssignment);

        }

        public void EditAssignment()
        {
            Click(editAssign);
            SendKey(noteAssign, "test add assign edit");
            SendKey(noteAssign, Keys.Enter);
            Click(btnCreateAssignDate);
            Click(editAssignDate);
            Click(btnSaveNewAssignment);

        }

        public void CancelEditAssignment()
        {
            Click(editAssign);
            Click(btnCancelEditAssignment);

        }

        public void DeleteAssignment()
        {
            Click(deleteAssign);
            Click(confirmDeleteAssign);

        }

        public void CancelDeleteAssignment()
        {
            Click(deleteAssign);
            Click(cancelDeleteAssign);

        }

        public void SortByStateAll()
        {
            Click(stateFilter);
            Click(stateAll);
        }

        public void SortByStateAcpt()
        {
            Click(stateFilter);
            Click(stateAcpt);
        }

        public void SortByStateWait()
        {
            Click(stateFilter);
            Click(stateWaiting);
        }

        public void DateFilter()
        {
            Click(filterDate);
        }

        public void SearchFilter()
        {
            WaitForElementToBeClickable(driver, searchFilter, 30);
            SendKey(searchFilter, Assignment.txtAssignSearchName);
            Click(btnSearch);
        }

        public void AdminCreateReturnAssYes()
        {
            Click(btnAdminCreateReturnAss);
            Click(btnAdminConfirmReturnAss);
        }

        public void AdminCreateReturnAssNo()
        {
            Click(btnAdminCreateReturnAss);
            Click(btnAdminCancelReturnAss);
        }
    }
}
