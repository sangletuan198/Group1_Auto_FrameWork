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
        private readonly String pageTitle = "//div[text()='Manage Assets']";
        private readonly String tableAsset = "";
        private readonly String rowAsset = "";
        private readonly String detailAsset = "";
        private readonly String closeViewDetail = "";
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