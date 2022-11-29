using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.TestSetup;


namespace Scenario_Team1_Auto.Services
{
    public class AssetService
    {
        private string getAssetPath = "/api/v1/admin/assets/";
                                     
        public APIResponse GetAssetRequest(string token)
        {
            APIResponse response = new APIRequest()
                .SetUrl(Constant.NASH_HOST + getAssetPath)
                .AddHeader("Authorization","Bearer " + token)
                .Get();
            return response;
        }

        public AssetsDAO GetAssets(string token)
        {
            APIResponse response = GetAssetRequest(token);
            Assert.True(response.responseStatusCode.Equals("OK"));
            var jsonResponse = response.responseBody;
            AssetsDAO content = (AssetsDAO)JsonConvert.DeserializeObject<AssetsDAO>(jsonResponse);
            return content;
        }
    }
}
