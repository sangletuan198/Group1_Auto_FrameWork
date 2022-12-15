using CoreFramework.DriverCore;
using OpenQA.Selenium;
using Scenario_Team1_Auto.TestSetup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject
{
    public class HomePage : WebDriverAction 
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        private readonly String btnHome = "//a[@href='/home']";
        private readonly String btnManageUser = "//a[@href='/manage-users']";
        private readonly String btnManageAssets = "//a[contains(text(),'Manage Assets')]";
        private readonly String btnManageAassignments = "//a[@href='/manage-assignments']";

        private readonly String btnChangePassword = "//a[contains(text(),'Change Password')]";         
        private readonly String btnLogout = "//a[contains(text(),'Logout')]";   

        private readonly String btnConfirmLogout = "//button[@class='ant-btn ant-btn-primary ant-btn-dangerous']";

        private readonly String tfOldPassword = "//input[@placeholder='Old Password']";
        private readonly String tfNewPassword = "//input[@placeholder='New Password']";
        private readonly String btnSave = "//button[@type='submit']";



        private readonly String btnRequestForReturning = "//a[(text()='Request For Returning')]";


        private readonly String firstAsset = "//tbody/tr[1]/td[1]";



        private readonly String acceptedTickIcon = "//td[contains(text(),'Accepted')]//following::td[1]//span[@aria-label='check']";
        private readonly String waitingForAcceptTickIcon = "//td[contains(text(),'Waiting For Acceptance')]//following::td[1]//span[@aria-label='check']";

        private readonly String waitingForAcceptXIcon = "//td[contains(text(),'Waiting For Acceptance')]//following::td[1]//span[@aria-label='close-circle']";


        private readonly String returnIcon = "//td[contains(text(),'Accepted')]//following::td[1]//button[not(@disabled)]//span[@aria-label='reload']";
        private readonly String assetCodeOfReturn = "//ancestor::tr//td[1]";

        private readonly String waitingForAcceptReturnIcon = "//td[contains(text(),'Waiting For Acceptance')]//following::td[1]//span[@aria-label='reload']";
        private readonly String acceptedReturnIcon = "//td[contains(text(),'Accepted')]//following::td[1]//span[@aria-label='reload']";

        private readonly String btnAccept = "//span[contains(text(),'Accept')]";
        private readonly String btnDecline = "//span[text()='Decline']";
        private readonly String btnYes = "//span[text()='Yes']";






        public void VerifyAdminAccessAuthority()
        {
            IsElementDisplay(btnHome);
            IsElementDisplay(btnManageUser);
            IsElementDisplay(btnManageAssets);
            IsElementDisplay(btnManageAassignments);
        }
        public void VerifyStaffAccessAuthority()
        {
            IsElementDisplay(btnHome);
            IsElementNotDisplay(btnManageAassignments);
           
        }

        public void ChangePassword(string user,string oldPassword,string newPassword)
        { 
            string locator = "//span[contains(text(),'" + user + "')]";
            Click(locator);
            Click(btnChangePassword);

            IsElementDisable(btnSave);

            SendKey(tfOldPassword, oldPassword);
            SendKey(tfNewPassword, newPassword);

            Click(btnSave);
        }
        
        public void VerifyReturnIconDisable()
        {
            IsElementDisable(waitingForAcceptReturnIcon);

        }
        public void VerifyTickIconEnable()
        {
            IsElementEnable(waitingForAcceptTickIcon);

        }
        public void VerifyXIconEnable()
        {
            IsElementEnable(waitingForAcceptXIcon);

        }
        public void StaffAcceptAssignment()
        {
            ClickOnRandomButton(waitingForAcceptTickIcon);
            Click(btnAccept);
            
        }
        public void VerifyReturnIconEnable()
        {
            IsElementEnable(acceptedReturnIcon);


        }
        public void VefiryTickIconDisable()
        {
            IsElementDisable(acceptedTickIcon);

        }

        public void StaffDeclineAssignment()
        {
            ClickOnRandomButton(waitingForAcceptXIcon);
            Click(btnDecline);
          
        }

       
        public void Logout(string user)
        {
            string cfgUser = "//span[contains(text(),'" + user + "')]";
            Click(cfgUser);
            Click(btnLogout);
            Click(btnConfirmLogout);

        }

        public void GetAssetPage()
        {
            Click(btnManageAssets);
           
        }
       
        public void GetManageAassignmentsPage()
        {
            Click(btnManageAassignments);
        }
        public void GetManageUserPage()
        {
            Click(btnManageUser);
        }
        public void GetRequestForReturningPage()
        {
            Click(btnRequestForReturning);
        }

        public string StaffReturnAssignent()
        {
            Click(returnIcon);
            string assetCode = GetText(returnIcon + assetCodeOfReturn);
            Thread.Sleep(500);
            Click(btnYes);
            return assetCode;
        }

        public IList<IWebElement> GetList(string xpath)
        {
            IList<IWebElement> randomButton = FindElementsByXpath(xpath);
            return randomButton;
        }
        
        public IWebElement ClickOnRandomButton(string xpath)
        {

            IList<IWebElement> randomButton = GetList(xpath);
            foreach (var buttons in randomButton)
            {
                Console.WriteLine(buttons.Text);
            }
            var random = new Random();
            int index = random.Next(randomButton.Count);
            ClickReturnButtonAndGetAssetCode(0);
            Console.WriteLine(randomButton[index].Text);
            return randomButton[index];

        }

        public void GetAssetCodeAndAcceptReturningRequest()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = new HomePage(driver);
            ReturnPage returnPage = new ReturnPage(driver);

            string assetCode = StaffReturnAssignent();
            Logout(Constant.STAFF_USERNAME);
            loginPage.Login(Constant.ADMIN_USERNAME, Constant.ADMIN_PASSWORD);
            homePage.GetRequestForReturningPage();
            returnPage.SearchByStateWaitingAndAssetCode(assetCode);
            returnPage.AdminConfirmReturn();
           

        }
        public IList<IWebElement> GetValidRow()
        {
            return FindElementsByXpath("//td[contains(text(),'Accepted')]//following::td[1]//button[not(@disabled)]//ancestor::tr");
        }
        public IList<IWebElement> FindChildOfRow(IWebElement row)
        {
            IList<IWebElement> cells = row.FindElements(ByXpath("//*"));
            return cells;
        }
        public string GetAssetCode(IList<IWebElement> cells)
        {
            return cells[0].Text;
        }

        public IWebElement GetReturnButtonOfCell(IWebElement cell)
        {
            return cell.FindElement(ByXpath("//span[@aria-label='reload']"));
        }
        public void ClickReturnButtonAndGetAssetCode(int index)
        {
            var rows = GetValidRow();
            var row = rows[index];
            var cell = FindChildOfRow(row);
            var assetCode = GetAssetCode(cell);
            var returnButton = GetReturnButtonOfCell(cell[4]);

            Click(returnButton);

        }
    }

}
