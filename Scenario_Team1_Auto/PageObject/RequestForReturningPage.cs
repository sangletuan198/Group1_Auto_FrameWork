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
    public class RequestForReturningPage : WebDriverAction
    {
        public RequestForReturningPage(IWebDriver driver) : base(driver)
        {
        }
        public string pageTitle = "//div[text()='Request For Returning']";
        public string findByState = "//span[@class='ant-select-selection-search']";
        public string stateAll = "//div[div[text () ='ALL']]";
        public string stateComplete = "//div[div[text () ='Completed']]";
        public string stateWaiting = "//div[div[text () ='Waiting For Returning']]";
        public string findByText = "//span[@class='ant-input-clear-icon ant-input-clear-icon-hidden']";
        public string text = "tuandv";
        public string foundText = "//td[text()='tuandv']";
        public string btnSearch = "//button[@class='ant-btn ant-btn-default ant-btn-icon-only ant-input-search-button']";
        public string findByReturnDate = "//input[@id='datepicker']";

        public string btnAdminAcptReturnAss = "//button[@class='ant-btn ant-btn-default' and not(@disabled)][span[@class='anticon anticon-check']]";
        public string btnAdminCancelReturnAss = "(//span[@aria-label='close-circle'])[2]";
        public string btnAdminConfirmAcceptReturn = "//span[text () ='Yes']";
        public string btnAdminCancelConfirmAcceptReturn = "//span[text () ='No']";
        public string btnAdminConfirmCancelReturnAss = "//span[text () ='Yes']";
        public string btnAdminCancelConfirmCancelReturnAss = "//span[text () ='No']";

        public void VerifyReturnPageDisplay()
        {
            IsElementDisplay(pageTitle);
        }

        public void ReturnPageSearchByStateComplete()
        {
            IsElementDisplay(findByState);
            //ClickAndSelect(findByType, typeAdmin);
            Thread.Sleep(2000);
            Clicks(findByState);
            Clicks(stateComplete);
            IsElementNotDisplay("WAITING_FOR_RETURNING");
        }
        public void ReturnPageSearchByStateWaiting()
        {
            Clicks(findByState);
            Clicks(stateWaiting);
        }
        public void ReturnPageSearchByText()
        {
            IsElementDisplay(findByText);
            SendKey(findByText, text);
            Clicks(btnSearch);
            IsElementNotDisplay(foundText);
        }
        public void AdminConfirmReturn()
        {
            Clicks(btnAdminAcptReturnAss);
            Clicks(btnAdminConfirmAcceptReturn);
        }

        public void AdminCancelConfirmReturn()
        {
            ReturnPageSearchByStateWaiting();
            IsElementEnable(btnAdminCancelReturnAss);
            Clicks(btnAdminCancelReturnAss);
            Clicks(btnAdminCancelConfirmAcceptReturn);
        }

        public void AdminConfirmCancelReturn()
        {
            ReturnPageSearchByStateWaiting();
            IsElementEnable(btnAdminCancelReturnAss);
            Clicks(btnAdminCancelReturnAss);
            Clicks(btnAdminCancelConfirmAcceptReturn);
        }

        public void AdminCancelConfirmCancelReturn()
        {
            ReturnPageSearchByStateWaiting();
            IsElementEnable(btnAdminCancelReturnAss);
            Clicks(btnAdminCancelReturnAss);
            Clicks(btnAdminCancelConfirmCancelReturnAss);
        }
    }
}