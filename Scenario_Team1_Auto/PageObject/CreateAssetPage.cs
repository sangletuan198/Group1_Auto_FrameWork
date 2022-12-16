using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject
{
    public class CreateAssetPage : WebDriverAction
    {
        public CreateAssetPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly string tfAssetName = "//input[@placeholder='Asset Name']";
        private readonly string dlCategory = " //input[@id='create-new-asset_category']";
        private readonly string tfSpecifications = " //textarea[@placeholder='Specifications']";
    }

}
