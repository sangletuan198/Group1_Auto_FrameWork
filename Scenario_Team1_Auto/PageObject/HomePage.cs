using CoreFramework.DriverCore;
using OpenQA.Selenium;
using Scenario_Team1_Auto.TestSetup;
using System;
using System.Collections.Generic;
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
        private readonly String btnHomePage = "//a[@href='/homepage']"; // homepage for staff
        private readonly String adminAssignList = "//table[@style='table-layout: auto;']";
        private readonly String btnRequestReturn = "//a[@href='/request-for-returning']";
        private readonly String btnReport = "//a[@href='/report']";

        private readonly String btnManageUser = "//a[@href='/manage-users']";
        private readonly String btnManageAssets = "//a[contains(text(),'Manage Assets')]";
        private readonly String btnManageAassignments = "//a[@href='/manage-assignments']";

        private readonly String btnChangePassword = "//a[contains(text(),'Change Password')]";         
        private readonly String btnLogout = "//a[contains(text(),'Logout')]";   

        private readonly String btnConfirmLogout = "//button[@class='ant-btn ant-btn-primary ant-btn-dangerous']";

        private readonly String tfOldPassword = "//input[@placeholder='Old Password']";
        private readonly String tfNewPassword = "//input[@placeholder='New Password']";
        private readonly String btnSave = "//button[@type='submit']";

        private readonly String btnStaffAcptAss = "//button[@class='ant-btn ant-btn-default tick-icon' and not(@disabled)][span[@class='anticon anticon-check']]";
        private readonly String btnStaffConfirmAcpt = "//span[text()='Accept']";
        private readonly String btnStaffCancelConfirmAcpt = "//span[text()='Cancel']";
        private readonly String btnStaffDeclineAss = "//button[@class='ant-btn ant-btn-default' and not(@disabled)]//span[@class='anticon anticon-close-circle']";
        private readonly String btnStaffReturnAss = "//button[@class='ant-btn ant-btn-default test' and not(@disabled)]//span[@class='anticon anticon-reload']";
        private readonly String btnStaffConfirmDecline = "//span[text () ='Decline']";
        private readonly String btnStaffCancelDecline = "//span[text () ='Cancel']";
        private readonly String btnStaffConfirmReturnAss = "//span[text () ='Yes']";
        private readonly String btnStaffCancelReturnAss = "//span[text () ='No']";

        private readonly String btnRequestForReturning = "//a[(text()='Request For Returning')]";


        private readonly String firstAsset = "//tbody/tr[1]/td[1]";



        private readonly String acceptedTickIcon = "//td[contains(text(),'Accepted')]//following::td[1]//span[@aria-label='check']";
        private readonly String waitingForAcceptTickIcon = "//td[contains(text(),'Waiting For Acceptance')]//following::td[1]//span[@aria-label='check']";

        private readonly String waitingForAcceptXIcon = "//td[contains(text(),'Waiting For Acceptance')]//following::td[1]//span[@aria-label='close-circle']";
        private readonly String returnIcon = "//tbody/tr[1]//span[@aria-label='reload']";

        private readonly String waitingForAcceptReturnIcon = "//td[contains(text(),'Waiting For Acceptance')]//following::td[1]//span[@aria-label='reload']";
        private readonly String acceptedReturnIcon = "//td[contains(text(),'Accepted')]//following::td[1]//span[@aria-label='reload']";

        private readonly String btnAccept = "//span[contains(text(),'Accept')]";
        private readonly String btnDecline = "//span[text()='Decline']";
        private readonly String btnYes = "//span[contains(text(),'Y')]";

        public void VerifyAdminAssignList()
        {
            IsElementDisplay(adminAssignList);
        }
        public void VerifyAdminAccessAuthority()
        {
            IsElementDisplay(btnHome);
            IsElementDisplay(btnManageUser);
            IsElementDisplay(btnManageAssets);
            IsElementDisplay(btnManageAassignments);
        }
        public void VerifyStaffAccessAuthority()
        {
            IsElementDisplay(btnHomePage);
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
        public void GetReqForReturnPage()
        {
            Click(btnRequestReturn);
        }

        public void GetReportPage()
        {
            Click(btnReport);
        }
        public void StaffAcptAssignment()
        {
            Click(btnStaffAcptAss);
            Click(btnStaffConfirmAcpt);
        }

        public void StaffCancelAcptAssignment()
        {
            Click(btnStaffAcptAss);
            Click(btnStaffCancelConfirmAcpt);
        }

        /*public void StaffDeclineAssignment()
        {
            Click(btnStaffDeclineAss);
            Click(btnStaffConfirmDecline);
        }*/

        public void StaffCancelDeclineAssignment()
        {
            Click(btnStaffDeclineAss);
            Click(btnStaffCancelDecline);
        }

        public void StaffReturnAssignment()
        {
            Click(btnStaffReturnAss);
            Click(btnStaffConfirmReturnAss);
        }

        public void StaffCancelReturnAssignment()
        {
            Click(btnStaffReturnAss);
            Click(btnStaffCancelReturnAss);
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

        public void StaffReturnAssignent()
        {
            Click(returnIcon);
            Click(btnYes);

        }

        public void Logout(string user)
        {
            string cfgUser = "//span[contains(text(),'" + user + "')]";
            Click(cfgUser);
            Click(btnLogout);
            Click(btnConfirmLogout);

        }

        public void GetRequestForReturningPage()
        {
            Click(btnRequestForReturning);
        }


        public IList<IWebElement> GetList(string button)
        {
            IList<IWebElement> randomButton = FindElementsByXpath(button);
            return randomButton;
        }
        public void ClickOnRandomButton(string button)
        {

            IList<IWebElement> randomButton = GetList(button);
            foreach (var buttons in randomButton)
            {
                Console.WriteLine(buttons.Text);
            }
            var random = new Random();
            int index = random.Next(randomButton.Count);
            Click(randomButton[index]);
            Console.WriteLine(randomButton[index].Text);

        }
        public void GetAssetCodeAndAcceptReturningRequest()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = new HomePage(driver);
            ReturnPage returnPage = new ReturnPage(driver);

            string assetCode = GetText(firstAsset);
            Logout(Constant.STAFF_USERNAME);
            loginPage.Login(Constant.ADMIN_USERNAME, Constant.ADMIN_PASSWORD);
            homePage.GetRequestForReturningPage();
            returnPage.SearchByStateWaitingAndAssetCode(assetCode);
            returnPage.AdminConfirmReturn();

        }
    }
}
