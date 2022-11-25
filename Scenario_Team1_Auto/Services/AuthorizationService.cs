using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.TestSetup;


namespace Scenario_Team1_Auto.Services
{
    public class AuthorizationService
    {
        private string loginPath = "/Account/v1/Login";

        public APIResponse LoginRequest(string username, string password)
        {
            string body = "{\"userName\":\"" + username + "\",\"password\":\""+password+"\"}"; 
            TestContext.WriteLine(body);
            APIResponse response = new APIRequest()
                .SetUrl(Constant.BOOK_STORE_HOST + loginPath)
                .AddHeader("Content-Type", "application/json")
                .SetBody(body)
                .Post();
            
            return response;
        }

        public UserDAO Login(string username, string password)
        {
            APIResponse response = LoginRequest(username, password);
            Assert.True(response.responseStatusCode.Equals("OK"));

            UserDAO user = (UserDAO)JsonConvert.DeserializeObject<UserDAO>(response.responseBody);
            TestContext.WriteLine(user.token  );
            return user;
        }
    }
}
 