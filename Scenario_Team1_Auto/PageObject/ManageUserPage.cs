using CoreFramework.DriverCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject
{
    public class ManageUserPage : WebDriverAction
    {
        public ManageUserPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly string detaiPopup = "//div[contains(text(),'Detailed User Information')]";
        private readonly string listUser = "//div[@id='root']//tr[@class='ant-table-row ant-table-row-level-0']";
        private readonly string pageTitle = "//div[contains(text(),'Manage Users')]";

        private readonly string tableUser = "//div[@class='ant-table']";
        private readonly string rowUser = "//td[@class='ant-table-cell'][1]";
        private readonly string detailUser = "//div[@class='ant-modal-content']";
        private readonly string findByType = "//input[@class='ant-select-selection-search-input']";
        private readonly string typeAdmin = "//div[@title='Admin']";
        private readonly string displayType = "//td[text()='ADMIN']";
        private readonly string findByText = "//input[@placeholder='Search']";
        private readonly string findText = "Vang Do Van";
        private readonly string btnSearch = "//button[@class='ant-btn ant-btn-default ant-btn-icon-only ant-input-search-button']";
        private readonly string textFullname = "//td[text()='Vang Do Van']";
        private readonly string btnCreate = "//button[@class='ant-btn ant-btn-default ant-btn-dangerous']//span[text()='Create new user']";
        private readonly string inputFirstName = "//input[@placeholder='First Name']";
        private readonly string inputLastName = "//input[@placeholder='Last Name']";
        private readonly string inputDOB = "//input[@id='create-new-user_birthday']";
        private readonly string genderMale = "//input[@value='MALE']";
        private readonly string genderFemale = "//input[@value='FEMALE']";
        private readonly string inputJoinDate = "//input[@id='create-new-user_joinedDate']";
        private readonly string selectType = "//input[@id='rc_select_14']";
        private readonly string selectTypeAdmin = "//div[text()='Admin']";
        private readonly string selectTypeStaff = "//div[text()='Staff']";
        private readonly string btnSave = "//span[contains(text(),'Save')]";
        private readonly string btnCancel = "//span[contains(text(),'Cancel')]";
        private readonly string firstName = "Tus";
        private readonly string lastName = "Nguyen";
        private readonly string dateOfBirth = "2000-01-01";
        private readonly string joinDate = "2022-07-12";

        private readonly string btnEdit = "//span[@aria-label='edit']";
        private readonly string edtDoB = "//input[@id='edit-asset_birthDate']";
        private readonly string edtJoinDate = "//input[@id='edit-asset_joinedDate']";
        private readonly string dropType = "//span[@aria-label='down']";
        private readonly string typeStaff = "//div[text()='Staff']";
        private readonly string btnSaveEdit = "//span[contains(text(),'Save')]";

        private readonly string btnDelete = "//span[@aria-label='close-circle']";
        private readonly string btnConfirmDel = "//span[text()='Delete']";
        public void VerifyManageUserPageDisplay()
        {
            IsElementDisplay(pageTitle);
        }
        public IList<IWebElement> GetUserList()
        {
            IList<IWebElement> randomUsers = FindElementsByXpath(listUser);
            return randomUsers;
        }
        public void GetDetailOfRandomUser()
        {
            IList<IWebElement> randomUsers = GetUserList();
            foreach (var user in randomUsers)
            {
                Console.WriteLine(user.Text);
            }
            var random = new Random();
            int index = random.Next(randomUsers.Count);
            Click(randomUsers[index]);
            TestContext.WriteLine(randomUsers[index].Text);
        }
        public void VerifyPopupDisplay()
        {
            IsElementDisplay(detaiPopup);
        }
        public void ViewUserPage()
        {
            IsElementDisplay(pageTitle);
            IsElementDisplay(tableUser);
            Clicks(rowUser);
            IsElementDisplay(detailUser);
        }
        public void SearchByTypeAdmin()
        {
            IsElementDisplay(findByType);
            //ClickAndSelect(findByType, typeAdmin);
            Thread.Sleep(2000);
            Clicks(findByType);
            Clicks(typeAdmin);
            IsElementNotDisplay("STAFF");
        }
        public void SearchByText()
        {
            IsElementDisplay(findByText);
            SendKey(findByText, findText);
            Clicks(btnSearch);
            IsElementNotDisplay(textFullname);
        }
        public void CreateNewUser()
        {
            Clicks(btnCreate);
            IsElementDisable(btnSave);
            SendKey(inputFirstName, firstName);
            SendKey(inputLastName, lastName);
            Clicks(genderMale);
            Clicks(selectType);
            Clicks(selectTypeStaff);
            SendKey(inputDOB, dateOfBirth);
            SendKey(inputJoinDate, joinDate);
            //ClickAndSelect(selectType, selectTypeStaff);
            IsElementEnable(btnSave);
            Clicks(btnSave);
        }
        public void CancelCreateNewUser()
        {
            Clicks(btnCreate);
            IsElementDisplay(btnCancel);
            Clicks(btnCancel);
        }
        public void EditUser()
        {
            IsElementDisplay(btnEdit);
            Clicks(btnEdit);
            //Clicks(dropType);
            //Clicks(typeStaff);
            //ClickAndSelect(dropType, typeStaff);
            IsElementDisplay(btnSaveEdit);
            Clicks(btnSaveEdit);
        }
        public void DeleteUser()
        {
            IsElementDisplay(btnDelete);
            Clicks(btnDelete);
            IsElementDisplay(btnConfirmDel);
            Clicks(btnConfirmDel);
        }
    }
}
