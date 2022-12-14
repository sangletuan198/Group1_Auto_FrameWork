using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject
{
    public class RequestReturningPage : WebDriverAction
    {
        public RequestReturningPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly string pageTitle = "//div[text()='Request For Returning']";
        private readonly string findByState = "//input[@class='ant-select-selection-search-input']";
        private readonly string stateComplete = "//div[text()='COMPLETED']";
        private readonly string stateWaiting = "//div[text()='WAITING FOR RETURNING']";
        private readonly string findByText = "//span[@class='ant-input-clear-icon ant-input-clear-icon-hidden']";
        private readonly string text = "quynhct";
        private readonly string foundText = "//td[text()='quynhct']";
        private readonly string btnSearch = "//button[@class='ant-btn ant-btn-default ant-btn-icon-only ant-input-search-button']";
        private readonly string findByReturnDate = "//input[@id='datepicker']";

        private readonly string btnComplete = "//span[@aria-label='check']";
        private readonly string btnYes = "//span[text()='Yes']";


        public void ViewPage()
        {
            IsElementDisplay(pageTitle);
        }
        public void SearchByStateComplete()
        {
            IsElementDisplay(findByState);
            //ClickAndSelect(findByType, typeAdmin);
            Thread.Sleep(2000);
            Click(findByState);
            Click(stateComplete);
            IsElementNotDisplay("WAITING_FOR_RETURNING");
        }
        public void SearchByStateWaiting()
        {
            IsElementDisplay(findByState);
            //ClickAndSelect(findByType, typeAdmin);
            Thread.Sleep(2000);
            Click(findByState);
            Click(stateWaiting);
        }
        public void SearchByText()
        {
            IsElementDisplay(findByText);
            SendKey(findByText, text);
            Click(btnSearch);
            IsElementNotDisplay(foundText);
        }
        public void CompleteRequest()
        {
            SearchByStateWaiting();
            IsElementEnable(btnComplete);
            Click(btnComplete);
            Click(btnYes);
        }

    }
}
