using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject
{
    public class ReturnPage : WebDriverAction
    {
        public ReturnPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly string findByState = "//span[@class='ant-select-selection-search']";
        private readonly string stateWaiting = "//div[div[text () ='Waiting For Returning']]";

        private readonly string tfSearchByAssetCode = "//input[@placeholder='Search']";
        private readonly string btnSearch = " //span[@aria-label='search']";
        public string btnAdminAcptReturnAss = "//button[@class='ant-btn ant-btn-default' and not(@disabled)][span[@class='anticon anticon-check']]";
        public string btnAdminConfirmAcceptReturn = "//span[text () ='Yes']";
        public void SearchByStateWaitingAndAssetCode(string assetCode)
        {
            Click(findByState);
            Click(stateWaiting);
            SendKey(tfSearchByAssetCode,assetCode);
            Click(btnSearch);
        }
        public void AdminConfirmReturn()
        {
            Click(btnAdminAcptReturnAss);
            Click(btnAdminConfirmAcceptReturn);
        }
    }
}
