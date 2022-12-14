using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject
{
    public class ManageAssetPage : WebDriverAction
    {
        public ManageAssetPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly string listAsset = "//tr[@class='ant-table-row ant-table-row-level-0']";
        private readonly string btnCreateAssets = "//span[contains(text(),'Create new asset')]";
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
