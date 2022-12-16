using CoreFramework.DriverCore;
using OpenQA.Selenium;
using Scenario_Team1_Auto.TestData;

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
        private readonly string closeViewDetail = "//span[@aria-label='close']";

        private readonly string findByType = "//input[@class='ant-select-selection-search-input']";
        private readonly string typeAdmin = "//div[@title='Admin']";

        private readonly string searchBox = "//input[@placeholder='Search']";
        private readonly string txtFullname = "Vang Do Van";
        private readonly string txtStaffCode = "SD0002";
        private readonly string delText = "//span[@class='anticon anticon-close-circle']";
        private readonly string btnSearch = "//button[@class='ant-btn ant-btn-default ant-btn-icon-only ant-input-search-button']";
        private readonly string resultFullname = "//td[text()='Vang Do Van']";
        private readonly string resultStaffcode = "//td[text()='SD0002']";

        private readonly string btnCreate = "//button[@class='ant-btn ant-btn-default ant-btn-dangerous']//span[text()='Create new user']";
        private readonly string inputFirstName = "//input[@placeholder='First Name']";
        private readonly string inputLastName = "//input[@placeholder='Last Name']";
        private readonly string inputDOB = "//input[@id='create-new-user_birthday']";
        private readonly string genderMale = "//input[@value='MALE']";
        private readonly string inputJoinDate = "//input[@id='create-new-user_joinedDate']";
        private readonly string joinToday = "//a[@class='ant-picker-today-btn']";
        private readonly string selectType = "//div[@class='ant-select ant-select-in-form-item ant-select-single ant-select-show-arrow']";
        private readonly string selectTypeStaff = "//div[text()='Staff']";
        private readonly string selectTypeAdmin = "//div[text()='Admin']";
        private readonly string btnSave = "//span[contains(text(),'Save')]";
        private readonly string btnCancel = "//span[contains(text(),'Cancel')]";

        private readonly string btnEdit = "//span[@aria-label='edit']";
        private readonly string btnSaveEdit = "//span[contains(text(),'Save')]";

        private readonly string btnDelete = "(//span[@aria-label='close-circle'])[2]";
        private readonly string btnConfirmDel = "//span[text()='Delete']";
        public void VerifyManageUserPageDisplay()
        {
            IsElementDisplay(pageTitle);
        }
       
        public void VerifyPopupDisplay()
        {
            IsElementDisplay(detaiPopup);
        }
        public void ViewUserPage()
        {
            IsElementDisplay(pageTitle);
            IsElementDisplay(tableUser);
            Click(rowUser);
            IsElementDisplay(detailUser);
            Click(closeViewDetail);
        }
        public void SearchByType()
        {
            IsElementDisplay(findByType);
            Thread.Sleep(2000);
            Click(findByType);
            Click(typeAdmin);
        }
        public void SearchByText()
        {
            IsElementDisplay(searchBox);
            SendKey(searchBox, txtFullname);
            Click(btnSearch);
            IsElementDisplay(resultFullname);
            Click(delText);
            SendKey(searchBox, txtStaffCode);
            Click(btnSearch);
            IsElementDisplay(resultStaffcode);
            Click(delText);
        }
        public void CreateNewUser()
        {
            Click(btnCreate);
            SendKey(inputFirstName, User.FirstName);
            SendKey(inputLastName, User.LastName);
            Click(genderMale);
            Click(selectType);
         
            Click(selectTypeStaff);
            Click(inputJoinDate);
            
            Click(joinToday);
           
            RemoveReadonlyAndSendKeys(inputDOB, User.DoB);
            IsElementEnable(btnSave);
            
            Click(btnSave);
            IsElementDisplay("//td[text()='Tu Nguyen']");
        }
        public void CancelCreateNewUser()
        {
            Click(btnCreate);
            IsElementDisplay(btnCancel);
            Click(btnCancel);
        }
        public void EditUser()
        {
            IsElementDisplay(btnEdit);
            Click(btnEdit);
            Click(selectType);
            
            Click(selectTypeAdmin);
            IsElementDisplay(btnSaveEdit);
            Click(btnSaveEdit);
        }
        public void DeleteUser()
        {
            IsElementDisplay(btnDelete);
            
            Click(btnDelete);
            IsElementDisplay(btnConfirmDel);
            
            Click(btnConfirmDel);
            //IsElementNotDisplay("//td[text()='Tu Nguyen']");
        }
    }
}
