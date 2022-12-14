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
        private readonly String titleHome = "//div[text()='Home']";
        private readonly String btnHome = "//a[@href='/home']";
        private readonly String btnHomePage = "//a[@href='/homepage']"; // homepage for staff
        private readonly String adminAssignList = "//table[@style='table-layout: auto;']";

        private readonly String btnManageUser = "//a[@href='/manage-users']";
        private readonly String btnManageAssets = "//a[contains(text(),'Manage Assets')]";
        private readonly String btnManageAassignments = "//a[@href='/manage-assignments']";
        private readonly String btnRequestFReturn = "//a[@href='/request-for-returning']";

        private readonly String btnChangePassword = "//a[contains(text(),'Change Password')]";         
        private readonly String btnLogout = "//a[contains(text(),'Logout')]";   

        private readonly String btnConfirmLogout = "//button[@class='ant-btn ant-btn-primary ant-btn-dangerous']";

        private readonly String tfOldPassword = "//input[@placeholder='Old Password']";
        private readonly String tfNewPassword = "//input[@placeholder='New Password']";
        private readonly String btnSave = "//button[@type='submit']";

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
        public void Logout(string user)
        {
            Click("//span[contains(text(),'" + user + "')]");
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
        public void GetReqForReturn()
        {
            Click(btnRequestFReturn);
        }
    }
}
