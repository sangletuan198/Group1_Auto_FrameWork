using CoreFramework.DriverCore;
using OpenQA.Selenium;
using Scenario_Team1_Auto.TestData;

namespace Scenario_Team1_Auto.PageObject
{
    public class ManageAssetPage : WebDriverAction
    {
        public ManageAssetPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly string pageTitle = "//div[text()='Manage Assets']";
        private readonly string tableAsset = "//div[@class='ant-table']";
        private readonly string rowAsset = "//tr[@class='ant-table-row ant-table-row-level-0']";
        private readonly string detailAsset = "//div[@class='ant-modal-content']";
        private readonly string closeViewDetail = "//span[@aria-label='close']";

        private readonly string searchBox = "//input[@placeholder='Search']";
        private readonly string btnSearch = "//button[@class='ant-btn ant-btn-default ant-btn-icon-only ant-input-search-button']";
        private readonly string resultAssetName = "//td[text()='Monitor Dell UltraSharp']";

        private readonly string searchState = "//div[@class='ant-space-item'][1]";
        private readonly string stateAvailble = "//div[text()='Assigned' and @class='ant-select-item-option-content']";

        private readonly string searchCategory = "//div[@class='ant-space-item'][2]";
        private readonly string categoryLaptop = "//div[text()='Monitor' and @class='ant-select-item-option-content']";

        private readonly string btnCreateNewAsset = "//span[text()='Create new asset']";
        private readonly string inputName = "//input[@placeholder='Asset Name']";
        private readonly string inputSpeci = "//textarea[@placeholder='Specifications']";
        private readonly string inputCat = "//input[@id='create-new-asset_category']";
        private readonly string catLaptop = "//div[@title='Laptop']";
        private readonly string inputDate = "//input[@id='create-new-asset_installed_date']";
        private readonly string dateToday = "//a[@class='ant-picker-today-btn']";
        private readonly string btnSave = "//span[text()='Save']";

        private readonly string btnEdit = "//span[@aria-label='edit']";
        private readonly string radioWait = "//input[@value='WAITING_FOR_RECYCLING']";
        private readonly string btnSaveEdit = "//span[text()='Save']";

        private readonly string btnDelete = "(//span[@aria-label='close-circle'])[2]";
        private readonly string btnConfDelete = "//span[text()='Delete']";

        private readonly string listAsset = "//tr[@class='ant-table-row ant-table-row-level-0']";
        private readonly string btnCreateAssets = "//button[@class='ant-btn ant-btn-default ant-btn-dangerous']";

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
            
            Click(stateAvailble);
        }
        public void SearchByCategories()
        {
            IsElementDisplay(searchCategory);
            
            Click(searchCategory);
            Click(categoryLaptop);
        }

        public void CreateNewAsset()
        {
            Click(btnCreateNewAsset);
            SendKey(inputName, Asset.AssetName);
            SendKey(inputSpeci, Asset.AssetSpecification);
            Click(inputCat);
           
            Click(catLaptop);
            Click(inputDate);
            Click(dateToday);
            Click(btnSave);
            IsElementDisplay(Asset.ResultName);
        }
        public void EditAsset()
        {
            Click(btnEdit);
            Click(radioWait);
            Click(btnSaveEdit);
        }
        public void DeleteAsset()
        {
            Click(btnDelete);
            Click(btnConfDelete);
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