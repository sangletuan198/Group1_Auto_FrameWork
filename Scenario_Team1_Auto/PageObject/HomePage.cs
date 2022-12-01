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
        private readonly String btnManageUser = "//a[@href='/manage-users']";
        private readonly String btnManageAssets = "//a[@href='/manage-assets']";
        private readonly String btnManageAassignments = "//a[@href='/manage-assignments']";
        
        private readonly String btnConfigUser = "//li[@role='none']";
        private readonly String btnChangePassword = "//div[contains(@style, 'position')]//li[1]";
        private readonly String btnLogout = "//div[contains(@style, 'position')]//li[2]";
        private readonly String btnConfirmLogout = "//button[@class='ant-btn ant-btn-primary ant-btn-dangerous']";

        private readonly String tfOldPassword = "//input[@placeholder='Old Password']";
        private readonly String tfNewPassword = "//input[@placeholder='New Password']";
        private readonly String btnSave = "//button[@type='submit']";

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
            IsElementNotDisplay(btnManageUser);
            IsElementNotDisplay(btnManageAssets);
            IsElementNotDisplay(btnManageAassignments);
        }

        public void ChangePassword(string oldPassword,string newPassword)
        {
            Clicks(btnConfigUser);
            Clicks(btnChangePassword);

            IsElementEnable(btnSave);

            SendKeys_(tfOldPassword, oldPassword);
            SendKeys_(tfNewPassword, newPassword);

            Clicks(btnSave);
        }
        public void Logout()
        {
            Clicks(btnConfigUser);
            Clicks(btnLogout);
            Clicks(btnConfirmLogout);
        }

        public void GetManageAassignmentsPage()
        {
            Clicks(btnManageAassignments);
        }
        public void GetManageUserPage()
        {
            Clicks(btnManageUser);
        }
    }
}
