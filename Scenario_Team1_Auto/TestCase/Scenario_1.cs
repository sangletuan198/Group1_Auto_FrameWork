using NUnit.Framework;
using RookiesTest.TestSetup;
using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.PageObject.ManageAsset;
using Scenario_Team1_Auto.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.TestCase
{
    [TestFixture]
    public class Scenario_1 : NUnitWebTestSetup// Admin manages staff members and setup assets
    {
        [Test]
        public void Scenario1() 
        {
            LoginPage login = new LoginPage(_driver);
            HomePage homePage = new HomePage(_driver);
            ManageUserPage manageUser = new ManageUserPage(_driver);
            ManageAssetPage manageAsset = new ManageAssetPage(_driver);
            ManageAssignmentsPage manageAssignment = new ManageAssignmentsPage(_driver);
            
            //1. admin login & view home page
            login.Login(Constant.ADMIN_USERNAME, Constant.ADMIN_PASSWORD);
            string title = _driver.Url;
            Assert.AreEqual("http://18.141.229.145/home", title);
            homePage.VerifyAdminAssignList();

            //2. admin manage user page
            homePage.GetManageUserPage();
            manageUser.ViewUserPage();      //admin view userlist
            manageUser.SearchByText();      //admin search by fullname, staffcode
            manageUser.SearchByType();    
            manageUser.CreateNewUser();     
            manageUser.EditUser();
            manageUser.DeleteUser();

            //3. admin view manage asset page
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
