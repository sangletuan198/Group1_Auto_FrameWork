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
        private readonly String btnHomePage = "//a[@href='/homepage']"; 
        private readonly String btnRequestReturn = "//a[@href='/request-for-returning']";
        private readonly String btnReport = "//a[@href='/report']";

        private readonly String btnManageUser = "//a[@href='/manage-users']";
        private readonly String btnManageAssets = "//a[contains(text(),'Manage Assets')]";
        private readonly String btnManageAassignments = "//a[@href='/manage-assignments']";

        private readonly String btnChangePassword = "//a[contains(text(),'Change Password')]";         
        private readonly String btnLogout = "//a[contains(text(),'Logout')]";   

        private readonly String btnConfirmLogout = "//button[@class='ant-btn ant-btn-primary ant-btn-dangerous']//span[text ()='Log out']";

        private readonly String tfOldPassword = "//input[@placeholder='Old Password']";
        private readonly String tfNewPassword = "//input[@placeholder='New Password']";
        private readonly String btnSave = "//button[@type='submit']";

        private readonly String btnStaffAcptAss = "//button[@class='ant-btn ant-btn-default' and not(@disabled)][span[@class='anticon anticon-check']]";
        private readonly String btnStaffConfirmAcpt = "//span[text()='Accept']";
        private readonly String btnStaffCancelConfirmAcpt = "//span[text()='Cancel']";
        private readonly String btnStaffDeclineAss = "//button[@class='ant-btn ant-btn-default' and not(@disabled)]//span[@class='anticon anticon-close-circle']";
        private readonly String btnStaffReturnAss = "//button[@class='ant-btn ant-btn-default test' and not(@disabled)]//span[@class='anticon anticon-reload']";
        private readonly String btnStaffConfirmDecline = "//span[text () ='Decline']";
        private readonly String btnStaffCancelDecline = "//span[text () ='Cancel']";
        private readonly String btnStaffConfirmReturnAss = "//span[text () ='Yes']";
        private readonly String btnStaffCancelReturnAss = "//span[text () ='No']";


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
            Clicks(locator);
            Clicks(btnChangePassword);

            IsElementDisable(btnSave);

            SendKey(tfOldPassword, oldPassword);
            SendKey(tfNewPassword, newPassword);

            Clicks(btnSave);
        }
        public void Logout(string user)
        {
            Clicks("//span[contains(text(),'" + user + "')]");
            Clicks(btnLogout);
            Clicks(btnConfirmLogout);
        }
        public void GetAssetPage()
        {
            Clicks(btnManageAssets);
        }
       
        public void GetManageAssignmentsPage()
        {
            Clicks(btnManageAassignments);
        }

        public void GetReqForReturnPage()
        {
            Clicks(btnRequestReturn);
        }

        public void GetReportPage()
        {
            Clicks(btnReport);
        }

        public void GetManageUserPage()
        {
            Clicks(btnManageUser);
        }

        public void StaffAcptAssignment()
        {
            Clicks(btnStaffAcptAss);
            Clicks(btnStaffConfirmAcpt);
        }

        public void StaffCancelAcptAssignment()
        {
            Clicks(btnStaffAcptAss);
            Clicks(btnStaffCancelConfirmAcpt);
        }

        public void StaffDeclineAssignment()
        {
            Clicks(btnStaffDeclineAss);
            Clicks(btnStaffConfirmDecline);
        }

        public void StaffCancelDeclineAssignment()
        {
            Clicks(btnStaffDeclineAss);
            Clicks(btnStaffCancelDecline);
        }

        public void StaffReturnAssignment()
        {
            Clicks(btnStaffReturnAss);
            Clicks(btnStaffConfirmReturnAss);
        }

        public void StaffCancelReturnAssignment()
        {
            Clicks(btnStaffReturnAss);
            Clicks(btnStaffCancelReturnAss);
        }

    }
}
