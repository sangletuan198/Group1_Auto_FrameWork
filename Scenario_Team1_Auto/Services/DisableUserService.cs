using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.TestData;
using Scenario_Team1_Auto.TestSetup;


namespace Scenario_Team1_Auto.Services
{
    public class DisableUserService
    {
        public APIResponse DisableUserRequest(string token,string username)
        {

            string disableUserPath = "/api/v1/admin/users/"+ username + "/disable";

            APIResponse response = new APIRequest()
                    .SetUrl(Constant.BASE_HOST + disableUserPath)
                    .AddHeader("Accept", "application/json, text/plain")
                    .AddHeader("Authorization", "Bearer " + token)
                    .Patch();
            return response;
        }
        public UserDAO CheckUserState(string token, string username)
        {
            APIResponse response = DisableUserRequest(token,username);
            Assert.True(response.responseStatusCode.Equals("OK"));
            var jsonResponse = response.responseBody;
            UserDAO userState = (UserDAO)JsonConvert.DeserializeObject<UserDAO>(jsonResponse);
            Assert.True(userState.active.Equals("false"));
            Console.WriteLine("User "+userState.username+" is disable");
            return userState;

        }
    }
}
