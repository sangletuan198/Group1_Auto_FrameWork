using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.TestData;
using Scenario_Team1_Auto.TestSetup;


namespace Scenario_Team1_Auto.Services
{
    public class CreateUserService
    {
        
        private string createUserPath = "/api/v1/admin/users";
        public List<CreateUserInfoDAO> testRecord = new List<CreateUserInfoDAO>();
        
        public APIResponse CreateNewUserRequest(string token,int i)
        {
            CreateUserTestData createUserTestData = new CreateUserTestData();
            createUserTestData.CreateUserData();
            testRecord = createUserTestData.userData;
            var row = testRecord.ElementAt(i);
            
            var body = "{\"birthDate\":\""+row.birthDate+"\"," +
                        "\"createdAt\":\""+row.createdAt+"\"," +
                        "\"firstName\":\""+row.firstName+"\"," +
                        "\"gender\":\""+row.gender+"\"," +
                        "\"lastName\":\""+row.lastName+"\"," +
                        "\"role\":\""+row.role+"\"}";

            TestContext.WriteLine(body);

            APIResponse response = new APIRequest()
                    .SetUrl(Constant.BASE_HOST + createUserPath)
                    .AddHeader("Content-Type", "application/json")
                    .AddHeader("Authorization", "Bearer " + token)
                    .SetBody(body)
                    .Post();
            return response;
        }
        public UserDAO GetNewUserInfo(string token, int i)
        {
            APIResponse response = CreateNewUserRequest(token,i);
            Assert.True(response.responseStatusCode.Equals("Created"));
            var jsonResponse = response.responseBody;
            UserDAO newUserInfo = (UserDAO)JsonConvert.DeserializeObject<UserDAO>(jsonResponse);

            return newUserInfo;
        }
        public static string ConversePassword(string userName,string password)
        {
            string trimPassword = password.Replace("-", "");
            var parsedPassword = DateTime.ParseExact(trimPassword, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            var reversePassword = parsedPassword.ToString("ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
            var newPassword = userName + "@" + reversePassword;
            return newPassword;
        }
    }
}
