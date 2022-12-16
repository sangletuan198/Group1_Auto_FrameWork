using NUnit.Framework;

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
    public class Scenario_1 : NashNUnitAPITestSetup
    {
        [Test]
        public void Scenario1() 
        {
            LoginPage login = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageUserPage manageUser = new ManageUserPage(_driver);
            ManageAssetPage manageAsset = new ManageAssetPage(_driver);
            ManageAssignmentsPage manageAssignment = new ManageAssignmentsPage(_driver);
          
            login.Login(Constant.ADMIN_USERNAME, Constant.ADMIN_PASSWORD);
            string title = _driver.Url;
            Assert.AreEqual("http://18.141.229.145/home", title);
            homePage.VerifyAdminAssignList();
           
            homePage.GetManageUserPage();
            manageUser.ViewUserPage();      
            manageUser.SearchByText();     
            manageUser.SearchByType();    
            manageUser.CreateNewUser();     
            manageUser.EditUser();
            manageUser.DeleteUser();
         
            homePage.GetAssetPage();
            manageAsset.ViewAssetPage();
            manageAsset.SearchByState();
            manageAsset.SearchByCategories();
            manageAsset.SearchByText();
            manageAsset.CreateNewAsset();
            manageAsset.EditAsset();
            manageAsset.DeleteAsset();

        }
        
    }
}
