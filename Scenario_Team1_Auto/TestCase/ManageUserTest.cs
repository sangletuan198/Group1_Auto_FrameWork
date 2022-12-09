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
    public class ManageUserTest : NashNUnitAPITestSetup
    {
        [Test]
        public void AccessManageUserPage() // admin view ManageUser Page , Users List and detail of User
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            ManageUserPage managaUserPage = new ManageUserPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);

            homePage.GetManageUserPage();

            managaUserPage.ViewUserPage();
        }
        [Test]
        public void SearchByTypeAdmin() // search user with type as admin
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            ManageUserPage managaUserPage = new ManageUserPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);
            homePage.GetManageUserPage();
            Thread.Sleep(2000);
            managaUserPage.SearchByTypeAdmin();
        }
        [Test]
        public void SearchByTextFullname() // search user with fullname
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            ManageUserPage managaUserPage = new ManageUserPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);
            homePage.GetManageUserPage();
            managaUserPage.SearchByText();
        }
        [Test]
        public void CreateNewUser() //create new User
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            ManageUserPage managaUserPage = new ManageUserPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);
            homePage.GetManageUserPage();
            managaUserPage.CreateNewUser();
        }
        [Test]
        public void CancelCreateNewUser() // cancel creating new user 
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            ManageUserPage managaUserPage = new ManageUserPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);
            homePage.GetManageUserPage();
            managaUserPage.CancelCreateNewUser();
        }
        [Test]
        public void EditUser() // delete user 
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            ManageUserPage managaUserPage = new ManageUserPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);
            homePage.GetManageUserPage();
            managaUserPage.EditUser();
        }
        [Test]
        public void DeleteUser() // delete user 
        {

            HomePage homePage = new HomePage(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            ManageUserPage managaUserPage = new ManageUserPage(_driver);

            loginPage.Login(newUserInfo.username, Constant.NEW_PASSWORD);
            homePage.GetManageUserPage();
            managaUserPage.DeleteUser();
        }
    }
}
