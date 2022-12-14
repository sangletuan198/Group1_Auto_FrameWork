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
        private readonly String btnManageAassignments = "//a[@href='/manage-assignments']";

           
        private readonly String btnLogout = "//a[contains(text(),'Logout')]";   

        private readonly String btnConfirmLogout = "//button[@class='ant-btn ant-btn-primary ant-btn-dangerous']";

        private readonly String acceptedTickIcon = "//td[contains(text(),'Accepted')]//following::td[1]//span[@aria-label='check']";
        private readonly String waitingForAcceptTickIcon = "//td[contains(text(),'Waiting For Acceptance')]//following::td[1]//span[@aria-label='check']";

        private readonly String waitingForAcceptXIcon = "//td[contains(text(),'Waiting For Acceptance')]//following::td[1]//span[@aria-label='close-circle']";
        private readonly String returnIcon = "//tbody/tr[1]//span[@aria-label='reload']";

        private readonly String waitingForAcceptReturnIcon = "//td[contains(text(),'Waiting For Acceptance')]//following::td[1]//span[@aria-label='reload']";
        private readonly String acceptedReturnIcon = "//td[contains(text(),'Accepted')]//following::td[1]//span[@aria-label='reload']";

        private readonly String btnAccept = " //span[contains(text(),'Accept')]";
        private readonly String btnDecline = "//button[@class='ant-btn ant-btn-danger button-modal']";
        private readonly String btnYes = "//span[contains(text(),'Yes')]";

        
        public void VerifyStaffAccessAuthority()
        {
            IsElementDisplay(btnHome);
            IsElementNotDisplay(btnManageAassignments);
           
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
            Click(waitingForAcceptTickIcon);
            Click(btnAccept);
            RefreshPage();
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
            Click(waitingForAcceptXIcon);
            Click(btnDecline);
            RefreshPage();
        }

        public void StaffReturnAssignent()
        {
            Click(returnIcon);
            Click(btnYes);
            RefreshPage();
        }

        public void Logout(string user)
        {
            string cfgUser = "//span[contains(text(),'" + user + "')]";
            Click(cfgUser);
            Click(btnLogout);
            Click(btnConfirmLogout);
           
        }

    }
}
