using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scenario_Team1_Auto.Services;
using Scenario_Team1_Auto.TestSetup;
using Scenario_Team1_Auto.DAO;

namespace RookiesTest.TestSetup
{
    public class NUnitAPITestSetup : NUnitTestSetup
    {
        public UserDAO user;
        public BookService bookService;
        [SetUp]
        public void SetUp()
        {
            AuthorizationService authorizationService = new AuthorizationService();
            bookService = new BookService();
            user = authorizationService.Login(Constant.USERNAME, Constant.PASSWORD);
        }
        [TearDown]
        public void TearDown()
        {
        }
    }
}
