﻿using NUnit.Framework;
using Scenario_Team1_Auto.PageObject;

using Scenario_Team1_Auto.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.TestCase
{
    [TestFixture]
    public class AssetTest : NashNUnitAPITestSetup
    {
        [Test]
        public void CreateAsset()
        {
            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            ManageAssetPage manageAssetPage = new ManageAssetPage(_driver);
            CreateAssetPage createAssetPage = new CreateAssetPage(_driver);
           
            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);
          
            homePage.GetAssetPage();
            
            manageAssetPage.GetCreateAssetPage();
            
            createAssetPage.InputAssetData();

            createAssetPage.SearchAsset();
           
            createAssetPage.EditAsset();

            homePage.Logout(newUserInfo.username);
        }

        [Test]
        public void DetailAsset()
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            ManageAssetPage manageAssetPage = new ManageAssetPage(_driver);
            CreateAssetPage createAssetPage = new CreateAssetPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);
       
            homePage.GetAssetPage();
            
            manageAssetPage.GetDetailOfRandomAsset();

        }
    }
}
