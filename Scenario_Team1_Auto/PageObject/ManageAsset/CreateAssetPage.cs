using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject.ManageAsset
{
    public class CreateAssetPage : WebDriverAction
    {
        public CreateAssetPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly String tfAssetName = "//input[@placeholder='Asset Name']";
        private readonly String dlCategory = " //input[@id='create-new-asset_category']";
        private readonly String tfSpecifications = " //textarea[@placeholder='Specifications']";
    }

}
