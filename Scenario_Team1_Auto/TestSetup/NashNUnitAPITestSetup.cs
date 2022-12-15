using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.PageObject;
using Scenario_Team1_Auto.Services;
using Newtonsoft.Json;
using Scenario_Team1_Auto.TestSetup;



namespace Scenario_Team1_Auto.TestSetup
{
    public class NashNUnitAPITestSetup : NUnitTestSetup
    {
        public AuthorizationDAO user;
        public UserDAO newUserInfo;
        public UserDAO userState;


        public NashAuthorizationService nashAuthorizationService;
        public CreateUserService createUserService;
        public DisableUserService disableUserService;
        public LoginPage loginPage;
        public ChangePasswordFirstTimeService changePasswordFirstTimeService;

        [SetUp]
        public void SetUp()
        {
            nashAuthorizationService = new NashAuthorizationService();
            createUserService = new CreateUserService();
            changePasswordFirstTimeService = new ChangePasswordFirstTimeService();


            user = nashAuthorizationService.Login(Constant.ADMIN_USERNAME, Constant.ADMIN_PASSWORD);

            newUserInfo = createUserService.GetNewUserInfo(user.accessToken, 0);

            string userName = newUserInfo.username;
            string password = CreateUserService.ConversePassword(userName, newUserInfo.birthDate);
            Console.WriteLine(userName);
            Console.WriteLine(password);

            user = nashAuthorizationService.Login(userName, password);

            changePasswordFirstTimeService.ChangePasswordRequest(user.accessToken, Constant.NEW_PASSWORD);

            driverBaseAction.GoToURL(Constant.BASE_HOST);
        }

        [TearDown]

        public void TearDown()
        {
            disableUserService = new DisableUserService();
            userState = disableUserService.CheckUserState(user.accessToken, newUserInfo.staffCode);
        }
    }
}
