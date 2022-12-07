using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject.ManageAsset
{
    public class ManageAssetPage : WebDriverAction
    {
        public ManageAssetPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly String btnCreateAssets = "//span[contains(text(),'Create new asset')]";
        public void GetCreateAssetPage()
        {
            Clicks(btnCreateAssets);
        }
        public void inputValidAssetInfo()
        {

        }
    }
}
