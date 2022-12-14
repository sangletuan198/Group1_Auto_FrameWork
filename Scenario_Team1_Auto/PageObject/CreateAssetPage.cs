using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V105.DOM;
using OpenQA.Selenium.Support.UI;
using Scenario_Team1_Auto.Common;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZendeskApi_v2.Models.Views.Executed;

namespace Scenario_Team1_Auto.PageObject
{
    public class CreateAssetPage : WebDriverAction
    {
        public CreateAssetPage(IWebDriver driver) : base(driver)
        {
        }



        public List<AssetDAO> testData = new List<AssetDAO>();

        private readonly string tfAssetName = "//input[@placeholder='Asset Name']";
        private readonly string dlCategory = "//span[@class='ant-select-selection-search']";
        private readonly string tfSpecifications = "//textarea[@placeholder='Specifications']";
        private readonly string tfEditSpecification = "//textarea[@placeholder='Specification']";
        private readonly string installedDate = "//input[@placeholder='Select date']";
        private readonly string editInstalledDate = "//input[@id='edit-asset_date']";
        private readonly string btnSave = "//span[contains(text(),'Save')]";


        private readonly string btnSearch = "//input[@placeholder='Search']";
        private readonly string iconSearch = "//span[@aria-label='search']";

        private readonly string btnEdit = "//span[@aria-label='edit']/parent::button";


        public void InputAssetData()
        {
            Commons commons = new Commons(driver);

            CreateAssetTestData createAssetTestData = new CreateAssetTestData();
            createAssetTestData.CreateAssetData();
            testData = createAssetTestData.assetData;
            var row = testData.ElementAt(0);

            IsElementDisable(btnSave);
            SendKey(tfAssetName, row.name);

            var category = "//div[@title='" + row.category + "']";
            commons.ClickAndSelect(dlCategory, category);

            SendKey(tfSpecifications, row.specification);

            commons.RemoveReadonlyAndSendKeys(installedDate, row.installedDate);

            string state = "//span[contains(text(),'" + row.state + "')]";
            Click(state);
            IsElementEnable(btnSave);
            Click(btnSave);
           

        }
        public void SearchAsset()
        {
            CreateAssetTestData createAssetTestData = new CreateAssetTestData();
            createAssetTestData.CreateAssetData();
            testData = createAssetTestData.assetData;
            var row = testData.ElementAt(0);

            SendKey(btnSearch, row.name);
            Click(iconSearch);
            Click(btnEdit);
          
        }
        public void EditAsset()
        {
            Commons commons = new Commons(driver);

            CreateAssetTestData createAssetTestData = new CreateAssetTestData();
            createAssetTestData.CreateAssetData();
            testData = createAssetTestData.assetData;
            var row = testData.ElementAt(0);
            var row2 = testData.ElementAt(1);

            commons.Replace2(tfAssetName, row2.name);


            IsElementDisable(dlCategory);

            commons.Replace(tfEditSpecification, row2.specification);

            commons.RemoveReadonlyAndSendKeys(editInstalledDate, row2.installedDate);
            string state = "//span[contains(text(),'" + row2.state + "')]";
            Click(state);
            IsElementEnable(btnSave);
            Click(btnSave);
           
        }
    }

}
