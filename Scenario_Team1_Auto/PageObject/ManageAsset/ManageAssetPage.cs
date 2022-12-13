using CoreFramework.DriverCore;
using OpenQA.Selenium;
using Scenario_Team1_Auto.TestData;
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
        private readonly String pageTitle = "//div[text()='Manage Assets']";
        private readonly String tableAsset = "//div[@class='ant-table']";
        private readonly String rowAsset = "//tr[@class='ant-table-row ant-table-row-level-0']";
        private readonly String detailAsset = "//div[@class='ant-modal-content']";
        private readonly String closeViewDetail = "//span[@aria-label='close']";

        private readonly String searchBox = "//input[@placeholder='Search']";
        private readonly String btnSearch = "//button[@class='ant-btn ant-btn-default ant-btn-icon-only ant-input-search-button']";
        private readonly String resultAssetName = "//td[text()='MacBook Air M1MacBook Air M1 New']";

        private readonly String searchState= "//div[@class='ant-space-item'][1]";
        private readonly String stateAvailble= "//div[text()='Available' and @class='ant-select-item-option-content']";

        private readonly String searchCategory = "//div[@class='ant-space-item'][2]";
        private readonly String categoryLaptop= "//div[text()='Monitor' and @class='ant-select-item-option-content']";

        private readonly String btnCreateNewAsset = "//span[text()='Create new asset']";
        private readonly String inputName= "//input[@placeholder='Asset Name']";
        private readonly String inputSpeci= "//textarea[@placeholder='Specifications']";
        private readonly String inputCat= "//input[@id='create-new-asset_category']";
        private readonly String catLaptop= "//div[@title='Laptop']";
        private readonly String inputDate= "//input[@id='create-new-asset_installed_date']";
        private readonly String dateToday = "//a[@class='ant-picker-today-btn']";
        private readonly String btnSave = "//span[text()='Save']";

        private readonly String btnEdit = "//span[@aria-label='edit']";
        private readonly String btnSaveEdit = "//span[text()='Save']";

        private readonly String btnDelete = "(//span[@aria-label='close-circle'])[2]";
        private readonly String btnConfDelete = "//span[text()='Delete']";

        private readonly string listAsset = "//tr[@class='ant-table-row ant-table-row-level-0']";
        private readonly String btnCreateAssets = "//button[@class='ant-btn ant-btn-default ant-btn-dangerous']";

        public void ViewAssetPage()
        {
            IsElementDisplay(pageTitle);
            IsElementDisplay(tableAsset);
            Click(rowAsset);
            IsElementDisplay(detailAsset);
            Click(closeViewDetail);
        }
        public void SearchByText()
        {
            IsElementDisplay(searchBox);
            SendKey(searchBox, Asset.txtSearchName);
            Click(btnSearch);
            IsElementDisplay(resultAssetName);
        }
        public void SearchByState()
        {
            IsElementDisplay(searchState);
            Click(searchState);
            Thread.Sleep(2000);
            Click(stateAvailble);
            IsElementDisplay("AVAILABLE");
        }
        public void SearchByCategories()
        {
            IsElementDisplay(searchCategory);
            Thread.Sleep(2000);
            Click(searchCategory);
            Click(categoryLaptop);
            IsElementDisplay("Monitor");
        }

        public void CreateNewAsset()
        {
            Click(btnCreateNewAsset);
            SendKey(inputName, Asset.AssetName);
            SendKey(inputSpeci, Asset.AssetSpecification);
            Click(inputCat);
            Thread.Sleep(2000);
            Click(catLaptop);
            Click(inputDate);
            Click(dateToday);
            Click(btnSave);
            IsElementDisplay(Asset.ResultName);
        }
        public void EditAsset()
        {
            Click(btnEdit);
            Clear(inputName);
            SendKey(inputName, Asset.EditName);
            Click(btnSaveEdit);
            IsElementDisplay(Asset.ResultEditName);
        }
        public void DeleteAsset()
        {
            Click(btnDelete);
            Click(btnConfDelete);
            IsElementNotDisplay(Asset.ResultEditName);
        }

        public void GetCreateAssetPage()
        {
            Click(btnCreateAssets);
        }
        public IList<IWebElement> GetAssetList()
        {
            IList<IWebElement> randomAsset = FindElementsByXpath(listAsset);
            return randomAsset;
        }
        public void GetDetailOfRandomAsset()
        {
            IList<IWebElement> randomAsset = GetAssetList();
            foreach (var asset in randomAsset)
            {
                Console.WriteLine(asset.Text);
            }
            var random = new Random();
            int index = random.Next(randomAsset.Count);
            Click(randomAsset[index]);
            Console.WriteLine(randomAsset[index].Text);
        }
    }
}