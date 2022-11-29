using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
        public string btnCreateNewAsset = "//span[contains(text(),'Create new asset')]";

        public string assignmentRow = "//tr[@data-row-key='1']";
        //tr[@data-row-key='1']/td[8]/preceding-sibling::td

        public void isManageAssignmentsPageDisplay()
        {
            IsElementDisplay(pageTitle);
        }
        public void getAssignmentPopup()
        {
            Clicks(assignmentRow);
        }


    }
}
