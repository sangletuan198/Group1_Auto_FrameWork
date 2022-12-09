using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Scenario_Team1_Auto.DAO;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string btnCreateNewAssign = "//span[contains(text(),'Create new assignment')]";
        public string createNewAssignPageTitle = "//div[contains(text(),'Manage Assignment > Create New Assignment')]";
        public string btnSelectAssignmentUser = "//label[@title='User']/parent::div/following-sibling::div/div/div/div/div/span/input";
        public string btnEditAssignmentUser = "//label[@title='User']/parent::div/following-sibling::div/div/div/div/div/span/input";
        public string btnSelectAssignmentAsset = "//input[@id='create-new-assignment_assetId']";
        public string btnEditAssignmentAsset = "//input[@id='create-new-assignment_assetId']";
        public string CreateAssignDate = "create-new-assignment_assignDate";
        public string btnSaveNewAssignment = "//button[@type='submit']";
        public string dropdownUser = "//label[@title='User']/parent::div/following-sibling::div/div/div/div/div/span[2]";
        public string noteAssign = "//textarea[@id='create-new-assignment_assignNote']";


        public void VerifyManageAssignmentsPageDisplay()
        {
            IsElementDisplay(pageTitle);
        }


        public IList<IWebElement> GetAssignmentList()
        {
            IList<IWebElement> randomAssignment = FindElementsByXpath(listAssignment);
            return randomAssignment;
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
            SendKey(btnSelectAssignmentUser, "Vang Do Van");
            SendKey(btnSelectAssignmentUser, Keys.Enter);
            Thread.Sleep(2000);
            SendKey(btnSelectAssignmentAsset, "laptop dell XPS 13");
            SendKey(btnSelectAssignmentAsset, Keys.Enter);
            RemoveReadonlyAndSendKeysAssignDate(CreateAssignDate, "2022-12-09");
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
            SendKey(btnSelectAssignmentUser, "Vang Do Van");
            SendKey(btnSelectAssignmentUser, Keys.Enter);
            Thread.Sleep(2000);
            SendKey(noteAssign, "test add assign edit");
            SendKey(noteAssign, Keys.Enter);
            Thread.Sleep(2000);
            Clicks(btnSaveNewAssignment);
            Thread.Sleep(2000);

        }

        public void DeleteAssignment()
        {
            Clicks(deleteAssign);
            Thread.Sleep(2000);
            Clicks(confirmDeleteAssign);
            Thread.Sleep(2000);

        }
    }
}
