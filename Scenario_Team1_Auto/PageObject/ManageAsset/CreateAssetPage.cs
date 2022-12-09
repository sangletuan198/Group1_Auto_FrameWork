using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V105.DOM;
using OpenQA.Selenium.Support.UI;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZendeskApi_v2.Models.Views.Executed;

namespace Scenario_Team1_Auto.PageObject.ManageAsset
{
    public class CreateAssetPage : WebDriverAction
    {
        public CreateAssetPage(IWebDriver driver) : base(driver)
        {
        }
        public List<AssetDAO> testData = new List<AssetDAO>();

        private readonly String tfAssetName = "//input[@placeholder='Asset Name']";
        private readonly String dlCategory = "//span[@class='ant-select-selection-search']";
        private readonly String tfSpecifications = "//textarea[@placeholder='Specifications']";
        private readonly String installedDate = "//input[@placeholder='Select date']";
        private readonly String btnSave = "//span[contains(text(),'Save')]";


        private readonly String btnSearch = "//input[@placeholder='Search']";
        private readonly String iconSearch = "//span[@aria-label='search']";
        public void InputAssetData()
        {
           
            CreateAssetTestData createAssetTestData = new CreateAssetTestData();
            createAssetTestData.CreateAssetData();
            testData = createAssetTestData.assetData;
            var row = testData.ElementAt(0);

            IsElementDisable(btnSave);
            SendKey(tfAssetName, row.name);
       
            var category = "//div[@title='"+row.category+"']";
            ClickAndSelect(dlCategory, category);

            SendKey(tfSpecifications, row.specification);
            
            RemoveReadonlyAndSendKeys(installedDate, row.installedDate);

            String state = "//span[contains(text(),'"+row.state+"')]";
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

            SendKey(btnSearch,row.name);
            Click(iconSearch);
        }
    }

}
